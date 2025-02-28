export interface OpenIddictScopeCreateOrUpdateDto extends ExtensibleObject {
  description?: string;
  descriptions?: Dictionary<string, string>;
  displayName?: string;
  displayNames?: Dictionary<string, string>;
  name: string;
  properties?: Dictionary<string, string>;
  resources?: string[];
}

export type OpenIddictScopeCreateDto = OpenIddictScopeCreateOrUpdateDto;

export interface OpenIddictScopeGetListInput
  extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export type OpenIddictScopeUpdateDto = OpenIddictScopeCreateOrUpdateDto;

export interface OpenIddictScopeDto extends ExtensibleAuditedEntityDto<string> {
  description?: string;
  descriptions?: Dictionary<string, string>;
  displayName?: string;
  displayNames?: Dictionary<string, string>;
  name: string;
  properties?: Dictionary<string, string>;
  resources?: string[];
}
