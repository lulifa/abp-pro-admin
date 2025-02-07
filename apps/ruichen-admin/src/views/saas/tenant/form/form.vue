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
    label-width="82px"
  >
    <el-row :gutter="30">
      <re-col v-if="!newFormInline.id">
        <Segmented
          v-model="newFormInline.menuType"
          :options="props.formOther.menuTypeOptions"
          block
          class="!w-full"
        />
      </re-col>
      <template v-if="newFormInline.menuType === 0">
        <re-col>
          <el-form-item label="激活状态" prop="isActive" label-position="top">
            <el-select
              v-model="newFormInline.isActive"
              class="!w-full"
              placeholder="请选择"
            >
              <el-option
                v-for="item in newFormOther.activeOptions"
                :key="item.value"
                :label="item.text"
                :value="item.value"
              />
            </el-select>
          </el-form-item>
        </re-col>
        <re-col>
          <el-form-item label="租户名称" prop="name" label-position="top">
            <el-input
              v-model="newFormInline.name"
              class="!w-full"
              clearable
              placeholder="请输入"
            />
          </el-form-item>
        </re-col>
        <re-col>
          <el-form-item label="版本名称" prop="editionId" label-position="top">
            <el-select
              v-model="newFormInline.editionId"
              class="!w-full"
              placeholder="请选择"
              clearable
            >
              <el-option
                v-for="item in newFormOther.editionOptions"
                :key="item.id"
                :label="item.displayName"
                :value="item.id"
              />
            </el-select>
          </el-form-item>
        </re-col>
        <re-col>
          <el-form-item label="启用时间" prop="enableTime" label-position="top">
            <el-date-picker
              v-model="newFormInline.enableTime"
              class="!w-full"
              type="date"
              placeholder="请选择"
              value-format="YYYY-MM-DD"
              :shortcuts="newFormOther.shortcutsOptions"
            />
          </el-form-item>
        </re-col>
        <re-col>
          <el-form-item
            label="禁用时间"
            prop="disableTime"
            label-position="top"
          >
            <el-date-picker
              v-model="newFormInline.disableTime"
              class="!w-full"
              type="date"
              placeholder="请选择"
              value-format="YYYY-MM-DD"
              :shortcuts="newFormOther.shortcutsOptions"
            />
          </el-form-item>
        </re-col>
        <re-col v-if="!newFormInline.id">
          <el-form-item
            label="管理员电子邮件地址"
            prop="adminEmailAddress"
            label-position="top"
          >
            <el-input
              v-model="newFormInline.adminEmailAddress"
              class="!w-full"
              clearable
              placeholder="请输入"
            />
          </el-form-item>
        </re-col>
        <re-col v-if="!newFormInline.id">
          <el-form-item
            label="管理员密码"
            prop="adminPassword"
            label-position="top"
          >
            <el-input
              v-model="newFormInline.adminPassword"
              class="!w-full"
              clearable
              show-password
              placeholder="请输入"
            />
          </el-form-item>
        </re-col>
      </template>
      <template v-if="newFormInline.menuType === 1">
        <re-col>
          <el-form-item label="" prop="useSharedDatabase" label-position="top">
            <el-checkbox
              v-model="newFormInline.useSharedDatabase"
              size="large"
              label="使用共享数据库"
            />
          </el-form-item>
        </re-col>
        <re-col v-show="!newFormInline.useSharedDatabase">
          <el-form-item
            label="默认连接字符串"
            prop="defaultConnectionString"
            label-position="top"
          >
            <el-input
              v-model="newFormInline.defaultConnectionString"
              class="!w-full"
              clearable
              placeholder="请输入"
            />
          </el-form-item>
        </re-col>
      </template>
    </el-row>
  </el-form>
</template>
