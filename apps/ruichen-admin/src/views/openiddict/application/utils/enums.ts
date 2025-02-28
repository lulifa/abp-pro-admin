import type { OptionsType } from "@/components/ReSegmented";

export const menuTypeOptions: Array<OptionsType> = [
  {
    label: "基本信息",
    value: 0
  },
  {
    label: "显示名称",
    value: 1
  },
  {
    label: "重定向Uri",
    value: 2
  },
  {
    label: "注销重定向Uri",
    value: 3
  },
  {
    label: "令牌",
    value: 4
  },
  {
    label: "范围",
    value: 5
  },
  {
    label: "授权",
    value: 6
  },
  {
    label: "属性",
    value: 7
  }
];

export const applicationTypeOptions: Array<NameValue> = [
  {
    text: "Web",
    value: "web"
  },
  {
    text: "Native",
    value: "native"
  }
];

export const clientTypeOptions: Array<NameValue> = [
  {
    text: "public",
    value: "public"
  },
  {
    text: "confidential",
    value: "confidential"
  }
];

export const consentTypeOptions: Array<NameValue> = [
  {
    text: "explicit",
    value: "explicit"
  },
  {
    text: "external",
    value: "external"
  },
  {
    text: "implicit",
    value: "implicit"
  },
  {
    text: "systematic",
    value: "systematic"
  }
];

export const endpointOptions: Array<NameValue> = [
  {
    text: "authorization",
    value: "authorization"
  },
  {
    text: "token",
    value: "token"
  },
  {
    text: "logout",
    value: "logout"
  },
  {
    text: "device",
    value: "device"
  },
  {
    text: "revocation",
    value: "revocation"
  },
  {
    text: "introspection",
    value: "introspection"
  }
];
