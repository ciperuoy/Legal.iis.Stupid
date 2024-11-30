using HarmonyLib;
using LegallyStupid.Mods;
using System;
using UnityEngine;
using static LegallyStupid.Menu.Main;

namespace LegallyStupid.Patches
{
    [HarmonyPatch(typeof(SnowballThrowable), "GetRandomModelIndex")]
    public class SnowballPatch
    {
        public static bool enabled = false;
        public static int minusIndex = 1;
        private static bool Prefix(SnowballThrowable __instance, ref int __result)
        {
            if (enabled)
            {
                if (!__instance.randomModelSelection)
                {
                    return false;
                }
                if (__instance.localModels.Count == 0)
                {
                    __result = -1;
                    return false;
                }
                __result = __instance.localModels.Count - minusIndex;
                Traverse.Create(__instance).Field("randModelIndex").SetValue(__instance.localModels.Count - minusIndex);
                return false;
            }
            return true;
        }
    }
}
