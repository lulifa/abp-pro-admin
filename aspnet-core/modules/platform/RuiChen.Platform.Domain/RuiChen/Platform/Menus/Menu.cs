using Volo.Abp;

namespace RuiChen.Platform
{
    public class Menu : Route
    {
        public Menu()
        {

        }

        public Menu(
            Guid id,
            Guid layoutId,
            string path,
            string name,
            string code,
            string component,
            string displayName,
            string framework,
            string redirect = "",
            string description = "",
            Guid? parentId = null,
            Guid? tenantId = null)
            : base(id, path, name, displayName, redirect, description, tenantId)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));

            LayoutId = layoutId;
            Code = code;
            Component = component;// 下属的一级菜单的Component应该是布局页, 例如vue-admin中的 component: Layout, 其他前端框架雷同, 此处应传递布局页的路径让前端import
            Framework = framework;
            ParentId = parentId;

            IsPublic = false;
        }

        /// <summary>
        /// 框架
        /// </summary>
        public virtual string Framework { get; set; }
        /// <summary>
        /// 菜单编号
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 菜单布局页,Layout的路径
        /// </summary>
        public virtual string Component { get; set; }
        /// <summary>
        /// 所属的父菜单
        /// </summary>
        public virtual Guid? ParentId { get; set; }
        /// <summary>
        /// 所属布局标识
        /// </summary>
        public virtual Guid LayoutId { get; set; }
        /// <summary>
        /// 公共菜单
        /// </summary>
        public virtual bool IsPublic { get; set; }

    }
}
