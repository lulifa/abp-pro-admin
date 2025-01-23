import { reactive, computed } from "vue";
import type { FormRules } from "element-plus";
// import { $t, transformI18n } from "@/plugins/i18n";

/** 自定义表单规则校验 */
export const formRules = computed(() => {
  const rules = reactive(<FormRules>{
    name: [
      {
        required: true,
        trigger: "blur"
      }
    ],
    isActive: [
      {
        required: true,
        trigger: "blur"
      }
    ],
    adminEmailAddress: [
      {
        required: true,
        trigger: "blur"
      }
    ],
    adminPassword: [
      {
        required: true,
        trigger: "blur"
      }
    ],
    defaultConnectionString: [
      {
        required: true,
        trigger: "blur"
      }
    ]
  });
  return rules;
});
