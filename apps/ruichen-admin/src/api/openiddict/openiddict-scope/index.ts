import { http } from "@/utils/http";
import { baseUrlApi } from "@/api/utils";

import type {
  OpenIddictScopeDto,
  OpenIddictScopeGetListInput,
  OpenIddictScopeCreateDto,
  OpenIddictScopeUpdateDto
} from "./model";

export const GetOpenIddictScope = (id: string) => {
  return http.get<OpenIddictScopeDto>(baseUrlApi(`openiddict/scopes/${id}`));
};

export const GetOpenIddictScopeList = (input: OpenIddictScopeGetListInput) => {
  return http.get<PagedResultDto<OpenIddictScopeDto>>(
    baseUrlApi("openiddict/scopes"),
    {
      params: input
    }
  );
};

export const CreateOpenIddictScope = (input: OpenIddictScopeCreateDto) => {
  return http.post<OpenIddictScopeDto>(baseUrlApi("openiddict/scopes"), {
    data: input
  });
};

export const UpdateOpenIddictScope = (
  id: string,
  input: OpenIddictScopeUpdateDto
) => {
  return http.put<OpenIddictScopeDto>(baseUrlApi(`openiddict/scopes/${id}`), {
    data: input
  });
};

export const DeleteOpenIddictScope = (id: string) => {
  return http.delete(baseUrlApi(`openiddict/scopes/${id}`));
};
