<script setup lang="ts">
import { ref } from "vue";
import { FormPropsConnection } from "./utils/types";

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
      class="mb-[20px] float-right"
      @click="newFormOther.addClick"
    >
      添加新连接
    </el-button>
    <pure-table
      :loading="newFormOther.loading"
      :data="newFormOther.dataList"
      :columns="newFormOther.columns"
      border
    >
      <template #operation="{ row }">
        <el-popconfirm
          :title="`是否确认删除连接字符串名称为${row.name}的这条数据`"
          @confirm="newFormOther.deleteClick(row)"
        >
          <template #reference>
            <el-button link type="primary" size="small"> 删除 </el-button>
          </template>
        </el-popconfirm>
      </template>
    </pure-table>
  </div>
</template>
