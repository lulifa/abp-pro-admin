<script setup lang="ts">
import { ref } from "vue";
import ReCol from "@/components/ReCol";
import { formRules } from "../utils/rule";
import { FormPropsConnectionAdd } from "../utils/types";

const props = withDefaults(defineProps<FormPropsConnectionAdd>(), {});

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
        <el-form-item label="名称" prop="name">
          <el-input
            v-model="newFormInline.name"
            class="!w-full"
            clearable
            placeholder="请输入"
          />
        </el-form-item>
      </re-col>
      <re-col>
        <el-form-item label="值" prop="value">
          <el-input
            v-model="newFormInline.value"
            class="!w-full"
            clearable
            placeholder="请输入"
          />
        </el-form-item>
      </re-col>
    </el-row>
  </el-form>
</template>
