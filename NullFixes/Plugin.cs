using BepInEx;
using NullFixes.Features;

namespace NullFixes;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static HarmonyLib.Harmony HarmonyInstance;
    public void Awake()
    {
        Log.Initialize(Logger);
        Log.Info($"NullFixes here. Put me in, coach.");
        HarmonyInstance = new("NullFixes");

        InstallFeatures();
    }

    private void InstallFeatures()
    {
        ThrottleLights.Install();
        MGUpdateFix.Install();
    }
}
