import { http } from "@/utils/http";
import { baseUrlApi } from "@/api/utils";

import type {
  TenantDto,
  TenantGetListInput,
  TenantCreateDto,
  TenantUpdateDto,
  TenantConnectionStringDto,
  TenantConnectionStringCreateOrUpdate
} from "./model";

export const GetTenant = (id: string) => {
  return http.get<TenantDto>(baseUrlApi(`saas/tenants/${id}`));
};

export const GetTenantByName = (name: string) => {
  return http.get<TenantDto>(baseUrlApi(`saas/tenants/by-name/${name}`));
};

export const GetTenantList = (input: TenantGetListInput) => {
  return http.get<PagedResultDto<TenantDto>>(baseUrlApi(`saas/tenants`), {
    params: input
  });
};

export const CreateTenant = (input: TenantCreateDto) => {
  return http.post<TenantDto>(baseUrlApi(`saas/tenants`), {
    data: input
  });
};

export const UpdateTenant = (id: string, input: TenantUpdateDto) => {
  return http.put<TenantDto>(baseUrlApi(`saas/tenants/${id}`), {
    data: input
  });
};

export const DeleteTenant = (id: string) => {
  return http.delete(baseUrlApi(`saas/tenants/${id}`));
};

export const GetTenantConnectionStringByName = (id: string, name: string) => {
  return http.get<TenantConnectionStringDto>(
    baseUrlApi(`saas/tenants/${id}/connection-string/${name}`)
  );
};

export const GetTenantConnectionString = (id: string) => {
  return http.get<ListResultDto<TenantConnectionStringDto>>(
    baseUrlApi(`saas/tenants/${id}/connection-string`)
  );
};

export const UpdateTenantConnectionString = (
  id: string,
  input: TenantConnectionStringCreateOrUpdate
) => {
  return http.put<TenantConnectionStringDto>(
    baseUrlApi(`saas/tenants/${id}/connection-string`),
    { data: input }
  );
};

export const DeleteTenantConnectionString = (id: string, name: string) => {
  return http.delete(
    baseUrlApi(`saas/tenants/${id}/connection-string/${name}`)
  );
};
