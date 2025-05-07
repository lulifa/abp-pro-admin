using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace RuiChen.Platform
{
    /// <summary>
    /// 用户菜单
    /// </summary>
    public class UserMenu : AuditedEntity<Guid>, IMultiTenant
    {
        public UserMenu()
        {

        }

        public UserMenu(
            Guid id,
            Guid menuId,
            Guid userId,
            Guid? tenantId = null)
            : base(id)
        {
            MenuId = menuId;
            UserId = userId;
            TenantId = tenantId;
        }

        public virtual Guid? TenantId { get; set; }

        public virtual Guid MenuId { get; set; }

        public virtual Guid UserId { get; set; }

        public virtual bool Startup { get; set; }
    }
}
