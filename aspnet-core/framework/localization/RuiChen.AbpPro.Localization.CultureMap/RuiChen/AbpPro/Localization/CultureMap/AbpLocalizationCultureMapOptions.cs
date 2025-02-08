namespace RuiChen.AbpPro.Localization
{
    public class AbpLocalizationCultureMapOptions
    {

        public List<CultureMapInfo> CulturesMaps { get; }

        public List<CultureMapInfo> UiCulturesMaps { get; }

        public AbpLocalizationCultureMapOptions()
        {
            CulturesMaps = new List<CultureMapInfo>();
            UiCulturesMaps = new List<CultureMapInfo>();
        }

    }
}
