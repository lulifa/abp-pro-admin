<script setup lang="ts">
import { ref } from "vue";
import ReCol from "@/components/ReCol";
import { formRules } from "../utils/rule";
import { FormProps } from "../utils/types";

const props = withDefaults(defineProps<FormProps>(), {});

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
    :rules="formRules"
    label-width="82px"
  >
    <el-row :gutter="30">
      <re-col>
        <el-form-item label="版本名称" prop="displayName">
          <el-input
            v-model="newFormInline.displayName"
            class="!w-full"
            clearable
            placeholder="请输入"
          />
        </el-form-item>
      </re-col>
    </el-row>
  </el-form>
</template>
