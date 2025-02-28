import type { OpenIddictTokenDto } from "@/api/openiddict/openiddict-token/model";

interface FormItemProps extends OpenIddictTokenDto {}

interface FormProps {
  formInline?: Partial<FormItemProps>;
  formOther?: {};
}

export type { FormItemProps, FormProps };
