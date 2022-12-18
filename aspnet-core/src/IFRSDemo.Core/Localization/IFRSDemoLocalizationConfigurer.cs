using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace IFRSDemo.Localization
{
    public static class IFRSDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    IFRSDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(IFRSDemoLocalizationConfigurer).GetAssembly(),
                        "IFRSDemo.Localization.IFRSDemo"
                    )
                )
            );
        }
    }
}