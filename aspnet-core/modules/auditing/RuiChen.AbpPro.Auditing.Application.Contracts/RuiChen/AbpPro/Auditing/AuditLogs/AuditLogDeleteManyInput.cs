using System.ComponentModel.DataAnnotations;

namespace RuiChen.AbpPro.Auditing
{
    public class AuditLogDeleteManyInput
    {
        [Required]
        public List<Guid> Ids { get; set; }
    }
}
