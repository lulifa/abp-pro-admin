import type { OpenIddictAuthorizationDto } from "@/api/openiddict/openiddict-authorization/model";

interface FormItemProps extends OpenIddictAuthorizationDto {}

interface FormProps {
  formInline?: Partial<FormItemProps>;
  formOther?: {};
}

export type { FormItemProps, FormProps };
