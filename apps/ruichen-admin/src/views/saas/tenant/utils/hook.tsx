import dayjs from "dayjs";
import editForm from "../form/form.vue";
import editFormConnection from "../form/formconnection.vue";
import indexConnection from "../indexConnection.vue";
import { transformI18n } from "@/plugins/i18n";
import { addDialog } from "@/components/ReDialog";
import type { PaginationProps } from "@pureadmin/table";
import { deviceDetection } from "@pureadmin/utils";
import { reactive, ref, onMounted, toRaw, computed, h } from "vue";
import type {
  FormProps,
  FormItemProps,
  FormItemPropsConnection,
  FormPropsConnection,
  FormItemPropsConnectionAdd,
  FormPropsConnectionAdd
} from "../utils/types";
import { activeOptions, menuTypeOptions, shortcutsOptions } from "./enums";

import {
  GetTenant,
  GetTenantList,
  CreateTenant,
  UpdateTenant,
  DeleteTenant,
  // GetTenantConnectionStringByName,
  GetTenantConnectionString,
  UpdateTenantConnectionString,
  DeleteTenantConnectionString
} from "@/api/saas/saas-tenant";
import { GetEditionList } from "@/api/saas/saas-edition";

import type { TenantGetListInput } from "@/api/saas/saas-tenant/model";
import type { EditionGetListInput } from "@/api/saas/saas-edition/model";

export function useSaasTenant() {
  // 租户
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

  const editionOptions = ref([]);

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
      label: "启用时间UTC",
      prop: "enableTime",
      formatter: ({ enableTime }) =>
        enableTime ? dayjs(enableTime).format("YYYY-MM-DD") : ""
    },
    {
      label: "禁用时间UTC",
      prop: "disableTime",
      formatter: ({ disableTime }) =>
        disableTime ? dayjs(disableTime).format("YYYY-MM-DD") : ""
    },
    {
      label: "激活状态",
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

  // 租户连接字符串
  const selectedRow = ref<FormItemProps>(null);

  const formRefConnection = ref();

  const formRefConnectionAdd = ref();

  const loadingConnection = ref(true);

  const dataListConnection = ref([]);

  const columnsConnection: TableColumnList = [
    {
      label: "名称",
      prop: "name",
      width: 150
    },
    {
      label: "值",
      prop: "value"
    },
    {
      label: "操作",
      headerAlign: "center",
      align: "center",
      fixed: "right",
      width: 150,
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
      const data = await GetTenantList(toRaw(form));
      dataList.value = data.items;
      pagination.total = data.totalCount;
    } finally {
      loading.value = false;
    }
  }

  async function onSearchConnection() {
    loadingConnection.value = true;
    try {
      const data = await GetTenantConnectionString(selectedRow?.value?.id);
      dataListConnection.value = data.items;
    } finally {
      loadingConnection.value = false;
    }
  }

  async function openDialog(title = "新增", row?: FormItemProps) {
    let props = await propsFormInline(title, row);
    const dialogTitle = `${title}租户${row?.name ? ` - ${row.name}` : ""}`;
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
                await CreateTenant(curData);
              } else {
                await UpdateTenant(curData.id, curData);
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
        menuType: 0,
        id: null,
        name: "",
        editionId: null,
        isActive: true,
        enableTime: new Date().toISOString(),
        disableTime: null,
        concurrencyStamp: null,
        useSharedDatabase: true
      },
      formOther: {
        menuTypeOptions: menuTypeOptions,
        editionOptions: editionOptions.value,
        activeOptions: activeOptions,
        shortcutsOptions: shortcutsOptions
      }
    };

    if (title !== "新增") {
      const res = await GetTenant(row?.id);
      if (res) {
        props.formInline.id = res.id;
        props.formInline.name = res.name;
        props.formInline.editionId = res.editionId;
        props.formInline.isActive = res.isActive;
        props.formInline.enableTime = res.enableTime;
        props.formInline.disableTime = res.disableTime;
        props.formInline.concurrencyStamp = res.concurrencyStamp;
      }
      // 编辑不需要tab页
      props.formOther.menuTypeOptions = [];
    }
    return props;
  }

  async function openDialogConnection(row?: FormItemProps) {
    let props = await propsFormInlineConnection(row);
    const dialogTitle = `租户${selectedRow?.value?.name ? ` - ${selectedRow?.value?.name}` : ""}`;
    addDialog({
      title: dialogTitle,
      props: props,
      width: "50%",
      draggable: true,
      hideFooter: true,
      closeOnClickModal: false,
      contentRenderer: () =>
        h(indexConnection, {
          ref: formRefConnection
        }),
      closeCallBack: () => {
        selectedRow.value = null;
      }
    });
  }

  async function propsFormInlineConnection(row?: FormItemProps) {
    // 组装参数
    selectedRow.value = row;

    await onSearchConnection();

    let props: FormPropsConnection = {
      formInline: {
        id: selectedRow?.value?.id,
        name: "",
        value: ""
      },
      formOther: {
        loading: loadingConnection,
        dataList: dataListConnection,
        columns: columnsConnection,
        addClick: openDialogConnectionAdd,
        deleteClick: handleDeleteConnection
      }
    };
    return props;
  }

  async function openDialogConnectionAdd() {
    let props = await propsFormInlineConnectionAdd();
    const dialogTitle = `连接字符串`;
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
        h(editFormConnection, {
          ref: formRefConnectionAdd,
          formInline: props.formInline
        }),
      beforeSure: (done, { options, closeLoading }) => {
        try {
          const FormRef = formRefConnectionAdd.value.getRef();
          const curData = options.props
            .formInline as FormItemPropsConnectionAdd;

          function chores() {
            done();
            onSearchConnection();
          }
          FormRef.validate(async valid => {
            if (valid) {
              await UpdateTenantConnectionString(curData.id, curData);
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

  async function propsFormInlineConnectionAdd() {
    let props: FormPropsConnectionAdd = {
      formInline: {
        id: selectedRow?.value?.id,
        name: "",
        value: ""
      }
    };
    return props;
  }

  async function handleDelete(row?: FormItemProps) {
    await DeleteTenant(row?.id);
    onSearch();
  }

  async function handleDeleteConnection(row?: FormItemPropsConnection) {
    await DeleteTenantConnectionString(selectedRow?.value?.id, row?.name);
    onSearchConnection();
  }

  async function loadEditionOptions() {
    let params: EditionGetListInput = {
      isPaged: false
    };
    const res = await GetEditionList(params);
    if (res) {
      editionOptions.value = res.items;
    }
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

  async function loadOptions() {
    await loadEditionOptions();
  }

  onMounted(() => {
    onSearch();
    loadOptions();
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
    openDialogConnection,
    handleDelete,
    transformI18n,
    handleSizeChange,
    handleCurrentChange,
    handleSelectionChange
  };
}
