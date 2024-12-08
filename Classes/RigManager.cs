using BepInEx;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace LegallyStupid.Classes
{
    public class RigManager
    {
        public static VRRig GetVRRigFromPlayer(NetPlayer p)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(p);
        }
    }
}
