using Volo.Abp.Application.Dtos;

namespace RuiChen.Platform
{
    public class GetDataListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
