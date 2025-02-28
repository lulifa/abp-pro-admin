<script setup lang="ts">
import { ref } from "vue";
import ReCol from "@/components/ReCol";
import Segmented from "@/components/ReSegmented";
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
    label-width="118px"
  >
    <el-row :gutter="30">
      <re-col>
        <Segmented
          v-model="newFormInline.menuType"
          :options="props.formOther.menuTypeOptions"
          block
          class="!w-full"
        />
      </re-col>
      <template v-if="newFormInline.menuType === 0">
        <re-col>
          <el-form-item label="应用类型" prop="applicationType">
            <el-select
              v-model="newFormInline.applicationType"
              class="!w-full"
              placeholder="请选择"
            >
              <el-option
                v-for="item in newFormOther.applicationTypeOptions"
                :key="item.value"
                :label="item.text"
                :value="item.value"
              />
            </el-select>
          </el-form-item>
        </re-col>
        <re-col>
          <el-form-item label="客户端标识" prop="clientId">
            <el-input
              v-model="newFormInline.clientId"
              class="!w-full"
              clearable
              placeholder="请输入"
            />
          </el-form-item>
        </re-col>
        <re-col>
          <el-form-item label="客户端类型" prop="clientType">
            <el-select
              v-model="newFormInline.clientType"
              class="!w-full"
              placeholder="请选择"
            >
              <el-option
                v-for="item in newFormOther.clientTypeOptions"
                :key="item.value"
                :label="item.text"
                :value="item.value"
              />
            </el-select>
          </el-form-item>
        </re-col>
        <re-col>
          <el-form-item label="客户端Uri" prop="clientUri">
            <el-input
              v-model="newFormInline.clientUri"
              class="!w-full"
              clearable
              placeholder="请输入"
            />
          </el-form-item>
        </re-col>
        <re-col>
          <el-form-item label="客户端Logo" prop="logoUri">
            <el-input
              v-model="newFormInline.logoUri"
              class="!w-full"
              clearable
              placeholder="请输入"
            />
          </el-form-item>
        </re-col>
        <re-col>
          <el-form-item label="同意类型" prop="consentType">
            <el-select
              v-model="newFormInline.consentType"
              class="!w-full"
              placeholder="请选择"
            >
              <el-option
                v-for="item in newFormOther.consentTypeOptions"
                :key="item.value"
                :label="item.text"
                :value="item.value"
              />
            </el-select>
          </el-form-item>
        </re-col>
      </template>
    </el-row>
  </el-form>
</template>
