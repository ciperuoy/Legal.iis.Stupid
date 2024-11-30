using HarmonyLib;
using GorillaLocomotion;
using static LegallyStupid.Menu.Main;

namespace LegallyStupid.Patches
{
    [HarmonyPatch(typeof(Player), "GetSlidePercentage")]
    public class SlidePatch
    {
        private static void Postfix(Player __instance, ref float __result)
        {
            try
            {
                if (EverythingSlippery == true)
                {
                    __result = 1;
                }

                if (EverythingGrippy == true)
                {
                    __result = 0;
                }
            }
            catch { }
        }
    }
}