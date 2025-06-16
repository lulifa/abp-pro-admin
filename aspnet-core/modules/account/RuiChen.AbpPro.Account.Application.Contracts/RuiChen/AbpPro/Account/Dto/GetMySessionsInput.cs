using Volo.Abp.Application.Dtos;

namespace RuiChen.AbpPro.Account
{
    public class GetMySessionsInput : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 设备
        /// </summary>
        public string Device { get; set; }
        /// <summary>
        /// 客户端id
        /// </summary>
        public string ClientId { get; set; }
    }
}
