<script setup lang="ts">
import Cookies from "js-cookie";
import { useI18n } from "vue-i18n";
import { message } from "@/utils/message";
import { ref, h, watch } from "vue";
import { deviceDetection } from "@pureadmin/utils";
import { useRenderIcon } from "@/components/ReIcon/src/hooks";

import { ABP_TENANT_KEY } from "@/enums/cacheEnum";
import { addDialog } from "@/components/ReDialog";
import { useAbpStoreHook } from "@/store/modules/abp";
import { GetTenantByName } from "@/api/saas/saas-tenant";
import { useLocalization } from "@/hooks/abp/useLocalization";

import Motion from "../utils/motion";
import editFormTenant from "./SwitchTenantForm.vue";
import type { FormPropsTenant, FormItemPropsTenant } from "../utils/types";

import Tenant from "@iconify-icons/ri/home-gear-line";

defineOptions({
  name: "SwtichSaasTenant"
});

const { t } = useI18n();
const { L } = useLocalization("AbpUiMultiTenancy");

const formRefTenant = ref();

const multiTenancyEnabled = ref(false);
const currentTenant = ref<CurrentTenant>();

watch(
  () => useAbpStoreHook().getApplication,
  newApp => {
    multiTenancyEnabled.value = newApp?.multiTenancy?.isEnabled;
    currentTenant.value = newApp?.currentTenant;
  },
  { deep: true, immediate: true }
);

const switchTenant = async () => {
  let props = await propsFormInline();
  const dialogTitle = `切换租户`;
  addDialog({
    title: dialogTitle,
    props: props,
    width: "30%",
    sureBtnLoading: true,
    draggable: true,
    fullscreen: deviceDetection(),
    fullscreenIcon: false,
    closeOnClickModal: false,
    contentRenderer: () =>
      h(editFormTenant, {
        ref: formRefTenant,
        formInline: props.formInline
      }),
    beforeSure: (done, { options, closeLoading }) => {
      try {
        debugger;
        const FormRef = formRefTenant.value.getRef();
        const curData = options.props.formInline as FormItemPropsTenant;

        function chores() {
          done();
        }
        FormRef.validate(valid => {
          if (valid) {
            if (curData.name) {
              GetTenantByName(curData.name).then(result => {
                if (!result.id) {
                  message(L("GivenTenantIsNotExist", [curData.name]), {
                    type: "warning"
                  });
                  return;
                }
                if (!result.isActive) {
                  message(L("GivenTenantIsNotAvailable", [curData.name]), {
                    type: "warning"
                  });
                  return;
                }
                Cookies.set(ABP_TENANT_KEY, result.id);
                chores();
              });
            } else {
              Cookies.remove(ABP_TENANT_KEY);
              chores();
            }
            setTimeout(async () => {
              await useAbpStoreHook().initlizeAbpApplication();
            }, 100);
          }
        });
      } finally {
        closeLoading();
      }
    },
    closeCallBack: () => {}
  });
};
const propsFormInline = async () => {
  let props: FormPropsTenant = {
    formInline: {
      name: currentTenant.value.name
    },
    formOther: {}
  };
  return props;
};
</script>

<template>
  <div v-if="multiTenancyEnabled">
    <Motion :delay="50">
      <el-form-item size="large">
        <el-input
          readonly
          :placeholder="t('login.pureTenant')"
          :prefix-icon="useRenderIcon(Tenant)"
          :value="currentTenant.name"
        >
          <template v-slot:append>
            <el-button link class="w-28" @click="switchTenant">
              {{ t("login.pureSwitch") }}
            </el-button>
          </template>
        </el-input>
      </el-form-item>
    </Motion>
  </div>
</template>
