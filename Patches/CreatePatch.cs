using GorillaTagScripts;
using HarmonyLib;
using UnityEngine;
using static LegallyStupid.Menu.Main;

namespace LegallyStupid.Patches
{
    [HarmonyPatch(typeof(BuilderTableNetworking), "PieceCreatedRPC")]
    public class CreatePatch
    {
        public static bool enabled = false;
        public static int pieceTypeSearch = 0;

        private static void Postfix(int pieceType, int pieceId)
        {
            if (enabled)
            {
                if (pieceTypeSearch == pieceType)
                {
                    LegallyStupid.Mods.Fun.pieceId = pieceId;
                    enabled = false;
                }
            }
        }
    }
}
