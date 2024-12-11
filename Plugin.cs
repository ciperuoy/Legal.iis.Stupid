using BepInEx;
using LegallyStupid.Classes;
using LegallyStupid.Menu;
using LegallyStupid.Mods;
using LegallyStupid.Notifications;
using Photon.Pun;
using System;
using System.ComponentModel;
using UnityEngine;
using static LegallyStupid.Menu.Main;

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
        }
        void OnModdedJoined()
        {

        }
        void OnModdedLeft()
        {
            foreach (ButtonInfo[] buttonlist in Buttons.buttons)
            {
                foreach (ButtonInfo v in buttonlist)
                {
                    if (v.enabled)
                    {
                        Toggle(v.buttonText);
                    }
                }
            }
            NotifiLib.ClearAllNotifications(); // Code from "Panic" lmfao
        }
    }
}
