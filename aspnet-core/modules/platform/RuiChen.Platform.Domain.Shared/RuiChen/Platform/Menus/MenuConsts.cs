namespace RuiChen.Platform
{
    public static class MenuConsts
    {
        public static int MaxComponentLength { get; set; } = 256;

        /// <summary>
        /// 最大深度
        /// 默认为4,仅支持四级子菜单
        /// </summary>
        public const int MaxDepth = 4;

        public const int MaxCodeLength = MaxDepth * (PlatformConsts.CodeUnitLength + 1) - 1;

    }
}
