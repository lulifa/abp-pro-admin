<script setup lang="ts">
import { ref } from "vue";
import ReCol from "@/components/ReCol";
import { tenantRules } from "../utils/rule";
import { FormPropsTenant } from "../utils/types";

const props = withDefaults(defineProps<FormPropsTenant>(), {});

const ruleFormRef = ref();

const newFormInline = ref(props.formInline);

const newFormOther = ref(props.formOther);

function getRef() {
  return ruleFormRef.value;
}

defineExpose({ getRef });
</script>

<template>
  <el-form
    ref="ruleFormRef"
    :model="newFormInline"
    :rules="tenantRules"
    label-width="82px"
  >
    <el-row :gutter="30">
      <re-col>
        <el-form-item
          label="将名称字段留空以切换到主机端。"
          prop="name"
          label-position="top"
        >
          <el-input
            v-model="newFormInline.name"
            class="!w-full"
            clearable
            placeholder="请输入"
          />
        </el-form-item>
      </re-col>
    </el-row>
  </el-form>
</template>
