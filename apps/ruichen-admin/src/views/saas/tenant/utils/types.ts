import type { TenantDto, TenantCreateDto } from "@/api/saas/saas-tenant/model";
import type { Ref } from "vue";

interface FormItemProps extends TenantDto, TenantCreateDto {
  menuType: number;
}

interface FormProps {
  formInline?: Partial<FormItemProps>;
  formOther?: {
    menuTypeOptions: any[];
    editionOptions: any[];
    activeOptions: any[];
    shortcutsOptions: any[];
  };
}

interface FormItemPropsConnection {
  id: string;
  name: string;
  value: string;
}

interface FormPropsConnection {
  formInline?: Partial<FormItemPropsConnection>;
  formOther?: {
    loading: Ref<boolean>;
    dataList: Ref<any[]>;
    columns: any[];
    addClick: () => void;
    deleteClick: (row) => void;
  };
}

interface FormItemPropsConnectionAdd {
  id: string;
  name: string;
  value: string;
}

interface FormPropsConnectionAdd {
  formInline?: Partial<FormItemPropsConnectionAdd>;
  formOther?: object;
}

export type {
  FormItemProps,
  FormProps,
  FormItemPropsConnection,
  FormPropsConnection,
  FormItemPropsConnectionAdd,
  FormPropsConnectionAdd
};
