<script setup lang="ts">
import { ref } from "vue";
import { FormPropsConnection } from "./utils/types";
import { useRenderIcon } from "@/components/ReIcon/src/hooks";

import Delete from "@iconify-icons/ep/delete";
import AddFill from "@iconify-icons/ri/add-circle-line";

const props = withDefaults(defineProps<FormPropsConnection>(), {});

const ruleFormRef = ref();

const newFormInline = ref(props.formInline);

const newFormOther = ref(props.formOther);

function getRef() {
  return ruleFormRef.value;
}

defineExpose({ getRef });
</script>

<template>
  <div class="main">
    <el-button
      type="primary"
      :icon="useRenderIcon(AddFill)"
      class="mb-[20px] float-right"
      @click="newFormOther.addClick"
    >
      添加新连接
    </el-button>
    <pure-table
      ref="tableRef"
      align-whole="left"
      showOverflowTooltip
      table-layout="auto"
      :loading="newFormOther.loading"
      :data="newFormOther.dataList"
      :columns="newFormOther.columns"
      :header-cell-style="{
        background: 'var(--el-fill-color-light)',
        color: 'var(--el-text-color-primary)'
      }"
      border
    >
      <template #operation="{ row }">
        <el-popconfirm
          :title="`是否确认删除连接字符串名称为${row.name}的这条数据`"
          @confirm="newFormOther.deleteClick(row)"
        >
          <template #reference>
            <el-button
              class="reset-margin"
              link
              type="primary"
              :icon="useRenderIcon(Delete)"
            >
              删除
            </el-button>
          </template>
        </el-popconfirm>
      </template>
    </pure-table>
  </div>
</template>
