using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(DDSS_IntroSkip.Properties.BuildInfo.Description)]
[assembly: AssemblyDescription(DDSS_IntroSkip.Properties.BuildInfo.Description)]
[assembly: AssemblyCompany(DDSS_IntroSkip.Properties.BuildInfo.Company)]
[assembly: AssemblyProduct(DDSS_IntroSkip.Properties.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + DDSS_IntroSkip.Properties.BuildInfo.Author)]
[assembly: AssemblyTrademark(DDSS_IntroSkip.Properties.BuildInfo.Company)]
[assembly: AssemblyVersion(DDSS_IntroSkip.Properties.BuildInfo.Version)]
[assembly: AssemblyFileVersion(DDSS_IntroSkip.Properties.BuildInfo.Version)]
[assembly: MelonInfo(typeof(DDSS_IntroSkip.MelonMain), 
    DDSS_IntroSkip.Properties.BuildInfo.Name, 
    DDSS_IntroSkip.Properties.BuildInfo.Version,
    DDSS_IntroSkip.Properties.BuildInfo.Author,
    DDSS_IntroSkip.Properties.BuildInfo.DownloadLink)]
[assembly: MelonGame("StripedPandaStudios", "DDSS")]
[assembly: MelonPriority(int.MinValue)]
[assembly: VerifyLoaderVersion("0.6.5", true)]
[assembly: HarmonyDontPatchAll]