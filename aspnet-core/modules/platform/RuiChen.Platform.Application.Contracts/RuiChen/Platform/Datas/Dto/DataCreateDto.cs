using System.ComponentModel;

namespace RuiChen.Platform
{
    public class DataCreateDto : DataCreateOrUpdateDto
    {
        [DisplayName("DisplayName:ParentData")]
        public Guid? ParentId { get; set; }
    }
}
