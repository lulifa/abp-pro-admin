import type {
  EditionDto,
  EditionCreateDto
} from "@/api/saas/saas-edition/model";

interface FormItemProps extends EditionDto, EditionCreateDto {}

interface FormProps {
  formInline?: Partial<FormItemProps>;
  formOther?: {};
}

export type { FormItemProps, FormProps };
