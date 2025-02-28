export interface OpenIddictApplicationFeaturesDto {
  requirePkce?: boolean;
}

export interface OpenIddictApplicationRequirementsDto {
  features: OpenIddictApplicationFeaturesDto;
}

export interface OpenIddictApplicationTokenLifetimesDto {
  accessToken?: number;
  authorizationCode?: number;
  deviceCode?: number;
  identityToken?: number;
  refreshToken?: number;
  userCode?: number;
}

export interface OpenIddictApplicationSettingsDto {
  tokenLifetime: OpenIddictApplicationTokenLifetimesDto;
}

export interface OpenIddictApplicationGetListInput
  extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface OpenIddictApplicationCreateOrUpdateDto
  extends ExtensibleObject {
  applicationType?: string;
  clientId: string;
  clientSecret?: string;
  clientType?: string;
  clientUri?: string;
  consentType?: string;
  displayName?: string;
  displayNames?: Dictionary<string, string>;
  endpoints?: string[];
  grantTypes?: string[];
  logoUri?: string;
  postLogoutRedirectUris?: string[];
  properties?: Dictionary<string, string>;
  redirectUris?: string[];
  requirements: OpenIddictApplicationRequirementsDto;
  responseTypes?: string[];
  scopes?: string[];
  settings: OpenIddictApplicationSettingsDto;
}

export type OpenIddictApplicationCreateDto =
  OpenIddictApplicationCreateOrUpdateDto;

export type OpenIddictApplicationUpdateDto =
  OpenIddictApplicationCreateOrUpdateDto;

export interface OpenIddictApplicationDto
  extends ExtensibleAuditedEntityDto<string> {
  applicationType?: string;
  clientId: string;
  clientSecret?: string;
  clientType?: string;
  clientUri?: string;
  consentType?: string;
  displayName?: string;
  displayNames?: Dictionary<string, string>;
  endpoints?: string[];
  grantTypes?: string[];
  logoUri?: string;
  postLogoutRedirectUris?: string[];
  properties?: Dictionary<string, string>;
  redirectUris?: string[];
  requirements: OpenIddictApplicationRequirementsDto;
  responseTypes?: string[];
  scopes?: string[];
  settings: OpenIddictApplicationSettingsDto;
}
