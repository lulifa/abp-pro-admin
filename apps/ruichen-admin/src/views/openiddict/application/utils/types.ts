import type {
  OpenIddictApplicationDto,
  OpenIddictApplicationCreateDto
} from "@/api/openiddict/openiddict-application/model";

interface FormItemProps
  extends OpenIddictApplicationDto,
    OpenIddictApplicationCreateDto {
  menuType: number;
}

interface FormProps {
  formInline?: Partial<FormItemProps>;
  formOther?: {
    menuTypeOptions: any[];
    applicationTypeOptions: any[];
    clientTypeOptions: any[];
    consentTypeOptions: any[];
    endpointOptions: any[];
  };
}

export type { FormItemProps, FormProps };
