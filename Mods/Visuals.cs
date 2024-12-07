using GorillaExtensions;
using GorillaNetworking;
using LegallyStupid.Classes;
using LegallyStupid.Notifications;
using Pathfinding.RVO;
using Photon.Pun;
using Photon.Voice.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static LegallyStupid.Menu.Main;

namespace LegallyStupid.Mods
{
    public class Visuals
    {
       
      
        /*public static void EnableRemoveLeaves()
        {
            foreach (GameObject g in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (g.activeSelf && g.name.Contains("smallleaves"))
                {
                    g.SetActive(false);
                    leaves.Add(g);
                }
            }
        }

        public static void DisableRemoveLeaves()
        {
            foreach (GameObject l in leaves)
            {
                l.SetActive(true);
            }
            leaves.Clear();
        }*/
        public static List<GameObject> leaves = new List<GameObject> { };
        public static void EnableRemoveLeaves()
        {
            foreach (GameObject g in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (g.activeSelf && (g.name.Contains("leaves_green") || g.name.Contains("fallleaves")))
                {
                    g.SetActive(false);
                    leaves.Add(g);
                }
            }
        }

        public static void DisableRemoveLeaves()
        {
            foreach (GameObject l in leaves)
            {
                l.SetActive(true);
            }
            leaves.Clear();
        }

        /*
        public static void EnableRemoveCherryBlossoms()
        {
            foreach (GameObject g in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (g.activeSelf && g.name.Contains("Cherry Blossoms"))
                {
                    g.SetActive(false);
                    cblos.Add(g);
                }
            }
        }

        public static void DisableRemoveCherryBlossoms()
        {
            foreach (GameObject l in cblos)
            {
                l.SetActive(true);
            }
            cblos.Clear();
        }*/

      
        public static void CasualTracers()
        {
            float lineWidth = GetIndex("Thin Tracers").enabled ? 0.0075f : 0.025f;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject line = new GameObject("Line");
                    if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                    LineRenderer liner = line.AddComponent<LineRenderer>();
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = lineWidth; liner.endWidth = lineWidth; liner.positionCount = 2; liner.useWorldSpace = true;
                    liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                    liner.SetPosition(1, vrrig.transform.position);
                    liner.material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(line, Time.deltaTime);
                }
            }
        }

        public static void InfectionTracers()
        {
            float lineWidth = GetIndex("Thin Tracers").enabled ? 0.0075f : 0.025f;
            bool isInfectedPlayers = false;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (PlayerIsTagged(vrrig))
                {
                    isInfectedPlayers = true;
                    break;
                }
            }
            if (isInfectedPlayers)
            {
                if (!PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            GameObject line = new GameObject("Line");
                            if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                            LineRenderer liner = line.AddComponent<LineRenderer>();
                            UnityEngine.Color thecolor = new Color32(255, 111, 0, 255);
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                            liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = lineWidth; liner.endWidth = lineWidth; liner.positionCount = 2; liner.useWorldSpace = true;
                            liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                            liner.SetPosition(1, vrrig.transform.position);
                            liner.material.shader = Shader.Find("GUI/Text Shader");
                            UnityEngine.Object.Destroy(line, Time.deltaTime);
                        }
                    }
                }
                else
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            GameObject line = new GameObject("Line");
                            if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                            LineRenderer liner = line.AddComponent<LineRenderer>();
                            UnityEngine.Color thecolor = vrrig.playerColor;
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                            liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = lineWidth; liner.endWidth = lineWidth; liner.positionCount = 2; liner.useWorldSpace = true;
                            liner.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                            liner.SetPosition(1, vrrig.transform.position);
                            liner.material.shader = Shader.Find("GUI/Text Shader");
                            UnityEngine.Object.Destroy(line, Time.deltaTime);
                        }
                    }
                }
            }
            else
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject line = new GameObject("Line");
                        if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                        LineRenderer liner = line.AddComponent<LineRenderer>();
                        UnityEngine.Color thecolor = vrrig.playerColor;
                        if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                        if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                        liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = lineWidth; liner.endWidth = lineWidth; liner.positionCount = 2; liner.useWorldSpace = true;
                        liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                        liner.SetPosition(1, vrrig.transform.position);
                        liner.material.shader = Shader.Find("GUI/Text Shader");
                        UnityEngine.Object.Destroy(line, Time.deltaTime);
                    }
                }
            }
        }

        public static void HuntTracers()
        {
            float lineWidth = GetIndex("Thin Tracers").enabled ? 0.0075f : 0.025f;
            GorillaHuntManager sillyComputer = GorillaGameManager.instance.gameObject.GetComponent<GorillaHuntManager>();
            NetPlayer target = sillyComputer.GetTargetOf(PhotonNetwork.LocalPlayer);
            foreach (NetPlayer player in PhotonNetwork.PlayerList)
            {
                VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                if (player == target)
                {
                    GameObject line = new GameObject("Line");
                    if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                    LineRenderer liner = line.AddComponent<LineRenderer>();
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = lineWidth; liner.endWidth = lineWidth; liner.positionCount = 2; liner.useWorldSpace = true;
                    liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                    liner.SetPosition(1, vrrig.transform.position);
                    liner.material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(line, Time.deltaTime);
                }
                if (sillyComputer.GetTargetOf(player) == (NetPlayer)PhotonNetwork.LocalPlayer)
                {
                    GameObject line = new GameObject("Line");
                    if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                    LineRenderer liner = line.AddComponent<LineRenderer>();
                    UnityEngine.Color thecolor = Color.red;
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = lineWidth; liner.endWidth = lineWidth; liner.positionCount = 2; liner.useWorldSpace = true;
                    liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                    liner.SetPosition(1, vrrig.transform.position);
                    liner.material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(line, Time.deltaTime);
                }
            }
        }

        public static void CasualBoneESP()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                UnityEngine.Color thecolor = vrrig.playerColor;
                if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    LineRenderer liner = vrrig.head.rigTarget.gameObject.GetOrAddComponent<LineRenderer>();
                    if (GetIndex("Hidden on Camera").enabled) { liner.gameObject.layer = 19; }
                    liner.startWidth = 0.025f;
                    liner.endWidth = 0.025f;

                    liner.startColor = thecolor;
                    liner.endColor = thecolor;

                    liner.material.shader = Shader.Find("GUI/Text Shader");

                    liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                    liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                    UnityEngine.Object.Destroy(liner, Time.deltaTime);
                    for (int i = 0; i < bones.Count<int>(); i += 2)
                    {
                        liner = vrrig.mainSkin.bones[bones[i]].gameObject.GetOrAddComponent<LineRenderer>();

                        liner.startWidth = 0.025f;
                        liner.endWidth = 0.025f;

                        liner.startColor = thecolor;
                        liner.endColor = thecolor;

                        liner.material.shader = Shader.Find("GUI/Text Shader");

                        liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                        liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                        UnityEngine.Object.Destroy(liner, Time.deltaTime);
                    }
                }
            }
        }

        public static void InfectionBoneESP()
        {
            bool isInfectedPlayers = false;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (PlayerIsTagged(vrrig))
                {
                    isInfectedPlayers = true;
                    break;
                }
            }
            if (isInfectedPlayers)
            {
                if (!PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        UnityEngine.Color thecolor = new Color32(255, 111, 0, 255);
                        if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                        if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                        if (PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            LineRenderer liner = vrrig.head.rigTarget.gameObject.GetOrAddComponent<LineRenderer>();
                            if (GetIndex("Hidden on Camera").enabled) { liner.gameObject.layer = 19; }
                            liner.startWidth = 0.025f;
                            liner.endWidth = 0.025f;

                            liner.startColor = thecolor;
                            liner.endColor = thecolor;

                            liner.material.shader = Shader.Find("GUI/Text Shader");

                            liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                            liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                            UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            for (int i = 0; i < bones.Count<int>(); i += 2)
                            {
                                liner = vrrig.mainSkin.bones[bones[i]].gameObject.GetOrAddComponent<LineRenderer>();

                                liner.startWidth = 0.025f;
                                liner.endWidth = 0.025f;

                                liner.startColor = thecolor;
                                liner.endColor = thecolor;

                                liner.material.shader = Shader.Find("GUI/Text Shader");

                                liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                                liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                                UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            }
                        }
                    }
                }
                else
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        UnityEngine.Color thecolor = vrrig.playerColor;
                        if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                        if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                        if (!PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            LineRenderer liner = vrrig.head.rigTarget.gameObject.GetOrAddComponent<LineRenderer>();
                            if (GetIndex("Hidden on Camera").enabled) { liner.gameObject.layer = 19; }
                            liner.startWidth = 0.025f;
                            liner.endWidth = 0.025f;

                            liner.startColor = thecolor;
                            liner.endColor = thecolor;

                            liner.material.shader = Shader.Find("GUI/Text Shader");

                            liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                            liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                            UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            for (int i = 0; i < bones.Count<int>(); i += 2)
                            {
                                liner = vrrig.mainSkin.bones[bones[i]].gameObject.GetOrAddComponent<LineRenderer>();

                                liner.startWidth = 0.025f;
                                liner.endWidth = 0.025f;

                                liner.startColor = thecolor;
                                liner.endColor = thecolor;

                                liner.material.shader = Shader.Find("GUI/Text Shader");

                                liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                                liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                                UnityEngine.Object.Destroy(liner, Time.deltaTime);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        LineRenderer liner = vrrig.head.rigTarget.gameObject.GetOrAddComponent<LineRenderer>();
                        if (GetIndex("Hidden on Camera").enabled) { liner.gameObject.layer = 19; }
                        liner.startWidth = 0.025f;
                        liner.endWidth = 0.025f;

                        liner.startColor = thecolor;
                        liner.endColor = thecolor;

                        liner.material.shader = Shader.Find("GUI/Text Shader");

                        liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                        liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                        UnityEngine.Object.Destroy(liner, Time.deltaTime);
                        for (int i = 0; i < bones.Count<int>(); i += 2)
                        {
                            liner = vrrig.mainSkin.bones[bones[i]].gameObject.GetOrAddComponent<LineRenderer>();

                            liner.startWidth = 0.025f;
                            liner.endWidth = 0.025f;

                            liner.startColor = thecolor;
                            liner.endColor = thecolor;

                            liner.material.shader = Shader.Find("GUI/Text Shader");

                            liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                            liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                            UnityEngine.Object.Destroy(liner, Time.deltaTime);
                        }
                    }
                }
            }
        }

        public static void HuntBoneESP()
        {
            GorillaHuntManager sillyComputer = GorillaGameManager.instance.gameObject.GetOrAddComponent<GorillaHuntManager>();
            NetPlayer target = sillyComputer.GetTargetOf(PhotonNetwork.LocalPlayer);
            foreach (NetPlayer player in PhotonNetwork.PlayerList)
            {
                VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                if (player == target)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    LineRenderer liner = vrrig.head.rigTarget.gameObject.GetOrAddComponent<LineRenderer>();
                    if (GetIndex("Hidden on Camera").enabled) { liner.gameObject.layer = 19; }
                    liner.startWidth = 0.025f;
                    liner.endWidth = 0.025f;

                    liner.startColor = thecolor;
                    liner.endColor = thecolor;

                    liner.material.shader = Shader.Find("GUI/Text Shader");

                    liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                    liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                    UnityEngine.Object.Destroy(liner, Time.deltaTime);
                    for (int i = 0; i < bones.Count<int>(); i += 2)
                    {
                        liner = vrrig.mainSkin.bones[bones[i]].gameObject.GetOrAddComponent<LineRenderer>();

                        liner.startWidth = 0.025f;
                        liner.endWidth = 0.025f;

                        liner.startColor = thecolor;
                        liner.endColor = thecolor;

                        liner.material.shader = Shader.Find("GUI/Text Shader");

                        liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                        liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                        UnityEngine.Object.Destroy(liner, Time.deltaTime);
                    }
                }
                if (sillyComputer.GetTargetOf(player) == (NetPlayer)PhotonNetwork.LocalPlayer)
                {
                    UnityEngine.Color thecolor = Color.red;
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    LineRenderer liner = vrrig.head.rigTarget.gameObject.GetOrAddComponent<LineRenderer>();
                    if (GetIndex("Hidden on Camera").enabled) { liner.gameObject.layer = 19; }
                    liner.startWidth = 0.025f;
                    liner.endWidth = 0.025f;

                    liner.startColor = thecolor;
                    liner.endColor = thecolor;

                    liner.material.shader = Shader.Find("GUI/Text Shader");

                    liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                    liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                    UnityEngine.Object.Destroy(liner, Time.deltaTime);
                    for (int i = 0; i < bones.Count<int>(); i += 2)
                    {
                        liner = vrrig.mainSkin.bones[bones[i]].gameObject.GetOrAddComponent<LineRenderer>();

                        liner.startWidth = 0.025f;
                        liner.endWidth = 0.025f;

                        liner.startColor = thecolor;
                        liner.endColor = thecolor;

                        liner.material.shader = Shader.Find("GUI/Text Shader");

                        liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                        liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);

                        UnityEngine.Object.Destroy(liner, Time.deltaTime);
                    }
                }
            }
        }

        public static void CasualChams()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    vrrig.mainSkin.material.color = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { vrrig.mainSkin.material.color = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { vrrig.mainSkin.material.color = new Color(vrrig.mainSkin.material.color.r, vrrig.mainSkin.material.color.g, vrrig.mainSkin.material.color.b, 0.5f); }
                }
            }
        }

        public static void InfectionChams()
        {
            bool isInfectedPlayers = false;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (PlayerIsTagged(vrrig))
                {
                    isInfectedPlayers = true;
                    break;
                }
            }
            if (isInfectedPlayers)
            {
                if (!PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = new Color32(255, 111, 0, 255);
                            if (GetIndex("Follow Menu Theme").enabled) { vrrig.mainSkin.material.color = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { vrrig.mainSkin.material.color = new Color(vrrig.mainSkin.material.color.r, vrrig.mainSkin.material.color.g, vrrig.mainSkin.material.color.b, 0.5f); }
                        }
                        else
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                        }
                    }
                }
                else
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                            vrrig.mainSkin.material.color = vrrig.playerColor;
                            if (GetIndex("Follow Menu Theme").enabled) { vrrig.mainSkin.material.color = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { vrrig.mainSkin.material.color = new Color(vrrig.mainSkin.material.color.r, vrrig.mainSkin.material.color.g, vrrig.mainSkin.material.color.b, 0.5f); }
                        }
                    }
                }
            }
            else
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                        vrrig.mainSkin.material.color = vrrig.playerColor;
                    }
                }
            }
        }

        public static void HuntChams()
        {
            GorillaHuntManager sillyComputer = GorillaGameManager.instance.gameObject.GetComponent<GorillaHuntManager>();
            NetPlayer target = sillyComputer.GetTargetOf(PhotonNetwork.LocalPlayer);
            foreach (NetPlayer player in PhotonNetwork.PlayerList)
            {
                VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                if (player == target)
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    vrrig.mainSkin.material.color = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { vrrig.mainSkin.material.color = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { vrrig.mainSkin.material.color = new Color(vrrig.mainSkin.material.color.r, vrrig.mainSkin.material.color.g, vrrig.mainSkin.material.color.b, 0.5f); }
                } else {
                    if (sillyComputer.GetTargetOf(player) == (NetPlayer)PhotonNetwork.LocalPlayer)
                    {
                        vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                        vrrig.mainSkin.material.color = Color.red;
                        if (GetIndex("Transparent Theme").enabled) { vrrig.mainSkin.material.color = new Color(vrrig.mainSkin.material.color.r, vrrig.mainSkin.material.color.g, vrrig.mainSkin.material.color.b, 0.5f); }
                    }
                    else
                    {
                        vrrig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                    }
                }
            }
        }

        public static void DisableChams()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                }
            }
        }

        public static void CasualBeacons()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    GameObject line = new GameObject("Line");
                    if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                    LineRenderer liner = line.AddComponent<LineRenderer>();
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { vrrig.mainSkin.material.color = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { vrrig.mainSkin.material.color = new Color(vrrig.mainSkin.material.color.r, vrrig.mainSkin.material.color.g, vrrig.mainSkin.material.color.b, 0.5f); }
                    liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                    liner.SetPosition(0, vrrig.transform.position + new Vector3(0f, 9999f, 0f));
                    liner.SetPosition(1, vrrig.transform.position - new Vector3(0f, 9999f, 0f));
                    liner.material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(line, Time.deltaTime);
                }
            }
        }

        public static void InfectionBeacons()
        {
            bool isInfectedPlayers = false;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (PlayerIsTagged(vrrig))
                {
                    isInfectedPlayers = true;
                    break;
                }
            }
            if (isInfectedPlayers)
            {
                if (!PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            GameObject line = new GameObject("Line");
                            if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                            LineRenderer liner = line.AddComponent<LineRenderer>();
                            UnityEngine.Color thecolor = new Color32(255, 111, 0, 255);
                            if (GetIndex("Follow Menu Theme").enabled) { vrrig.mainSkin.material.color = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { vrrig.mainSkin.material.color = new Color(vrrig.mainSkin.material.color.r, vrrig.mainSkin.material.color.g, vrrig.mainSkin.material.color.b, 0.5f); }
                            liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                            liner.SetPosition(0, vrrig.transform.position + new Vector3(0f, 9999f, 0f));
                            liner.SetPosition(1, vrrig.transform.position - new Vector3(0f, 9999f, 0f));
                            liner.material.shader = Shader.Find("GUI/Text Shader");
                            UnityEngine.Object.Destroy(line, Time.deltaTime);
                        }
                    }
                }
                else
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            GameObject line = new GameObject("Line");
                            if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                            LineRenderer liner = line.AddComponent<LineRenderer>();
                            UnityEngine.Color thecolor = vrrig.playerColor;
                            if (GetIndex("Follow Menu Theme").enabled) { vrrig.mainSkin.material.color = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { vrrig.mainSkin.material.color = new Color(vrrig.mainSkin.material.color.r, vrrig.mainSkin.material.color.g, vrrig.mainSkin.material.color.b, 0.5f); }
                            liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                            liner.SetPosition(0, vrrig.transform.position + new Vector3(0f, 9999f, 0f));
                            liner.SetPosition(1, vrrig.transform.position - new Vector3(0f, 9999f, 0f));
                            liner.material.shader = Shader.Find("GUI/Text Shader");
                            UnityEngine.Object.Destroy(line, Time.deltaTime);
                        }
                    }
                }
            }
            else
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject line = new GameObject("Line");
                        if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                        LineRenderer liner = line.AddComponent<LineRenderer>();
                        UnityEngine.Color thecolor = vrrig.playerColor;
                        if (GetIndex("Follow Menu Theme").enabled) { vrrig.mainSkin.material.color = GetBGColor(0f); }
                        if (GetIndex("Transparent Theme").enabled) { vrrig.mainSkin.material.color = new Color(vrrig.mainSkin.material.color.r, vrrig.mainSkin.material.color.g, vrrig.mainSkin.material.color.b, 0.5f); }
                        liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                        liner.SetPosition(0, vrrig.transform.position + new Vector3(0f, 9999f, 0f));
                        liner.SetPosition(1, vrrig.transform.position - new Vector3(0f, 9999f, 0f));
                        liner.material.shader = Shader.Find("GUI/Text Shader");
                        UnityEngine.Object.Destroy(line, Time.deltaTime);
                    }
                }
            }
        }

        public static void HuntBeacons()
        {
            GorillaHuntManager sillyComputer = GorillaGameManager.instance.gameObject.GetComponent<GorillaHuntManager>();
            NetPlayer target = sillyComputer.GetTargetOf(PhotonNetwork.LocalPlayer);
            foreach (NetPlayer player in PhotonNetwork.PlayerList)
            {
                VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                if (player == target)
                {
                    GameObject line = new GameObject("Line");
                    if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                    LineRenderer liner = line.AddComponent<LineRenderer>();
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { vrrig.mainSkin.material.color = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { vrrig.mainSkin.material.color = new Color(vrrig.mainSkin.material.color.r, vrrig.mainSkin.material.color.g, vrrig.mainSkin.material.color.b, 0.5f); }
                    liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                    liner.SetPosition(0, vrrig.transform.position + new Vector3(0f, 9999f, 0f));
                    liner.SetPosition(1, vrrig.transform.position - new Vector3(0f, 9999f, 0f));
                    liner.material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(line, Time.deltaTime);
                }
                if (sillyComputer.GetTargetOf(player) == (NetPlayer)PhotonNetwork.LocalPlayer)
                {
                    GameObject line = new GameObject("Line");
                    if (GetIndex("Hidden on Camera").enabled) { line.layer = 19; }
                    LineRenderer liner = line.AddComponent<LineRenderer>();
                    UnityEngine.Color thecolor = Color.red;
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                    liner.SetPosition(0, vrrig.transform.position + new Vector3(0f, 9999f, 0f));
                    liner.SetPosition(1, vrrig.transform.position - new Vector3(0f, 9999f, 0f));
                    liner.material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(line, Time.deltaTime);
                }
            }
        }

        public static void CasualBoxESP()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { box.layer = 19; }
                    box.transform.position = vrrig.transform.position;
                    UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                    box.transform.localScale = new Vector3(0.5f,0.5f,0f);
                    box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    box.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(box, Time.deltaTime);
                }
            }
        }

        public static void InfectionBoxESP()
        {
            bool isInfectedPlayers = false;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (PlayerIsTagged(vrrig))
                {
                    isInfectedPlayers = true;
                    break;
                }
            }
            if (isInfectedPlayers)
            {
                if (!PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            UnityEngine.Color thecolor = new Color32(255, 111, 0, 255);
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            if (GetIndex("Hidden on Camera").enabled) { box.layer = 19; }
                            box.transform.position = vrrig.transform.position;
                            UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                            box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                            box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                            box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            box.GetComponent<Renderer>().material.color = thecolor;
                            UnityEngine.Object.Destroy(box, Time.deltaTime);
                        }
                    }
                }
                else
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            UnityEngine.Color thecolor = vrrig.playerColor;
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            if (GetIndex("Hidden on Camera").enabled) { box.layer = 19; }
                            box.transform.position = vrrig.transform.position;
                            UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                            box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                            box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                            box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            box.GetComponent<Renderer>().material.color = thecolor;
                            UnityEngine.Object.Destroy(box, Time.deltaTime);
                        }
                    }
                }
            }
            else
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        UnityEngine.Color thecolor = vrrig.playerColor;
                        if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                        if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                        GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (GetIndex("Hidden on Camera").enabled) { box.layer = 19; }
                        box.transform.position = vrrig.transform.position;
                        UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                        box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                        box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                        box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        box.GetComponent<Renderer>().material.color = thecolor;
                        UnityEngine.Object.Destroy(box, Time.deltaTime);
                    }
                }
            }
        }

        public static void HuntBoxESP()
        {
            GorillaHuntManager sillyComputer = GorillaGameManager.instance.gameObject.GetComponent<GorillaHuntManager>();
            NetPlayer target = sillyComputer.GetTargetOf(PhotonNetwork.LocalPlayer);
            foreach (NetPlayer player in PhotonNetwork.PlayerList)
            {
                VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                if (player == target)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { box.layer = 19; }
                    box.transform.position = vrrig.transform.position;
                    UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                    box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                    box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    box.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(box, Time.deltaTime);
                }
                if (sillyComputer.GetTargetOf(player) == (NetPlayer)PhotonNetwork.LocalPlayer)
                {
                    UnityEngine.Color thecolor = Color.red;
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { box.layer = 19; }
                    box.transform.position = vrrig.transform.position;
                    UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                    box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                    box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    box.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(box, Time.deltaTime);
                }
            }
        }

        public static void CasualHollowBoxESP()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }

                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.position = vrrig.transform.position;
                    UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                    box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                    box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    box.GetComponent<Renderer>().enabled = false;

                    GameObject outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.up * 0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.5f, 0.05f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.up * -0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.55f, 0.05f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.right * 0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.right * -0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    UnityEngine.Object.Destroy(box);
                }
            }
        }

        public static void HollowInfectionBoxESP()
        {
            bool isInfectedPlayers = false;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (PlayerIsTagged(vrrig))
                {
                    isInfectedPlayers = true;
                    break;
                }
            }
            if (isInfectedPlayers)
            {
                if (!PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            UnityEngine.Color thecolor = new Color32(255, 111, 0, 255);
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }

                            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            box.transform.position = vrrig.transform.position;
                            UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                            box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                            box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                            box.GetComponent<Renderer>().enabled = false;

                            GameObject outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                            outl.transform.position = vrrig.transform.position + (box.transform.up * 0.25f);
                            UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                            outl.transform.localScale = new Vector3(0.5f, 0.05f, 0f);
                            outl.transform.rotation = box.transform.rotation;
                            outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            outl.GetComponent<Renderer>().material.color = thecolor;
                            UnityEngine.Object.Destroy(outl, Time.deltaTime);

                            outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                            outl.transform.position = vrrig.transform.position + (box.transform.up * -0.25f);
                            UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                            outl.transform.localScale = new Vector3(0.55f, 0.05f, 0f);
                            outl.transform.rotation = box.transform.rotation;
                            outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            outl.GetComponent<Renderer>().material.color = thecolor;
                            UnityEngine.Object.Destroy(outl, Time.deltaTime);

                            outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                            outl.transform.position = vrrig.transform.position + (box.transform.right * 0.25f);
                            UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                            outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                            outl.transform.rotation = box.transform.rotation;
                            outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            outl.GetComponent<Renderer>().material.color = thecolor;
                            UnityEngine.Object.Destroy(outl, Time.deltaTime);

                            outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                            outl.transform.position = vrrig.transform.position + (box.transform.right * -0.25f);
                            UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                            outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                            outl.transform.rotation = box.transform.rotation;
                            outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            outl.GetComponent<Renderer>().material.color = thecolor;
                            UnityEngine.Object.Destroy(outl, Time.deltaTime);

                            UnityEngine.Object.Destroy(box);
                        }
                    }
                }
                else
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            UnityEngine.Color thecolor = vrrig.playerColor;
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }

                            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            box.transform.position = vrrig.transform.position;
                            UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                            box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                            box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                            box.GetComponent<Renderer>().enabled = false;

                            GameObject outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                            outl.transform.position = vrrig.transform.position + (box.transform.up * 0.25f);
                            UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                            outl.transform.localScale = new Vector3(0.5f, 0.05f, 0f);
                            outl.transform.rotation = box.transform.rotation;
                            outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            outl.GetComponent<Renderer>().material.color = thecolor;
                            UnityEngine.Object.Destroy(outl, Time.deltaTime);

                            outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                            outl.transform.position = vrrig.transform.position + (box.transform.up * -0.25f);
                            UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                            outl.transform.localScale = new Vector3(0.55f, 0.05f, 0f);
                            outl.transform.rotation = box.transform.rotation;
                            outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            outl.GetComponent<Renderer>().material.color = thecolor;
                            UnityEngine.Object.Destroy(outl, Time.deltaTime);

                            outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                            outl.transform.position = vrrig.transform.position + (box.transform.right * 0.25f);
                            UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                            outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                            outl.transform.rotation = box.transform.rotation;
                            outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            outl.GetComponent<Renderer>().material.color = thecolor;
                            UnityEngine.Object.Destroy(outl, Time.deltaTime);

                            outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                            outl.transform.position = vrrig.transform.position + (box.transform.right * -0.25f);
                            UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                            outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                            outl.transform.rotation = box.transform.rotation;
                            outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            outl.GetComponent<Renderer>().material.color = thecolor;
                            UnityEngine.Object.Destroy(outl, Time.deltaTime);

                            UnityEngine.Object.Destroy(box);
                        }
                    }
                }
            }
            else
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        UnityEngine.Color thecolor = vrrig.playerColor;
                        if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                        if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }

                        GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        box.transform.position = vrrig.transform.position;
                        UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                        box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                        box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                        box.GetComponent<Renderer>().enabled = false;

                        GameObject outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                        outl.transform.position = vrrig.transform.position + (box.transform.up * 0.25f);
                        UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                        outl.transform.localScale = new Vector3(0.5f, 0.05f, 0f);
                        outl.transform.rotation = box.transform.rotation;
                        outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        outl.GetComponent<Renderer>().material.color = thecolor;
                        UnityEngine.Object.Destroy(outl, Time.deltaTime);

                        outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                        outl.transform.position = vrrig.transform.position + (box.transform.up * -0.25f);
                        UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                        outl.transform.localScale = new Vector3(0.55f, 0.05f, 0f);
                        outl.transform.rotation = box.transform.rotation;
                        outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        outl.GetComponent<Renderer>().material.color = thecolor;
                        UnityEngine.Object.Destroy(outl, Time.deltaTime);

                        outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                        outl.transform.position = vrrig.transform.position + (box.transform.right * 0.25f);
                        UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                        outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                        outl.transform.rotation = box.transform.rotation;
                        outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        outl.GetComponent<Renderer>().material.color = thecolor;
                        UnityEngine.Object.Destroy(outl, Time.deltaTime);

                        outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                        outl.transform.position = vrrig.transform.position + (box.transform.right * -0.25f);
                        UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                        outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                        outl.transform.rotation = box.transform.rotation;
                        outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        outl.GetComponent<Renderer>().material.color = thecolor;
                        UnityEngine.Object.Destroy(outl, Time.deltaTime);

                        UnityEngine.Object.Destroy(box);
                    }
                }
            }
        }

        public static void HollowHuntBoxESP()
        {
            GorillaHuntManager sillyComputer = GorillaGameManager.instance.gameObject.GetComponent<GorillaHuntManager>();
            NetPlayer target = sillyComputer.GetTargetOf(PhotonNetwork.LocalPlayer);
            foreach (NetPlayer player in PhotonNetwork.PlayerList)
            {
                VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                if (player == target)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }

                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.position = vrrig.transform.position;
                    UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                    box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                    box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    box.GetComponent<Renderer>().enabled = false;

                    GameObject outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.up * 0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.5f, 0.05f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.up * -0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.55f, 0.05f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.right * 0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.right * -0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    UnityEngine.Object.Destroy(box);
                }
                if (sillyComputer.GetTargetOf(player) == (NetPlayer)PhotonNetwork.LocalPlayer)
                {
                    UnityEngine.Color thecolor = Color.red;
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }

                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.position = vrrig.transform.position;
                    UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                    box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                    box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    box.GetComponent<Renderer>().enabled = false;

                    GameObject outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.up * 0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.5f, 0.05f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.up * -0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.55f, 0.05f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.right * 0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    outl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (GetIndex("Hidden on Camera").enabled) { outl.layer = 19; }
                    outl.transform.position = vrrig.transform.position + (box.transform.right * -0.25f);
                    UnityEngine.Object.Destroy(outl.GetComponent<BoxCollider>());
                    outl.transform.localScale = new Vector3(0.05f, 0.55f, 0f);
                    outl.transform.rotation = box.transform.rotation;
                    outl.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    outl.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(outl, Time.deltaTime);

                    UnityEngine.Object.Destroy(box);
                }
            }
        }

        public static void CasualBreadcrumbs()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    if (GetIndex("Hidden on Camera").enabled) { sphere.layer = 19; }
                    UnityEngine.Object.Destroy(sphere.GetComponent<SphereCollider>());
                    sphere.GetComponent<Renderer>().material.color = thecolor;
                    sphere.transform.position = vrrig.transform.position;
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    UnityEngine.Object.Destroy(sphere, 10f);
                }
            }
        }

        public static void InfectionBreadcrumbs()
        {
            bool isInfectedPlayers = false;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (PlayerIsTagged(vrrig))
                {
                    isInfectedPlayers = true;
                    break;
                }
            }
            if (isInfectedPlayers)
            {
                if (!PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            UnityEngine.Color thecolor = new Color32(255, 111, 0, 255);
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            if (GetIndex("Hidden on Camera").enabled) { sphere.layer = 19; }
                            UnityEngine.Object.Destroy(sphere.GetComponent<SphereCollider>());
                            sphere.GetComponent<Renderer>().material.color = thecolor;
                            sphere.transform.position = vrrig.transform.position;
                            sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                            UnityEngine.Object.Destroy(sphere, 10f);
                        }
                    }
                }
                else
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            UnityEngine.Color thecolor = vrrig.playerColor;
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            if (GetIndex("Hidden on Camera").enabled) { sphere.layer = 19; }
                            UnityEngine.Object.Destroy(sphere.GetComponent<SphereCollider>());
                            sphere.GetComponent<Renderer>().material.color = thecolor;
                            sphere.transform.position = vrrig.transform.position;
                            sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                            UnityEngine.Object.Destroy(sphere, 10f);
                        }
                    }
                }
            }
            else
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        UnityEngine.Color thecolor = vrrig.playerColor;
                        if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                        if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        if (GetIndex("Hidden on Camera").enabled) { sphere.layer = 19; }
                        UnityEngine.Object.Destroy(sphere.GetComponent<SphereCollider>());
                        sphere.GetComponent<Renderer>().material.color = thecolor;
                        sphere.transform.position = vrrig.transform.position;
                        sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        UnityEngine.Object.Destroy(sphere, 10f);
                    }
                }
            }
        }

        public static void HuntBreadcrumbs()
        {
            GorillaHuntManager sillyComputer = GorillaGameManager.instance.gameObject.GetComponent<GorillaHuntManager>();
            NetPlayer target = sillyComputer.GetTargetOf(PhotonNetwork.LocalPlayer);
            foreach (NetPlayer player in PhotonNetwork.PlayerList)
            {
                VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                if (player == target)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    if (GetIndex("Hidden on Camera").enabled) { sphere.layer = 19; }
                    UnityEngine.Object.Destroy(sphere.GetComponent<SphereCollider>());
                    sphere.GetComponent<Renderer>().material.color = thecolor;
                    sphere.transform.position = vrrig.transform.position;
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    UnityEngine.Object.Destroy(sphere, 10f);
                }
                if (sillyComputer.GetTargetOf(player) == (NetPlayer)PhotonNetwork.LocalPlayer)
                {
                    UnityEngine.Color thecolor = Color.red;
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    if (GetIndex("Hidden on Camera").enabled) { sphere.layer = 19; }
                    UnityEngine.Object.Destroy(sphere.GetComponent<SphereCollider>());
                    sphere.GetComponent<Renderer>().material.color = thecolor;
                    sphere.transform.position = vrrig.transform.position;
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    UnityEngine.Object.Destroy(sphere, 10f);
                }
            }
        }

        public static void CasualDistanceESP()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    UnityEngine.Color thecolor2 = Color.white;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor2 = titleColor; }
                    if (GetIndex("Transparent Theme").enabled) { thecolor2.a = 0.5f; }
                    GameObject go = new GameObject("Dist");
                    if (GetIndex("Hidden on Camera").enabled) { go.layer = 19; }
                    TextMesh textMesh = go.AddComponent<TextMesh>();
                    textMesh.fontSize = 18;
                    textMesh.fontStyle = activeFontStyle;
                    textMesh.characterSize = 0.1f;
                    textMesh.anchor = TextAnchor.MiddleCenter;
                    textMesh.alignment = TextAlignment.Center;
                    textMesh.color = thecolor2;
                    go.transform.position = vrrig.transform.position + new Vector3(0f, -0.2f, 0f);
                    textMesh.text = string.Format("{0:F1}m", Vector3.Distance(Camera.main.transform.position, vrrig.transform.position));
                    GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(bg.GetComponent<Collider>());
                    bg.transform.parent = go.transform;
                    bg.transform.localPosition = Vector3.zero;
                    bg.transform.localScale = new Vector3(textMesh.GetComponent<Renderer>().bounds.size.x + 0.2f, 0.2f, 0.01f);
                    bg.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    bg.GetComponent<Renderer>().material.color = thecolor;
                    textMesh.GetComponent<Renderer>().material.renderQueue = bg.GetComponent<Renderer>().material.renderQueue + 1;
                    go.transform.LookAt(Camera.main.transform.position);
                    go.transform.Rotate(0f, 180f, 0f);
                    UnityEngine.Object.Destroy(go, Time.deltaTime);
                }
            }
        }

        public static void InfectionDistanceESP()
        {
            bool isInfectedPlayers = false;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (PlayerIsTagged(vrrig))
                {
                    isInfectedPlayers = true;
                    break;
                }
            }
            if (isInfectedPlayers)
            {
                if (!PlayerIsTagged(GorillaTagger.Instance.offlineVRRig))
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            UnityEngine.Color thecolor = new Color32(255, 111, 0, 255);
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                            UnityEngine.Color thecolor2 = Color.white;
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor2 = titleColor; }
                            if (GetIndex("Transparent Theme").enabled) { thecolor2.a = 0.5f; }
                            GameObject go = new GameObject("Dist");
                            if (GetIndex("Hidden on Camera").enabled) { go.layer = 19; }
                            TextMesh textMesh = go.AddComponent<TextMesh>();
                            textMesh.fontSize = 18;
                            textMesh.fontStyle = activeFontStyle;
                            textMesh.characterSize = 0.1f;
                            textMesh.anchor = TextAnchor.MiddleCenter;
                            textMesh.alignment = TextAlignment.Center;
                            textMesh.color = thecolor2;
                            go.transform.position = vrrig.transform.position + new Vector3(0f, -0.2f, 0f);
                            textMesh.text = string.Format("{0:F1}m", Vector3.Distance(Camera.main.transform.position, vrrig.transform.position));
                            GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            UnityEngine.Object.Destroy(bg.GetComponent<Collider>());
                            bg.transform.parent = go.transform;
                            bg.transform.localPosition = Vector3.zero;
                            bg.transform.localScale = new Vector3(textMesh.GetComponent<Renderer>().bounds.size.x + 0.2f, 0.2f, 0.01f);
                            bg.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            bg.GetComponent<Renderer>().material.color = thecolor;
                            textMesh.GetComponent<Renderer>().material.renderQueue = bg.GetComponent<Renderer>().material.renderQueue + 1;
                            go.transform.LookAt(Camera.main.transform.position);
                            go.transform.Rotate(0f, 180f, 0f);
                            UnityEngine.Object.Destroy(go, Time.deltaTime);
                        }
                    }
                }
                else
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!PlayerIsTagged(vrrig) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            UnityEngine.Color thecolor = vrrig.playerColor;
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                            if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                            UnityEngine.Color thecolor2 = Color.white;
                            if (GetIndex("Follow Menu Theme").enabled) { thecolor2 = titleColor; }
                            if (GetIndex("Transparent Theme").enabled) { thecolor2.a = 0.5f; }
                            GameObject go = new GameObject("Dist");
                            if (GetIndex("Hidden on Camera").enabled) { go.layer = 19; }
                            TextMesh textMesh = go.AddComponent<TextMesh>();
                            textMesh.fontSize = 18;
                            textMesh.fontStyle = activeFontStyle;
                            textMesh.characterSize = 0.1f;
                            textMesh.anchor = TextAnchor.MiddleCenter;
                            textMesh.alignment = TextAlignment.Center;
                            textMesh.color = thecolor2;
                            go.transform.position = vrrig.transform.position + new Vector3(0f, -0.2f, 0f);
                            textMesh.text = string.Format("{0:F1}m", Vector3.Distance(Camera.main.transform.position, vrrig.transform.position));
                            GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            UnityEngine.Object.Destroy(bg.GetComponent<Collider>());
                            bg.transform.parent = go.transform;
                            bg.transform.localPosition = Vector3.zero;
                            bg.transform.localScale = new Vector3(textMesh.GetComponent<Renderer>().bounds.size.x + 0.2f, 0.2f, 0.01f);
                            bg.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                            bg.GetComponent<Renderer>().material.color = thecolor;
                            textMesh.GetComponent<Renderer>().material.renderQueue = bg.GetComponent<Renderer>().material.renderQueue + 1;
                            go.transform.LookAt(Camera.main.transform.position);
                            go.transform.Rotate(0f, 180f, 0f);
                            UnityEngine.Object.Destroy(go, Time.deltaTime);
                        }
                    }
                }
            }
            else
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        UnityEngine.Color thecolor = vrrig.playerColor;
                        if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                        if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                        UnityEngine.Color thecolor2 = Color.white;
                        if (GetIndex("Follow Menu Theme").enabled) { thecolor2 = titleColor; }
                        if (GetIndex("Transparent Theme").enabled) { thecolor2.a = 0.5f; }
                        GameObject go = new GameObject("Dist");
                        if (GetIndex("Hidden on Camera").enabled) { go.layer = 19; }
                        TextMesh textMesh = go.AddComponent<TextMesh>();
                        textMesh.fontSize = 18;
                        textMesh.fontStyle = activeFontStyle;
                        textMesh.characterSize = 0.1f;
                        textMesh.anchor = TextAnchor.MiddleCenter;
                        textMesh.alignment = TextAlignment.Center;
                        textMesh.color = thecolor2;
                        go.transform.position = vrrig.transform.position + new Vector3(0f, -0.2f, 0f);
                        textMesh.text = string.Format("{0:F1}m", Vector3.Distance(Camera.main.transform.position, vrrig.transform.position));
                        GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        UnityEngine.Object.Destroy(bg.GetComponent<Collider>());
                        bg.transform.parent = go.transform;
                        bg.transform.localPosition = Vector3.zero;
                        bg.transform.localScale = new Vector3(textMesh.GetComponent<Renderer>().bounds.size.x + 0.2f, 0.2f, 0.01f);
                        bg.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        bg.GetComponent<Renderer>().material.color = thecolor;
                        textMesh.GetComponent<Renderer>().material.renderQueue = bg.GetComponent<Renderer>().material.renderQueue + 1;
                        go.transform.LookAt(Camera.main.transform.position);
                        go.transform.Rotate(0f, 180f, 0f);
                        UnityEngine.Object.Destroy(go, Time.deltaTime);
                    }
                }
            }
        }

        public static void HuntDistanceESP()
        {
            GorillaHuntManager sillyComputer = GorillaGameManager.instance.gameObject.GetComponent<GorillaHuntManager>();
            NetPlayer target = sillyComputer.GetTargetOf(PhotonNetwork.LocalPlayer);
            foreach (NetPlayer player in PhotonNetwork.PlayerList)
            {
                VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                if (player == target)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    UnityEngine.Color thecolor2 = Color.white;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor2 = titleColor; }
                    if (GetIndex("Transparent Theme").enabled) { thecolor2.a = 0.5f; }
                    GameObject go = new GameObject("Dist");
                    if (GetIndex("Hidden on Camera").enabled) { go.layer = 19; }
                    TextMesh textMesh = go.AddComponent<TextMesh>();
                    textMesh.fontSize = 18;
                    textMesh.fontStyle = activeFontStyle;
                    textMesh.characterSize = 0.1f;
                    textMesh.anchor = TextAnchor.MiddleCenter;
                    textMesh.alignment = TextAlignment.Center;
                    textMesh.color = thecolor2;
                    go.transform.position = vrrig.transform.position + new Vector3(0f, -0.2f, 0f);
                    textMesh.text = string.Format("{0:F1}m", Vector3.Distance(Camera.main.transform.position, vrrig.transform.position));
                    GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(bg.GetComponent<Collider>());
                    bg.transform.parent = go.transform;
                    bg.transform.localPosition = Vector3.zero;
                    bg.transform.localScale = new Vector3(textMesh.GetComponent<Renderer>().bounds.size.x + 0.2f, 0.2f, 0.01f);
                    bg.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    bg.GetComponent<Renderer>().material.color = thecolor;
                    textMesh.GetComponent<Renderer>().material.renderQueue = bg.GetComponent<Renderer>().material.renderQueue + 1;
                    go.transform.LookAt(Camera.main.transform.position);
                    go.transform.Rotate(0f, 180f, 0f);
                    UnityEngine.Object.Destroy(go, Time.deltaTime);
                }
                if (sillyComputer.GetTargetOf(player) == (NetPlayer)PhotonNetwork.LocalPlayer)
                {
                    UnityEngine.Color thecolor = Color.red;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor = GetBGColor(0f); }
                    if (GetIndex("Transparent Theme").enabled) { thecolor.a = 0.5f; }
                    UnityEngine.Color thecolor2 = Color.white;
                    if (GetIndex("Follow Menu Theme").enabled) { thecolor2 = titleColor; }
                    if (GetIndex("Transparent Theme").enabled) { thecolor2.a = 0.5f; }
                    GameObject go = new GameObject("Dist");
                    if (GetIndex("Hidden on Camera").enabled) { go.layer = 19; }
                    TextMesh textMesh = go.AddComponent<TextMesh>();
                    textMesh.fontSize = 18;
                    textMesh.fontStyle = activeFontStyle;
                    textMesh.characterSize = 0.1f;
                    textMesh.anchor = TextAnchor.MiddleCenter;
                    textMesh.alignment = TextAlignment.Center;
                    textMesh.color = thecolor2;
                    go.transform.position = vrrig.transform.position + new Vector3(0f, -0.2f, 0f);
                    textMesh.text = string.Format("{0:F1}m", Vector3.Distance(Camera.main.transform.position, vrrig.transform.position));
                    GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(bg.GetComponent<Collider>());
                    bg.transform.parent = go.transform;
                    bg.transform.localPosition = Vector3.zero;
                    bg.transform.localScale = new Vector3(textMesh.GetComponent<Renderer>().bounds.size.x + 0.2f, 0.2f, 0.01f);
                    bg.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    bg.GetComponent<Renderer>().material.color = thecolor;
                    textMesh.GetComponent<Renderer>().material.renderQueue = bg.GetComponent<Renderer>().material.renderQueue + 1;
                    go.transform.LookAt(Camera.main.transform.position);
                    go.transform.Rotate(0f, 180f, 0f);
                    UnityEngine.Object.Destroy(go, Time.deltaTime);
                }
            }
        }
