import { defineStore } from "pinia";
import { ABP_APP_KEY, ABP_API_KEY } from "@/enums/cacheEnum";
import { i18n } from "@/plugins/i18n";
import { store, storageLocal } from "../utils";
import { getApplicationConfiguration } from "@/api/abp/abp-configuration";
import { getApiDefinition } from "@/api/abp/abp-definition";
import { ApplicationApiDescriptionModel } from "@/api/abp/abp-definition/model";

const ls = storageLocal();

const defaultApp = {};
const defaultApi = new ApplicationApiDescriptionModel();

const lsApplication = (ls.getItem(ABP_APP_KEY) ||
  defaultApp) as ApplicationConfigurationDto;
const lsApiDefinition = (ls.getItem(ABP_API_KEY) ||
  defaultApi) as ApplicationApiDescriptionModel;

interface AbpState {
  application: ApplicationConfigurationDto;
  apidefinition: ApplicationApiDescriptionModel;
}

export const useAbpStore = defineStore("abp", {
  state: (): AbpState => ({
    application: lsApplication,
    apidefinition: lsApiDefinition
  }),
  getters: {
    getApplication(state): ApplicationConfigurationDto {
      return state.application || ls.getItem(ABP_APP_KEY);
    },
    getApiDefinition(state): ApplicationApiDescriptionModel {
      return state.apidefinition || ls.getItem(ABP_API_KEY);
    }
  },
  actions: {
    setApplication(application: ApplicationConfigurationDto) {
      this.application = application;
      ls.setItem(ABP_APP_KEY, application);
    },
    removeApplication() {
      this.application = lsApplication;
      ls.removeItem(ABP_APP_KEY);
    },
    setApiDefinition(apidefinition: ApplicationApiDescriptionModel) {
      this.apidefinition = apidefinition;
      ls.setItem(ABP_API_KEY, apidefinition);
    },
    removeApiDefinition() {
      this.apidefinition = lsApiDefinition;
      ls.removeItem(ABP_API_KEY);
    },
    mergeLocaleMessage(localization: ApplicationLocalizationConfigurationDto) {
      debugger;
      if (localization.languagesMap["pure-admin-ui"]) {
        const transferCulture = localization.languagesMap[
          "pure-admin-ui"
        ].filter(x => x.value === localization.currentCulture.cultureName);
        function transformAbpLocaleMessageDicToI18n(abpLocaleMessageDic) {
          const i18nLocaleMessageDic = {};
          Object.keys(abpLocaleMessageDic).forEach(vKey => {
            i18nLocaleMessageDic[vKey] = {};
            Object.keys(abpLocaleMessageDic[vKey]).forEach(mKey => {
              let msgKey = mKey;
              // 处理最后一个字符以适配 i18n
              if (msgKey.endsWith(".")) {
                msgKey = msgKey.substring(0, msgKey.length - 1);
              }
              i18nLocaleMessageDic[vKey][msgKey] =
                abpLocaleMessageDic[vKey][mKey];
            });
          });
          return i18nLocaleMessageDic;
        }
        if (transferCulture && transferCulture.length > 0) {
          i18n.global.mergeLocaleMessage(
            transferCulture[0].name,
            transformAbpLocaleMessageDicToI18n(localization.values)
          );
        } else {
          i18n.global.mergeLocaleMessage(
            localization.currentCulture.cultureName,
            transformAbpLocaleMessageDicToI18n(localization.values)
          );
        }
      }
    },
    async initlizeAbpApplication() {
      const application = await getApplicationConfiguration();
      this.setApplication(application);

      // 多语言合并设置 TO  多语言提示要怎么兼容下
      const { localization } = application;
      this.mergeLocaleMessage(localization);
    },
    async initlizaAbpApiDefinition() {
      const apidefinition = await getApiDefinition();
      this.setApiDefinition(apidefinition);
    }
  }
});

export function useAbpStoreWithOut() {
  return useAbpStore(store);
}
