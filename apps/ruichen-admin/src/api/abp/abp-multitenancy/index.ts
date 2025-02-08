import { http } from "@/utils/http";
import { baseUrlApi } from "@/api/utils";

import type { FindTenantResult } from "./model";

export const findTenantByName = (name: string) => {
  return http.get<FindTenantResult>(
    baseUrlApi(`abp/multi-tenancy/tenants/by-name/${name}`)
  );
};

export const findTenantById = (id: string) => {
  return http.get<FindTenantResult>(
    baseUrlApi(`abp/multi-tenancy/tenants/by-id/${id}`)
  );
};
