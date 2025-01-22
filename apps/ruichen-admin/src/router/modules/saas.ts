export default {
  path: "/saas",
  redirect: "/saas/tenant/index",
  meta: {
    icon: "ri:settings-3-line",
    title: "Saas",
    rank: 1
  },
  children: [
    {
      path: "/saas/tenant/index",
      name: "SaasTenant",
      component: () => import("@/views/saas/tenant/index.vue"),
      meta: {
        icon: "ep:menu",
        extraIcon: "IF-pure-iconfont-new svg",
        title: "租户管理",
        showParent: true,
        roles: ["admin"]
      }
    },
    {
      path: "/saas/edition/index",
      name: "SaasEdition",
      component: () => import("@/views/saas/edition/index.vue"),
      meta: {
        icon: "ep:menu",
        extraIcon: "IF-pure-iconfont-new svg",
        title: "版本管理",
        showParent: true,
        roles: ["admin"]
      }
    }
  ]
} satisfies RouteConfigsTable;
