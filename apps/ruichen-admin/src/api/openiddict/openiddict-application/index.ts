import { http } from "@/utils/http";
import { baseUrlApi } from "@/api/utils";

import type {
  OpenIddictApplicationDto,
  OpenIddictApplicationGetListInput,
  OpenIddictApplicationCreateDto,
  OpenIddictApplicationUpdateDto
} from "./model";

export const GetOpenIddictApplication = (id: string) => {
  return http.get<OpenIddictApplicationDto>(
    baseUrlApi(`openiddict/applications/${id}`)
  );
};

export const GetOpenIddictApplicationList = (
  input: OpenIddictApplicationGetListInput
) => {
  return http.get<PagedResultDto<OpenIddictApplicationDto>>(
    baseUrlApi("openiddict/applications"),
    {
      params: input
    }
  );
};

export const CreateOpenIddictApplication = (
  input: OpenIddictApplicationCreateDto
) => {
  return http.post<OpenIddictApplicationDto>(
    baseUrlApi("openiddict/applications"),
    {
      data: input
    }
  );
};

export const UpdateOpenIddictApplication = (
  id: string,
  input: OpenIddictApplicationUpdateDto
) => {
  return http.put<OpenIddictApplicationDto>(
    baseUrlApi(`openiddict/applications/${id}`),
    {
      data: input
    }
  );
};

export const DeleteOpenIddictApplication = (id: string) => {
  return http.delete(baseUrlApi(`openiddict/applications/${id}`));
};
