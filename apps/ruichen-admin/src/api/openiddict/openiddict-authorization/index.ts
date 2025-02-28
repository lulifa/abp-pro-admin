import { http } from "@/utils/http";
import { baseUrlApi } from "@/api/utils";

import type {
  OpenIddictAuthorizationDto,
  OpenIddictAuthorizationGetListInput
} from "./model";

export const GetOpenIddictAuthorization = (id: string) => {
  return http.get<OpenIddictAuthorizationDto>(
    baseUrlApi(`openiddict/authorizations/${id}`)
  );
};

export const GetOpenIddictAuthorizationList = (
  input: OpenIddictAuthorizationGetListInput
) => {
  return http.get<PagedResultDto<OpenIddictAuthorizationDto>>(
    baseUrlApi("openiddict/authorizations"),
    {
      params: input
    }
  );
};

export const DeleteOpenIddictAuthorization = (id: string) => {
  return http.delete(baseUrlApi(`openiddict/authorizations/${id}`));
};
