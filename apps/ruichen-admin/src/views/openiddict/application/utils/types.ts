import type {
  OpenIddictApplicationDto,
  OpenIddictApplicationCreateDto
} from "@/api/openiddict/openiddict-application/model";

interface FormItemProps
  extends OpenIddictApplicationDto,
    OpenIddictApplicationCreateDto {}

interface FormProps {
  formInline?: Partial<FormItemProps>;
  formOther?: {};
}

export type { FormItemProps, FormProps };
