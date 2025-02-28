import { http } from "@/utils/http";
import { baseUrlApi } from "@/api/utils";

import type { OpenIddictTokenDto, OpenIddictTokenGetListInput } from "./model";

export const GetOpenIddictToken = (id: string) => {
  return http.get<OpenIddictTokenDto>(baseUrlApi(`openiddict/tokens/${id}`));
};

export const GetOpenIddictTokenList = (input: OpenIddictTokenGetListInput) => {
  return http.get<PagedResultDto<OpenIddictTokenDto>>(
    baseUrlApi("openiddict/tokens"),
    {
      params: input
    }
  );
};

export const DeleteOpenIddictToken = (id: string) => {
  return http.delete(baseUrlApi(`openiddict/tokens/${id}`));
};
