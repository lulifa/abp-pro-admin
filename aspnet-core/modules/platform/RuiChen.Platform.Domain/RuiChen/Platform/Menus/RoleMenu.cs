using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace RuiChen.Platform
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    public class RoleMenu : AuditedEntity<Guid>, IMultiTenant
    {
        public RoleMenu()
        {

        }

        public RoleMenu(
            Guid id,
            Guid menuId,
            string roleName,
            Guid? tenantId = null)
            : base(id)
        {
            MenuId = menuId;
            RoleName = roleName;
            TenantId = tenantId;
        }

        public virtual Guid? TenantId { get; set; }

        public virtual Guid MenuId { get; set; }

        public virtual string RoleName { get; set; }

        public virtual bool Startup { get; set; }
    }
}
