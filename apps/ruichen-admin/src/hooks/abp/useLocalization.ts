import { computed } from "vue";
import { merge } from "lodash-es";
import { format } from "../utils/string";
import { useAbpStoreHook } from "@/store/modules/abp";

export function useLocalization(resourceNames?: string | string[]) {
  const getResource = computed(() => {
    const abpStore = useAbpStoreHook();
    const { values } = abpStore.getApplication.localization;

    let resource: { [key: string]: string } = {};
    if (resourceNames) {
      if (Array.isArray(resourceNames)) {
        resourceNames.forEach(name => {
          resource = merge(resource, values[name]);
        });
      } else {
        resource = merge(resource, values[resourceNames]);
      }
    } else {
      Object.keys(values).forEach(rs => {
        resource = merge(resource, values[rs]);
      });
    }

    return resource;
  });
  const getResourceByName = computed(() => {
    return (resource: string): Dictionary<string, string> => {
      const abpStore = useAbpStoreHook();
      const { values } = abpStore.getApplication.localization;
      if (Reflect.has(values, resource)) {
        return values[resource];
      }
      return {};
    };
  });

  function L(key: string, args?: Recordable | any[] | undefined) {
    if (!key) return "";
    if (!getResource.value) return key;
    if (!Reflect.has(getResource.value, key)) return key;
    return format(getResource.value[key], args ?? []);
  }

  function Lr(
    resource: string,
    key: string,
    args?: Recordable | any[] | undefined
  ) {
    if (!key) return "";
    const findResource = getResourceByName.value(resource);
    if (!findResource) return key;
    if (!Reflect.has(findResource, key)) return key;
    return format(findResource[key], args ?? []);
  }

  const localizer: IStringLocalizer = {
    L: L,
    Lr: Lr
  };

  return { L, Lr, localizer };
}
