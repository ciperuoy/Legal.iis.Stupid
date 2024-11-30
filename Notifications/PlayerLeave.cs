using HarmonyLib;
using LegallyStupid.Notifications;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine;
using static LegallyStupid.Menu.Main;

namespace LegallyStupid.Patches
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerLeftRoom")]
    public class LeavePatch
    {
        private static void Prefix(Player otherPlayer)
        {
            if (otherPlayer != PhotonNetwork.LocalPlayer && otherPlayer != a)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>LEAVE</color><color=grey>]</color> <color=white>Name: " + otherPlayer.NickName + "</color>");
                if (customSoundOnJoin)
                {
                    if (!Directory.Exists("iisStupidMenu"))
                    {
                        Directory.CreateDirectory("iisStupidMenu");
                    }
                    File.WriteAllText("iisStupidMenu/LegallyStupid_CustomSoundOnJoin.txt", "PlayerLeave");
                }
                a = otherPlayer;
            }
        }

        private static Player a;
    }
}