import editForm from "../form/form.vue";
import { transformI18n } from "@/plugins/i18n";
import { addDialog } from "@/components/ReDialog";
import type { PaginationProps } from "@pureadmin/table";
import { deviceDetection } from "@pureadmin/utils";
import { reactive, ref, onMounted, toRaw, computed, h } from "vue";
import type { FormProps, FormItemProps } from "../utils/types";

import {
  GetOpenIddictScope,
  GetOpenIddictScopeList,
  CreateOpenIddictScope,
  UpdateOpenIddictScope,
  DeleteOpenIddictScope
} from "@/api/openiddict/openiddict-scope";

import type { OpenIddictScopeGetListInput } from "@/api/openiddict/openiddict-scope/model";

export function useOpenIddictScope() {
  const pagination = reactive<PaginationProps>({
    total: 0,
    pageSize: 10,
    currentPage: 1,
    background: true
  });

  const form = reactive<Partial<OpenIddictScopeGetListInput>>({
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
      label: "名称",
      prop: "name"
    },
    {
      label: "显示名称",
      prop: "displayName"
    },
    {
      label: "描述",
      prop: "description"
    },
    {
      label: "创建日期",
      prop: "creationTime"
    },
    {
      label: "操作",
      fixed: "right",
      width: 240,
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
      const data = await GetOpenIddictScopeList(toRaw(form));
      dataList.value = data.items;
      pagination.total = data.totalCount;
    } finally {
      loading.value = false;
    }
  }

  async function openDialog(title = "新增", row?: FormItemProps) {
    let props = await propsFormInline(title, row);
    const dialogTitle = `${title}应用${row?.displayName ? ` - ${row.displayName}` : ""}`;
    addDialog({
      title: dialogTitle,
      props: props,
      width: "50%",
      sureBtnLoading: true,
      draggable: true,
      fullscreen: deviceDetection(),
      fullscreenIcon: false,
      closeOnClickModal: false,
      contentRenderer: () =>
        h(editForm, {
          ref: formRef
        }),
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
                await CreateOpenIddictScope(curData);
              } else {
                await UpdateOpenIddictScope(curData.id, curData);
              }
              chores();
            }
          });
        } finally {
          closeLoading();
        }
      },
      closeCallBack: () => {}
    });
  }

  async function propsFormInline(title, row?: FormItemProps) {
    let props: FormProps = {
      formInline: {
        displayName: ""
      },
      formOther: {}
    };

    if (title !== "新增") {
      const res = await GetOpenIddictScope(row?.id);
      if (res) {
        props.formInline.id = res.id;
        props.formInline.displayName = res.displayName;
      }
    }
    return props;
  }

  async function handleDelete(row?: FormItemProps) {
    await DeleteOpenIddictScope(row?.id);
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

  onMounted(() => {
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
