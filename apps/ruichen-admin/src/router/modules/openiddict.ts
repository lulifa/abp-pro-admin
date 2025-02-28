export default {
  path: "/openiddict",
  redirect: "/openiddict/application/index",
  meta: {
    icon: "ri:settings-3-line",
    title: "Openiddict",
    rank: 2
  },
  children: [
    {
      path: "/openiddict/application/index",
      name: "OpeniddictApplication",
      component: () => import("@/views/openiddict/application/index.vue"),
      meta: {
        icon: "ep:histogram",
        extraIcon: "IF-pure-iconfont-new svg",
        title: "应用管理",
        showParent: true,
        roles: ["admin"]
      }
    },
    {
      path: "/openiddict/authorization/index",
      name: "OpeniddictAuthorization",
      component: () => import("@/views/openiddict/authorization/index.vue"),
      meta: {
        icon: "ri:ubuntu-fill",
        extraIcon: "IF-pure-iconfont-new svg",
        title: "授权管理",
        showParent: true,
        roles: ["admin"]
      }
    },
    {
      path: "/openiddict/scope/index",
      name: "OpeniddictScope",
      component: () => import("@/views/openiddict/scope/index.vue"),
      meta: {
        icon: "ri:tools-fill",
        extraIcon: "IF-pure-iconfont-new svg",
        title: "范围管理",
        showParent: true,
        roles: ["admin"]
      }
    },
    {
      path: "/openiddict/token/index",
      name: "OpeniddictToken",
      component: () => import("@/views/openiddict/token/index.vue"),
      meta: {
        icon: "ep:lollipop",
        extraIcon: "IF-pure-iconfont-new svg",
        title: "令牌管理",
        showParent: true,
        roles: ["admin"]
      }
    }
  ]
} satisfies RouteConfigsTable;
