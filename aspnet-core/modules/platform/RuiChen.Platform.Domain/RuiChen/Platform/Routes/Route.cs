using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace RuiChen.Platform
{
    /// <summary>
    /// 不管是布局还是视图或者页面，都作为路由的实现，因此抽象一个路由实体<br/> 
    /// 注意:这是基于 Vue Router 的路由规则设计的实体,详情:https://router.vuejs.org/zh/api/#routes
    /// </summary>
    public abstract class Route : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        protected Route()
        {

        }

        protected Route(
            Guid id,
            string path,
            string name,
            string displayName,
            string redirect = "",
            string description = "",
            Guid? tenantId = null)
        {
            Check.NotNullOrWhiteSpace(path, nameof(path));
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(displayName, nameof(displayName));

            Path = path;
            Name = name;
            DisplayName = displayName;
            Redirect = redirect;
            Description = description;
            TenantId = tenantId;
        }

        public virtual Guid? TenantId { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public virtual string Path { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public virtual string DisplayName { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 重定向路径
        /// </summary>
        public virtual string Redirect { get; set; }

    }
}
