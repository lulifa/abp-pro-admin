interface FormItemPropsTenant {
  name?: string;
}

interface FormPropsTenant {
  formInline?: Partial<FormItemPropsTenant>;
  formOther?: {};
}

export type { FormItemPropsTenant, FormPropsTenant };
