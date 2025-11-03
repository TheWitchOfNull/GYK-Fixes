using HarmonyLib;
using UnityEngine;

namespace NullFixes.Features;

public static class ThrottleLights
{
    private const float TARGET_HZ = 20f;
    private static float _lastUpdate = 0f;
    public static void Install()
    {
        Log.Info("Installing feature: throttle lights");
        var h = Plugin.HarmonyInstance;
        var og = AccessTools.Method(typeof(DynamicLights), nameof(DynamicLights.Update));
        var pf = new HarmonyMethod(typeof(ThrottleLights).GetMethod(nameof(DynamicLights_Update_Prefix)));
        h.Patch(og, prefix: pf);
    }

    public static bool DynamicLights_Update_Prefix()
    {
        if (Time.realtimeSinceStartup - _lastUpdate < (1f / TARGET_HZ)) return false;
        _lastUpdate = Time.realtimeSinceStartup;
        return true;
    }
}