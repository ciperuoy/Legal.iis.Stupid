using BepInEx;
using Photon.Pun;
using System;
using System.ComponentModel;
using UnityEngine;

namespace LegallyStupid
{
    [Description(PluginInfo.Description)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private void Start()
        {
            Console.Title = "Legally Stupid Menu /~/ Build " + PluginInfo.Version;

            Patches.Menu.ApplyHarmonyPatches();
            GameObject Loading = new GameObject();
            Loading.AddComponent<UI.Main>();
            Loading.AddComponent<Notifications.NotifiLib>();
            Loading.AddComponent<Classes.CoroutineManager>();
            DontDestroyOnLoad(Loading);
            GorillaTagger.OnPlayerSpawned(OnGameInitialized);
        }
        void OnGameInitialized()
        {

        }
        private void Update()
        {
            if (!PhotonNetwork.InRoom) OnModdedJoined();
            else if (!NetworkSystem.Instance.GameModeString.Contains("MODDED")) OnModdedLeft();
            GorillaTagger.OnPlayerSpawned(OnGameInitialized);
        }
        void OnModdedJoined() { }
        void OnModdedLeft() { }
    }
}
