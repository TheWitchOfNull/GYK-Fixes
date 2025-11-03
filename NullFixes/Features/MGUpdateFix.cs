using CodeStage.AdvancedFPSCounter;
using HarmonyLib;
using UnityEngine;
using static MainGame;

namespace NullFixes.Features;

public static class MGUpdateFix
{
    public static void Install()
    {
        Log.Info("Installing feature: main game update fix");
        var h = Plugin.HarmonyInstance;
        var og = AccessTools.Method(typeof(MainGame), nameof(MainGame.Update));
        var pf = new HarmonyMethod(typeof(MGUpdateFix).GetMethod(nameof(MainGame_Update_Prefix)));
        h.Patch(og, prefix: pf);
    }

    public static bool MainGame_Update_Prefix()
    {
        //removes dead code, doesn't reset vsync every frame D:
        if (MainGame.game_started)
        {
            MainGame.me.save.game_logics.Update();
            if (!paused)
            {
                BuffsLogics.RecalculateBuffs();
            }
            if (MainGame.me.game_mode == GameMode.Building)
            {
                MainGame.me.build_mode_logics.Update();
            }
        }
        if (GamePadController.cheat_combination_pressed)
        {
            Object.FindObjectOfType<AFPSCounter>().SwitchCounter();
        }
        return false;
    }
}