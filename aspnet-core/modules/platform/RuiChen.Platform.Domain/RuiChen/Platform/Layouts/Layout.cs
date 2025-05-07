using JetBrains.Annotations;

namespace RuiChen.Platform
{
    /// <summary>
    /// 布局视图实体
    /// </summary>
    public class Layout : Route
    {
        /// <summary>
        /// 框架
        /// </summary>
        public virtual string Framework { get; protected set; }
        /// <summary>
        /// 约定的Meta采用哪种数据字典,主要是约束路由必须字段的一致性
        /// </summary>
        public virtual Guid DataId { get; protected set; }

        protected Layout() { }

        public Layout(
            Guid id,
            string path,
            string name,
            string displayName,
            Guid dataId,
            string framework,
            string redirect = "",
            string description = "",
            Guid? tenantId = null)
            : base(id, path, name, displayName, redirect, description, tenantId)
        {
            DataId = dataId;
            Framework = framework;
        }
    }
}
