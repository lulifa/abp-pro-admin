import type { TenantDto, TenantCreateDto } from "@/api/saas/saas-tenant/model";

interface FormItemProps extends TenantDto, TenantCreateDto {
  menuType: number;
}

interface FormProps {
  formInline: Partial<FormItemProps>;
  menuTypeOptions: any[];
  editionOptions: any[];
  activeOptions: any[];
  shortcutsOptions: any[];
}

export type { FormItemProps, FormProps };
