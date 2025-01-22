import type { TenantDto, TenantCreateDto } from "@/api/saas/saas-tenant/model";

interface FormItemProps extends TenantDto, TenantCreateDto {}

interface FormProps {
  formInline: Partial<FormItemProps>;
}

export type { FormItemProps, FormProps };
