using System.ComponentModel.DataAnnotations;

namespace RuiChen.AbpPro.Auditing
{
    public class SecurityLogDeleteManyInput
    {
        [Required]
        public List<Guid> Ids { get; set; }
    }
}
