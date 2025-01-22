import editForm from "../form/form.vue";
import { transformI18n } from "@/plugins/i18n";
import { addDialog } from "@/components/ReDialog";
import type { PaginationProps } from "@pureadmin/table";
import { deviceDetection } from "@pureadmin/utils";
import { reactive, ref, onMounted, h, toRaw, computed } from "vue";
import type { FormProps, FormItemProps } from "../utils/types";

import {
  GetAsyncById,
  GetListAsyncByInput,
  CreateAsyncByInput,
  UpdateAsyncByIdAndInput,
  DeleteAsyncById
  // GetConnectionStringAsyncByIdAndName,
  // GetConnectionStringAsyncById,
  // SetConnectionStringAsyncByIdAndInput,
  // DeleteConnectionStringAsyncByIdAndName
} from "@/api/saas/saas-tenant";

import type { TenantGetListInput } from "@/api/saas/saas-tenant/model";

export function useSaasTenant() {
  const pagination = reactive<PaginationProps>({
    total: 0,
    pageSize: 10,
    currentPage: 1,
    background: true
  });

  const form = reactive<Partial<TenantGetListInput>>({
    get skipCount() {
      return (pagination.currentPage - 1) * pagination.pageSize;
    },
    get maxResultCount() {
      return pagination.pageSize;
    }
  });

  const formRef = ref();

  const dataList = ref([]);

  const loading = ref(true);

  const columns: TableColumnList = [
    {
      label: "租户名称",
      prop: "name"
    },
    {
      label: "版本名称",
      prop: "editionName"
    },
    {
      label: "版本失效日期UTC",
      prop: "disableTime"
    },
    {
      label: "启用",
      prop: "isActive",
      cellRenderer: scope => <el-switch v-model={scope.row.isActive} disabled />
    },
    {
      label: "操作",
      fixed: "right",
      width: 200,
      slot: "operation"
    }
  ];

  const buttonClass = computed(() => {
    return [
      "!h-[20px]",
      "reset-margin",
      "!text-gray-500",
      "dark:!text-white",
      "dark:hover:!text-primary"
    ];
  });

  const resetForm = formEl => {
    if (!formEl) return;
    formEl.resetFields();
    onSearch();
  };

  async function onSearch() {
    loading.value = true;
    try {
      const data = await GetListAsyncByInput(toRaw(form));
      dataList.value = data.items;
      pagination.total = data.totalCount;
    } finally {
      loading.value = false;
    }
  }

  async function openDialog(title = "新增", row?: FormItemProps) {
    let props = await propsFormInline(title, row);
    addDialog({
      title: `${title}租户`,
      props: props,
      width: "70%",
      sureBtnLoading: true,
      draggable: true,
      fullscreen: deviceDetection(),
      fullscreenIcon: false,
      closeOnClickModal: false,
      contentRenderer: () => h(editForm, { ref: formRef }),
      beforeSure: (done, { options, closeLoading }) => {
        try {
          const FormRef = formRef.value.getRef();
          const curData = options.props.formInline as FormItemProps;

          function chores() {
            done();
            onSearch();
          }
          FormRef.validate(async valid => {
            if (valid) {
              if (title === "新增") {
                await CreateAsyncByInput(curData);
              } else {
                await UpdateAsyncByIdAndInput(curData.id, curData);
              }
              chores();
            }
          });
        } finally {
          closeLoading();
        }
      }
    });
  }

  async function propsFormInline(title, row?: FormItemProps) {
    let props: FormProps = {
      formInline: {
        id: null,
        name: "",
        editionId: null,
        isActive: null,
        enableTime: null,
        disableTime: null,
        concurrencyStamp: null
      }
    };

    if (title !== "新增") {
      const res = await GetAsyncById(row?.id);
      if (res) {
        props.formInline.id = res.id;
        props.formInline.name = res.name;
        props.formInline.editionId = res.editionId;
        props.formInline.isActive = res.isActive;
        props.formInline.enableTime = res.enableTime;
        props.formInline.disableTime = res.disableTime;
        props.formInline.concurrencyStamp = res.concurrencyStamp;
      }
    }
    return props;
  }

  async function handleDelete(row?: FormItemProps) {
    await DeleteAsyncById(row?.id);
    onSearch();
  }

  function handleSizeChange(val: number) {
    pagination.pageSize = val;
    onSearch();
  }

  function handleCurrentChange(val: number) {
    pagination.currentPage = val;
    onSearch();
  }

  function handleSelectionChange(val) {
    console.log(val);
  }

  onMounted(async () => {
    onSearch();
  });

  return {
    form,
    loading,
    columns,
    dataList,
    pagination,
    buttonClass,
    onSearch,
    resetForm,
    openDialog,
    handleDelete,
    transformI18n,
    handleSizeChange,
    handleCurrentChange,
    handleSelectionChange
  };
}
