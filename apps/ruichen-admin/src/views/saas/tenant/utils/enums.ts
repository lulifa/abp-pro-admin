import type { OptionsType } from "@/components/ReSegmented";

export const menuTypeOptions: Array<OptionsType> = [
  {
    label: "基本信息",
    icon: "ri:admin-line",
    value: 0
  },
  {
    label: "连接字符串",
    icon: "ri:admin-fill",
    value: 1
  }
];

export const activeOptions: Array<NameValue> = [
  {
    text: "活跃",
    value: true
  },
  {
    text: "不活跃",
    value: false
  }
];

export const shortcutsOptions: Array<NameValue> = [
  {
    text: "一年前",
    value: () => {
      const date = new Date();
      date.setFullYear(date.getFullYear() - 1);
      return date;
    }
  },
  {
    text: "半年前",
    value: () => {
      const date = new Date();
      date.setMonth(date.getMonth() - 6);
      return date;
    }
  },
  {
    text: "三个月前",
    value: () => {
      const date = new Date();
      date.setMonth(date.getMonth() - 3);
      return date;
    }
  },
  {
    text: "一个月前",
    value: () => {
      const date = new Date();
      date.setMonth(date.getMonth() - 1);
      return date;
    }
  },
  {
    text: "一周前",
    value: () => {
      const date = new Date();
      date.setTime(date.getTime() - 3600 * 1000 * 24 * 7);
      return date;
    }
  },
  {
    text: "今天",
    value: new Date()
  },
  {
    text: "一周后",
    value: () => {
      const date = new Date();
      date.setTime(date.getTime() + 3600 * 1000 * 24 * 7);
      return date;
    }
  },
  {
    text: "一个月后",
    value: () => {
      const date = new Date();
      date.setMonth(date.getMonth() + 1);
      return date;
    }
  },
  {
    text: "三个月后",
    value: () => {
      const date = new Date();
      date.setMonth(date.getMonth() + 3);
      return date;
    }
  },
  {
    text: "半年后",
    value: () => {
      const date = new Date();
      date.setMonth(date.getMonth() + 6);
      return date;
    }
  },
  {
    text: "一年后",
    value: () => {
      const date = new Date();
      date.setFullYear(date.getFullYear() + 1);
      return date;
    }
  }
];
