import type {
  OpenIddictScopeDto,
  OpenIddictScopeCreateDto
} from "@/api/openiddict/openiddict-scope/model";

interface FormItemProps extends OpenIddictScopeDto, OpenIddictScopeCreateDto {}

interface FormProps {
  formInline?: Partial<FormItemProps>;
  formOther?: {};
}

export type { FormItemProps, FormProps };
