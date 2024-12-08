using BepInEx;
using ExitGames.Client.Photon;
using GorillaLocomotion.Climbing;
using GorillaLocomotion.Swimming;
using GorillaNetworking;
using HarmonyLib;
using LegallyStupid.Classes;
using LegallyStupid.Menu;
using LegallyStupid.Notifications;
using Oculus.Platform;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR;
using static LegallyStupid.Menu.Main;

namespace LegallyStupid.Mods
{
    public class Movement
    {
        public static void ChangePlatformType()
        {
            platformMode++;
            if (platformMode > 11)
            {
                platformMode = 0;
            }

            string[] platformNames = new string[] {
                "Normal",
                "Invisible",
                "Rainbow",
                "Random Color",
                "Noclip",
                "Glass",
                "Snowball",
                "Water Balloon",
                "Rock",
                "Present",
                "Mentos",
                "Fish Food"
            };

            GetIndex("Change Platform Type").overlapText = "Change Platform Type <color=grey>[</color><color=green>" + platformNames[platformMode] + "</color><color=grey>]</color>";
        }

        public static void ChangePlatformShape()
        {
            platformShape++;
            if (platformShape > 6)
            {
                platformShape = 0;
            }

            string[] platformShapes = new string[] {
                "Sphere",
                "Cube",
                "Cylinder",
                "Legacy",
                "Small",
                "Long",
                "1x1"
            };

            GetIndex("Change Platform Shape").overlapText = "Change Platform Shape <color=grey>[</color><color=green>" + platformShapes[platformShape] + "</color><color=grey>]</color>";
        }

        public static GameObject CreatePlatform()
        {
            GameObject platform = null;
            if (platformShape == 0)
            {
                platform = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                platform.transform.localScale = new Vector3(0.333f, 0.333f, 0.333f);
            }
            if (platformShape == 1)
            {
                platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platform.transform.localScale = new Vector3(0.333f, 0.333f, 0.333f);
            }
            if (platformShape == 2)
            {
                platform = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                platform.transform.localScale = new Vector3(0.333f, 0.333f, 0.333f);
            }
            if (platformShape == 3)
            {
                platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platform.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
            }
            if (platformShape == 4)
            {
                platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platform.transform.localScale = new Vector3(0.025f, 0.15f, 0.2f);
            }
            if (platformShape == 5)
            {
                platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platform.transform.localScale = new Vector3(0.025f, 0.3f, 0.8f);
            }
            if (platformShape == 6)
            {
                platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platform.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (platformMode != 5)
            {
                platform.GetComponent<Renderer>().material.color = GetBGColor(0f);
            }
            if (platformMode == 1)
            {
                platform.GetComponent<Renderer>().enabled = false;
            }
            if (platformMode == 2)
            {
                float h = (Time.frameCount / 180f) % 1f;
                platform.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
            }
            if (platformMode == 3)
            {
                platform.GetComponent<Renderer>().material.color = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 128);
            }
            if (platformMode == 4)
            {
                UpdateClipColliders(false);
            }
            if (platformMode == 5)
            {
                platform.AddComponent<GorillaSurfaceOverride>().overrideIndex = 29;
                if (glass == null)
                {
                    glass = new Material(Shader.Find("GUI/Text Shader"));
                    glass.color = new Color32(145, 187, 255, 100);
                }
                platform.GetComponent<Renderer>().material = glass;
            }
            if (platformMode == 6)
            {
                platform.AddComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                platform.GetComponent<Renderer>().enabled = false;
            }
            if (platformMode == 7)
            {
                platform.AddComponent<GorillaSurfaceOverride>().overrideIndex = 204;
                platform.GetComponent<Renderer>().enabled = false;
            }
            if (platformMode == 8)
            {
                platform.AddComponent<GorillaSurfaceOverride>().overrideIndex = 231;
                platform.GetComponent<Renderer>().enabled = false;
            }
            if (platformMode == 9)
            {
                platform.AddComponent<GorillaSurfaceOverride>().overrideIndex = 240;
                platform.GetComponent<Renderer>().enabled = false;
            }
            if (platformMode == 10)
            {
                platform.AddComponent<GorillaSurfaceOverride>().overrideIndex = 249;
                platform.GetComponent<Renderer>().enabled = false;
            }
            if (platformMode == 11)
            {
                platform.AddComponent<GorillaSurfaceOverride>().overrideIndex = 252;
                platform.GetComponent<Renderer>().enabled = false;
            }

            FixStickyColliders(platform);

            if (GetIndex("Platform Outlines").enabled)
            {
                GameObject gameObject = null;
                if (platformShape == 2)
                {
                    gameObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                }
                if (platformShape == 1)
                {
                    gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                }
                if (platformShape == 0)
                {
                    gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                }
                if (gameObject == null)
                {
                    gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                }
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
                gameObject.transform.parent = platform.transform;
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.transform.localRotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.95f, 1.05f, 1.05f);
                GradientColorKey[] array = new GradientColorKey[3];
                array[0].color = buttonDefaultA;
                array[0].time = 0f;
                array[1].color = buttonDefaultB;
                array[1].time = 0.5f;
                array[2].color = buttonDefaultA;
                array[2].time = 1f;
                ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
                colorChanger.colors = new Gradient
                {
                    colorKeys = array
                };
                colorChanger.Start();
            }
            return platform;
        }

        public static GameObject leftplat = null;
        public static GameObject rightplat = null;
        public static void Platforms()
        {
            if (leftGrab)
            {
                if (leftplat == null)
                {
                    leftplat = CreatePlatform();
                    var leftHandTransform = TrueLeftHand();
                    leftplat.transform.position = leftHandTransform.position;
                    leftplat.transform.rotation = leftHandTransform.rotation;
                }


                else
                {
                    if (platformMode != 5)
                    {
                        leftplat.GetComponent<Renderer>().material.color = GetBGColor(0f);
                    }
                    if (platformMode == 2)
                    {
                        float h = (Time.frameCount / 180f) % 1f;
                        leftplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
                    }
                    if (platformMode == 3)
                    {
                        leftplat.GetComponent<Renderer>().material.color = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 128);
                    }
                }
                }
                else
                {
                    if (leftplat != null)
                    {
                        if (GetIndex("Platform Gravity").enabled)
                        {
                            leftplat.AddComponent(typeof(Rigidbody));
                            UnityEngine.Object.Destroy(leftplat.GetComponent<Collider>());
                            UnityEngine.Object.Destroy(leftplat, 2f);
                        }
                        else
                        {
                            UnityEngine.Object.Destroy(leftplat);
                        }
                        leftplat = null;
                        if (platformMode == 4 && rightplat == null)
                        {
                            UpdateClipColliders(true);
                        }
                    }
                }

                if (rightGrab)
                {
                    if (rightplat == null)
                    {
                        rightplat = CreatePlatform();
                        var rightHandTransform = TrueRightHand();
                        rightplat.transform.position = rightHandTransform.position;
                        rightplat.transform.rotation = rightHandTransform.rotation;
                    }

                    else
                    {
                        if (platformMode != 5)
                        {
                            rightplat.GetComponent<Renderer>().material.color = GetBGColor(0f);
                        }
                        if (platformMode == 2)
                        {
                            float h = (Time.frameCount / 180f) % 1f;
                            rightplat.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(h, 1f, 1f);
                        }
                        if (platformMode == 3)
                        {
                            rightplat.GetComponent<Renderer>().material.color = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 128);
                        }
                    }
                }
                else
                {
                    if (rightplat != null)
                    {
                        if (GetIndex("Platform Gravity").enabled)
                        {
                            rightplat.AddComponent(typeof(Rigidbody));
                            UnityEngine.Object.Destroy(rightplat.GetComponent<Collider>());
                            UnityEngine.Object.Destroy(rightplat, 2f);
                        }
                        else
                        {
                            UnityEngine.Object.Destroy(rightplat);
                        }
                        rightplat = null;
                        if (platformMode == 4 && leftplat == null)
                        {
                            UpdateClipColliders(true);
                        }
                    }
                }
            }

        public static void TriggerPlatforms()
        {
            bool lt = leftGrab;
            bool rt = rightGrab;
            leftGrab = leftTrigger > 0.5f;
            rightGrab = rightTrigger > 0.5f;
            Platforms();
            leftGrab = lt;
            rightGrab = rt;
        }

        public static void Frozone()
        {
            if (leftGrab)
            {
                GameObject lol = GameObject.CreatePrimitive(PrimitiveType.Cube);
                lol.GetComponent<Renderer>().material.color = GetBGColor(0f);
                lol.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                lol.transform.localPosition = TrueLeftHand().position + (TrueLeftHand().right * 0.05f);
                lol.transform.rotation = TrueLeftHand().rotation;

                lol.AddComponent<GorillaSurfaceOverride>().overrideIndex = 61;
                UnityEngine.Object.Destroy(lol, 1);
            }

            if (rightGrab)
            {
                GameObject lol = GameObject.CreatePrimitive(PrimitiveType.Cube);
                lol.GetComponent<Renderer>().material.color = GetBGColor(0f);
                lol.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                lol.transform.localPosition = TrueRightHand().position + (TrueRightHand().right * -0.05f);
                lol.transform.rotation = TrueRightHand().rotation;

                lol.AddComponent<GorillaSurfaceOverride>().overrideIndex = 61;
                UnityEngine.Object.Destroy(lol, 1);
            }

            GorillaTagger.Instance.bodyCollider.enabled = !(leftGrab || rightGrab);
        }

        public static void ChangeSpeedBoostAmount()
        {
            speedboostCycle++;
            if (speedboostCycle > 3)
            {
                speedboostCycle = 0;
            }

            float[] jspeedamounts = new float[] { 2f, 7.5f, 9f, 200f };
            jspeed = jspeedamounts[speedboostCycle];

            float[] jmultiamounts = new float[] { 0.5f, /*1.25f*/1.1f, 2f, 10f };
            jmulti = jmultiamounts[speedboostCycle];

            string[] speedNames = new string[] { "Slow", "Normal", "Fast", "Ultra Fast" };
            GetIndex("Change Speed Boost Amount").overlapText = "Change Speed Boost Amount <color=grey>[</color><color=green>" + speedNames[speedboostCycle] + "</color><color=grey>]</color>";
        }

      
        public static void ChangeFlySpeed()
        {
            flySpeedCycle++;
            if (flySpeedCycle > 4)
            {
                flySpeedCycle = 0;
            }

            float[] speedamounts = new float[] { 5f, 10f, 30f, 60f, 0.5f };
            flySpeed = speedamounts[flySpeedCycle];

            string[] speedNames = new string[] { "Slow", "Normal", "Fast", "Extra Fast", "Extra Slow" };
            GetIndex("Change Fly Speed").overlapText = "Change Fly Speed <color=grey>[</color><color=green>" + speedNames[flySpeedCycle] + "</color><color=grey>]</color>";
        }

        

        public static void Fly()
        {
            if (rightPrimary)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * flySpeed;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void TriggerFly()
        {
            if (rightTrigger > 0.5f)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * flySpeed;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void NoclipFly()
        {
            if (rightPrimary)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * flySpeed;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                if (noclip == false)
                {
                    noclip = true;
                    UpdateClipColliders(false);
                }
            } else
            {
                if (noclip == true)
                {
                    noclip = false;
                    UpdateClipColliders(true);
                }
            }
        }

        public static void JoystickFly()
        {
            Vector2 joy = SteamVR_Actions.gorillaTag_LeftJoystick2DAxis.axis;

            if (Mathf.Abs(joy.x) > 0.3 || Mathf.Abs(joy.y) > 0.3)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * (joy.y * flySpeed)) + (GorillaTagger.Instance.headCollider.transform.right * Time.deltaTime * (joy.x * flySpeed));
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void BarkFly()
        {
            ZeroGravity();

            var rb = GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody;
            Vector2 xz = SteamVR_Actions.gorillaTag_LeftJoystick2DAxis.axis;
            float y = SteamVR_Actions.gorillaTag_RightJoystick2DAxis.axis.y;

            Vector3 inputDirection = new Vector3(xz.x, y, xz.y);
            var playerForward = GorillaLocomotion.Player.Instance.bodyCollider.transform.forward;
            playerForward.y = 0;
            var playerRight = GorillaLocomotion.Player.Instance.bodyCollider.transform.right;
            playerRight.y = 0;

            var velocity = inputDirection.x * playerRight + y * Vector3.up + inputDirection.z * playerForward;
            velocity *= GorillaLocomotion.Player.Instance.scale * flySpeed;
            rb.velocity = Vector3.Lerp(rb.velocity, velocity, 0.12875f);
        }

        public static void HandFly()
        {
            if (rightPrimary)
            {
                GorillaLocomotion.Player.Instance.transform.position += TrueRightHand().forward * Time.deltaTime * flySpeed;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        private static float driveSpeed = 0f;
        public static int driveInt = 0;
       

        public static Vector2 lerpygerpy = Vector2.zero;
      
        public static void IronMan()
        {
            if (leftPrimary)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(flySpeed * -GorillaTagger.Instance.leftHandTransform.right, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 50f * GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
            }
            if (rightPrimary)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(flySpeed * GorillaTagger.Instance.rightHandTransform.right, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 50f * GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
            }
        }

        private static float loaoalsode = 0f;
       

        public static Vector3 rightgrapplePoint;
        public static Vector3 leftgrapplePoint;
        public static SpringJoint rightjoint;
        public static SpringJoint leftjoint;
        public static bool isLeftGrappling = false;
        public static bool isRightGrappling = false;
        public static void SpiderMan()
        {
            if (leftGrab)
            {
                if (!isLeftGrappling)
                {
                    isLeftGrappling = true;
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaTagger.Instance.leftHandTransform.forward * 5f;
                    if (PhotonNetwork.InRoom)
                    {
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]{
                            89,
                            true,
                            999999f
                        });
                    } else
                    {
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(89, true, 999999f);
                    }
                    RPCProtection();
                    RaycastHit lefthit;
                    if (Physics.Raycast(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.forward, out lefthit, 512f, NoInvisLayerMask()))
                    {
                        leftgrapplePoint = lefthit.point;

                        leftjoint = GorillaTagger.Instance.gameObject.AddComponent<SpringJoint>();
                        leftjoint.autoConfigureConnectedAnchor = false;
                        leftjoint.connectedAnchor = leftgrapplePoint;

                        float leftdistanceFromPoint = Vector3.Distance(GorillaTagger.Instance.bodyCollider.attachedRigidbody.position, leftgrapplePoint);

                        leftjoint.maxDistance = leftdistanceFromPoint * 0.8f;
                        leftjoint.minDistance = leftdistanceFromPoint * 0.25f;

                        leftjoint.spring = 10f;
                        leftjoint.damper = 50f;
                        leftjoint.massScale = 12f;
                    }
                }

                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                UnityEngine.Color thecolor = Color.red;
                liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                liner.SetPosition(0, GorillaTagger.Instance.leftHandTransform.position);
                liner.SetPosition(1, leftgrapplePoint);
                liner.material.shader = Shader.Find("GorillaTag/UberShader");
                UnityEngine.Object.Destroy(line, Time.deltaTime);
            }
            else
            {
                Physics.Raycast(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.forward, out var Ray, 512f, NoInvisLayerMask());
                GameObject NewPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                NewPointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                NewPointer.GetComponent<Renderer>().material.color = buttonDefaultA - new Color32(0, 0, 0, 128);
                NewPointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                NewPointer.transform.position = Ray.point;
                UnityEngine.Object.Destroy(NewPointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(NewPointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(NewPointer.GetComponent<Collider>());
                UnityEngine.Object.Destroy(NewPointer, Time.deltaTime);
                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                liner.material.shader = Shader.Find("GUI/Text Shader");
                liner.startColor = GetBGColor(0f) - new Color32(0, 0, 0, 128);
                liner.endColor = GetBGColor(0.5f) - new Color32(0, 0, 0, 128);
                liner.startWidth = 0.025f;
                liner.endWidth = 0.025f;
                liner.positionCount = 2;
                liner.useWorldSpace = true;
                liner.SetPosition(0, GorillaTagger.Instance.leftHandTransform.position);
                liner.SetPosition(1, Ray.point);
                UnityEngine.Object.Destroy(line, Time.deltaTime);

                isLeftGrappling = false;
                UnityEngine.Object.Destroy(leftjoint);
            }

            if (rightGrab)
            {
                if (!isRightGrappling)
                {
                    isRightGrappling = true;
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += GorillaTagger.Instance.rightHandTransform.forward * 5f;
                    if (PhotonNetwork.InRoom)
                    {
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]{
                            89,
                            false,
                            999999f
                        });
                        RPCProtection();
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(89, false, 999999f);
                    }
                    RaycastHit righthit;
                    if (Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out righthit, 512f, NoInvisLayerMask()))
                    {
                        rightgrapplePoint = righthit.point;

                        rightjoint = GorillaTagger.Instance.gameObject.AddComponent<SpringJoint>();
                        rightjoint.autoConfigureConnectedAnchor = false;
                        rightjoint.connectedAnchor = rightgrapplePoint;

                        float rightdistanceFromPoint = Vector3.Distance(GorillaTagger.Instance.bodyCollider.attachedRigidbody.position, rightgrapplePoint);

                        rightjoint.maxDistance = rightdistanceFromPoint * 0.8f;
                        rightjoint.minDistance = rightdistanceFromPoint * 0.25f;

                        rightjoint.spring = 10f;
                        rightjoint.damper = 50f;
                        rightjoint.massScale = 12f;
                    }
                }

                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                UnityEngine.Color thecolor = Color.red;
                liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                liner.SetPosition(1, rightgrapplePoint);
                liner.material.shader = Shader.Find("GorillaTag/UberShader");
                UnityEngine.Object.Destroy(line, Time.deltaTime);
            }
            else
            {
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out var Ray, 512f, NoInvisLayerMask());
                GameObject NewPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                NewPointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                NewPointer.GetComponent<Renderer>().material.color = buttonDefaultA - new Color32(0, 0, 0, 128);
                NewPointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                NewPointer.transform.position = Ray.point;
                UnityEngine.Object.Destroy(NewPointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(NewPointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(NewPointer.GetComponent<Collider>());
                UnityEngine.Object.Destroy(NewPointer, Time.deltaTime);

                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                liner.material.shader = Shader.Find("GUI/Text Shader");
                liner.startColor = GetBGColor(0f) - new Color32(0, 0, 0, 128);
                liner.endColor = GetBGColor(0.5f) - new Color32(0, 0, 0, 128);
                liner.startWidth = 0.025f;
                liner.endWidth = 0.025f;
                liner.positionCount = 2;
                liner.useWorldSpace = true;
                liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                liner.SetPosition(1, Ray.point);
                UnityEngine.Object.Destroy(line, Time.deltaTime);

                isRightGrappling = false;
                UnityEngine.Object.Destroy(rightjoint);
            }
        }

        public static void GrapplingHooks()
        {
            if (leftGrab)
            {
                if (!isLeftGrappling)
                {
                    isLeftGrappling = true;
                    if (PhotonNetwork.InRoom)
                    {
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]{
                            89,
                            true,
                            999999f
                        });
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(89, true, 999999f);
                    }
                    RPCProtection();
                    RaycastHit lefthit;
                    if (Physics.Raycast(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.forward, out lefthit, 512f, NoInvisLayerMask()))
                    {
                        leftgrapplePoint = lefthit.point;
                    }
                }

                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(leftgrapplePoint - GorillaTagger.Instance.leftHandTransform.position) * 0.5f;

                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                UnityEngine.Color thecolor = Color.red;
                liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                liner.SetPosition(0, GorillaTagger.Instance.leftHandTransform.position);
                liner.SetPosition(1, leftgrapplePoint);
                liner.material.shader = Shader.Find("GorillaTag/UberShader");
                UnityEngine.Object.Destroy(line, Time.deltaTime);
            }
            else
            {
                Physics.Raycast(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.forward, out var Ray, 512f, NoInvisLayerMask());
                GameObject NewPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                NewPointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                NewPointer.GetComponent<Renderer>().material.color = buttonDefaultA - new Color32(0, 0, 0, 128);
                NewPointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                NewPointer.transform.position = Ray.point;
                UnityEngine.Object.Destroy(NewPointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(NewPointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(NewPointer.GetComponent<Collider>());
                UnityEngine.Object.Destroy(NewPointer, Time.deltaTime);

                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                liner.material.shader = Shader.Find("GUI/Text Shader");
                liner.startColor = GetBGColor(0f) - new Color32(0, 0, 0, 128);
                liner.endColor = GetBGColor(0.5f) - new Color32(0, 0, 0, 128);
                liner.startWidth = 0.025f;
                liner.endWidth = 0.025f;
                liner.positionCount = 2;
                liner.useWorldSpace = true;
                liner.SetPosition(0, GorillaTagger.Instance.leftHandTransform.position);
                liner.SetPosition(1, Ray.point);
                UnityEngine.Object.Destroy(line, Time.deltaTime);

                isLeftGrappling = false;
                UnityEngine.Object.Destroy(leftjoint);
            }

            if (rightGrab)
            {
                if (!isRightGrappling)
                {
                    isRightGrappling = true;
                    if (PhotonNetwork.InRoom)
                    {
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]{
                            89,
                            false,
                            999999f
                        });
                        RPCProtection();
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(89, false, 999999f);
                    }
                    RaycastHit righthit;
                    if (Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out righthit, 512f, NoInvisLayerMask()))
                    {
                        rightgrapplePoint = righthit.point;
                    }
                }

                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(rightgrapplePoint - GorillaTagger.Instance.rightHandTransform.position) * 0.5f;

                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                UnityEngine.Color thecolor = Color.red;
                liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                liner.SetPosition(1, rightgrapplePoint);
                liner.material.shader = Shader.Find("GorillaTag/UberShader");
                UnityEngine.Object.Destroy(line, Time.deltaTime);
            }
            else
            {
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out var Ray, 512f, NoInvisLayerMask());
                GameObject NewPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                NewPointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                NewPointer.GetComponent<Renderer>().material.color = buttonDefaultA - new Color32(0, 0, 0, 128);
                NewPointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                NewPointer.transform.position = Ray.point;
                UnityEngine.Object.Destroy(NewPointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(NewPointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(NewPointer.GetComponent<Collider>());
                UnityEngine.Object.Destroy(NewPointer, Time.deltaTime);

                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                liner.material.shader = Shader.Find("GUI/Text Shader");
                liner.startColor = GetBGColor(0f) - new Color32(0, 0, 0, 128);
                liner.endColor = GetBGColor(0.5f) - new Color32(0, 0, 0, 128);
                liner.startWidth = 0.025f;
                liner.endWidth = 0.025f;
                liner.positionCount = 2;
                liner.useWorldSpace = true;
                liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                liner.SetPosition(1, Ray.point);
                UnityEngine.Object.Destroy(line, Time.deltaTime);

                isRightGrappling = false;
                UnityEngine.Object.Destroy(rightjoint);
            }
        }

        public static void DisableSpiderMan()
        {
            isLeftGrappling = false;
            UnityEngine.Object.Destroy(leftjoint);
            isRightGrappling = false;
            UnityEngine.Object.Destroy(rightjoint);
        }

        public static void ZeroGravity()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static void WallWalk()
        {
            if (GorillaLocomotion.Player.Instance.wasLeftHandTouching || GorillaLocomotion.Player.Instance.wasRightHandTouching)
            {
                FieldInfo fieldInfo = typeof(GorillaLocomotion.Player).GetField("lastHitInfoHand", BindingFlags.NonPublic | BindingFlags.Instance);
                RaycastHit ray = (RaycastHit)fieldInfo.GetValue(GorillaLocomotion.Player.Instance);
                walkPos = ray.point;
                walkNormal = ray.normal;
            }

            if (walkPos != Vector3.zero && rightGrab)
            {
                //GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(walkNormal * -10, ForceMode.Acceleration);
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(walkNormal * -9.81f, ForceMode.Acceleration);
                ZeroGravity();
            }
        }

        public static void WeakWallWalk()
        {
            if (GorillaLocomotion.Player.Instance.wasLeftHandTouching || GorillaLocomotion.Player.Instance.wasRightHandTouching)
            {
                FieldInfo fieldInfo = typeof(GorillaLocomotion.Player).GetField("lastHitInfoHand", BindingFlags.NonPublic | BindingFlags.Instance);
                RaycastHit ray = (RaycastHit)fieldInfo.GetValue(GorillaLocomotion.Player.Instance);
                walkPos = ray.point;
                walkNormal = ray.normal;
            }

            if (walkPos != Vector3.zero && rightGrab)
            {
                //GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(walkNormal * -10, ForceMode.Acceleration);
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(walkNormal * -5f, ForceMode.Acceleration);
                ZeroGravity();
            }
        }

        public static void StrongWallWalk()
        {
            if (GorillaLocomotion.Player.Instance.wasLeftHandTouching || GorillaLocomotion.Player.Instance.wasRightHandTouching)
            {
                FieldInfo fieldInfo = typeof(GorillaLocomotion.Player).GetField("lastHitInfoHand", BindingFlags.NonPublic | BindingFlags.Instance);
                RaycastHit ray = (RaycastHit)fieldInfo.GetValue(GorillaLocomotion.Player.Instance);
                walkPos = ray.point;
                walkNormal = ray.normal;
            }

            if (walkPos != Vector3.zero && rightGrab)
            {
                //GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(walkNormal * -10, ForceMode.Acceleration);
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(walkNormal * -50f, ForceMode.Acceleration);
                ZeroGravity();
            }
        }





        private static int rememberPageNumber = 0;
      
        public static void TeleportGun()
        {
            if (rightGrab || Mouse.current.rightButton.isPressed)
            {
                var GunData = RenderGun();
                RaycastHit Ray = GunData.Ray;
                GameObject NewPointer = GunData.NewPointer;

                if ((rightTrigger > 0.5f || Mouse.current.leftButton.isPressed) && Time.time > teleDebounce)
                {
                    closePosition = Vector3.zero;
                    TeleportPlayer(NewPointer.transform.position + new Vector3(0f, 1f, 0f));
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    teleDebounce = Time.time + 0.5f;
                }
            }
        }

        public static GameObject CheckPoint = null;
        public static void Checkpoint()
        {
            if (rightGrab)
            {
                if (CheckPoint == null)
                {
                    CheckPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(CheckPoint.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(CheckPoint.GetComponent<SphereCollider>());
                    CheckPoint.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }
                CheckPoint.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
            if (CheckPoint != null)
            {
                if (rightPrimary)
                {
                    CheckPoint.GetComponent<Renderer>().material.color = bgColorA;
                    TeleportPlayer(CheckPoint.transform.position);
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                else
                {
                    CheckPoint.GetComponent<Renderer>().material.color = buttonDefaultA;
                }
            }
        }

        public static void DisableCheckpoint()
        {
            if (CheckPoint != null)
            {
                UnityEngine.Object.Destroy(CheckPoint);
                CheckPoint = null;
            }
        }

        private static GameObject pearl = null;
        private static Texture2D pearltxt = null;
        private static Material pearlmat = null;
        private static bool isrighthandedpearl = false;
        public static void EnderPearl()
        {
            if (rightGrab || leftGrab)
            {
                if (pearl == null)
                {
                    pearl = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(pearl.GetComponent<Collider>());
                    pearl.transform.localScale = new Vector3(0.1f, 0.1f, 0.01f);
                    if (pearlmat == null)
                    {
                        pearlmat = new Material(Shader.Find("Universal Render Pipeline/Lit"));

                        pearlmat.color = Color.white;
                        if (pearltxt == null)
                        {
                            pearltxt = LoadTextureFromResource("LegallyStupid.Resources.pearl.png");
                            pearltxt.filterMode = FilterMode.Point;
                            pearltxt.wrapMode = TextureWrapMode.Clamp;
                        }
                        pearlmat.mainTexture = pearltxt;

                        pearlmat.SetFloat("_Surface", 1);
                        pearlmat.SetFloat("_Blend", 0);
                        pearlmat.SetFloat("_SrcBlend", (float)BlendMode.SrcAlpha);
                        pearlmat.SetFloat("_DstBlend", (float)BlendMode.OneMinusSrcAlpha);
                        pearlmat.SetFloat("_ZWrite", 0);
                        pearlmat.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
                        pearlmat.renderQueue = (int)RenderQueue.Transparent;

                        pearlmat.SetFloat("_Glossiness", 0f);
                        pearlmat.SetFloat("_Metallic", 0f);
                    }
                    pearl.GetComponent<Renderer>().material = pearlmat;
                }
                if (pearl.GetComponent<Rigidbody>() != null)
                {
                    UnityEngine.Object.Destroy(pearl.GetComponent<Rigidbody>());
                }
                isrighthandedpearl = rightGrab;
                pearl.transform.position = rightGrab ? GorillaTagger.Instance.rightHandTransform.position : GorillaTagger.Instance.leftHandTransform.position;
            } else
            {
                if (pearl != null)
                {
                    if (pearl.GetComponent<Rigidbody>() == null)
                    {
                        Rigidbody comp = pearl.AddComponent(typeof(Rigidbody)) as Rigidbody;
                        comp.velocity = isrighthandedpearl ? GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0) : GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    }
                    Physics.Raycast(pearl.transform.position, pearl.GetComponent<Rigidbody>().velocity, out var Ray, 0.25f, GorillaLocomotion.Player.Instance.locomotionEnabledLayers);
                    if (Ray.collider != null)
                    {
                        TeleportPlayer(pearl.transform.position);
                        if (PhotonNetwork.InRoom)
                        {
                            GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]{
                                84,
                                true,
                                999999f
                            });
                        }
                        else
                        {
                            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(84, true, 999999f);
                        }
                        RPCProtection();
                        UnityEngine.Object.Destroy(pearl);
                    }
                }
            }
            if (pearl != null)
            {
                pearl.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                if (pearl.GetComponent<Rigidbody>() != null)
                {
                    pearl.GetComponent<Rigidbody>().AddForce(Vector3.up * (Time.deltaTime * (6.66f / Time.deltaTime)), ForceMode.Acceleration);
                }
            }
        }

        public static void DestroyEnderPearl()
        {
            if (pearl != null)
            {
                UnityEngine.Object.Destroy(pearl);
            }
        }

        public static void SpeedBoost()
        {
            float jspt = jspeed;
            float jmpt = jmulti;
            if (GetIndex("Factored Speed Boost").enabled)
            {
                jspt = (jspt / 6.5f) * GorillaLocomotion.Player.Instance.maxJumpSpeed;
                jmpt = (jmpt / 1.1f) * GorillaLocomotion.Player.Instance.jumpMultiplier;
            }
            if (!GetIndex("Disable Max Speed Modification").enabled)
            {
                GorillaLocomotion.Player.Instance.maxJumpSpeed = jspeed;
            }
            GorillaLocomotion.Player.Instance.jumpMultiplier = jmulti;
        }

        public static void GripSpeedBoost()
        {
            if (rightGrab)
            {
                SpeedBoost();
            }
        }

        public static void JoystickSpeedBoost()
        {
            if (SteamVR_Actions.gorillaTag_RightJoystickClick.state)
            {
                SpeedBoost();
            }
        }


        public static void DisableSpeedBoost()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
            GorillaLocomotion.Player.Instance.jumpMultiplier = 1.1f;
        }

      

        public static void UpdateClipColliders(bool enabledd)
        {
            foreach (MeshCollider v in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                v.enabled = enabledd;
            }
        }

        public static void Noclip()
        {
            if (rightTrigger > 0.5f || UnityInput.Current.GetKey(KeyCode.E))
            {
                if (noclip == false)
                {
                    noclip = true;
                    UpdateClipColliders(false);
                }
            }
            else
            {
                if (noclip == true)
                {
                    noclip = false;
                    UpdateClipColliders(true);
                }
            }
        }

        private static bool wasDisabledAlready = false;
        private static bool invisMonke = false;
        

        private static bool ghostMonke = false;
       

       

        public static Vector3 offsetLH = Vector3.zero;
        public static Vector3 offsetRH = Vector3.zero;
        public static Vector3 offsetH = Vector3.zero;
        
        //private static Traverse minScale = null;
        //private static Traverse maxScale = null;
        public static void SizeChanger()
        {
            //Patches.SizePatch.enabled = true;
            //Patches.SizePatch.overlapSizeChanger = GameObject.Find("Environment Objects/05Maze_PersistentObjects/GuardianZoneManagers/GuardianZoneManager_Forest/GuardianSizeChanger").GetComponent<SizeChanger>();
            //if (minScale == null)
            //{
            //    minScale = Traverse.Create(Patches.SizePatch.overlapSizeChanger).Field("minScale");
            //}
            //if (maxScale == null)
            //{
            //    maxScale = Traverse.Create(Patches.SizePatch.overlapSizeChanger).Field("maxScale");
            //}
            float increment = 0.05f;
            if (!GetIndex("Disable Size Changer Buttons").enabled)
            {
                if (leftTrigger > 0.5f)
                {
                    increment = 0.2f;
                }
                if (leftGrab)
                {
                    increment = 0.01f;
                }
                if (rightTrigger > 0.5f)
                {
                    sizeScale += increment;
                }
                if (rightGrab)
                {
                    sizeScale -= increment;
                }
                if (rightPrimary)
                {
                    sizeScale = 1f;
                }
            }
            if (sizeScale < 0.05f)
            {
                sizeScale = 0.05f;
            }
            GorillaLocomotion.Player.Instance.scale = sizeScale;
            GorillaTagger.Instance.offlineVRRig.scaleFactor = sizeScale;
            //minScale.SetValue(sizeScale);
            //maxScale.SetValue(sizeScale);
        }

        public static void DisableSizeChanger()
        {
            //Patches.SizePatch.enabled =  false;
            //Traverse.Create(Patches.SizePatch.overlapSizeChanger).Field("minScale").SetValue(3f);
            //Traverse.Create(Patches.SizePatch.overlapSizeChanger).Field("maxScale").SetValue(3f);
            sizeScale = 1f;
            GorillaLocomotion.Player.Instance.scale = sizeScale;
            GorillaTagger.Instance.offlineVRRig.scaleFactor = sizeScale;
        }

        public static void EnableSlipperyHands()
        {
            EverythingSlippery = true;
        }

        public static void DisableSlipperyHands()
        {
            EverythingSlippery = false;
        }

        public static void EnableGrippyHands()
        {
            EverythingGrippy = true;
        }

        public static void DisableGrippyHands()
        {
            EverythingGrippy = false;
        }

        public static GameObject stickpart = null;
        public static void StickyHands()
        {
            if (stickpart == null)
            {
                stickpart = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                FixStickyColliders(stickpart);
                stickpart.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                stickpart.GetComponent<Renderer>().enabled = false;
            }
            if (Time.time > partDelay)
            {
                if (GorillaLocomotion.Player.Instance.wasLeftHandTouching)
                {
                    stickpart.transform.position = TrueLeftHand().position;
                    //partDelay = Time.time + 0.1f;
                }
                if (GorillaLocomotion.Player.Instance.wasRightHandTouching)
                {
                    stickpart.transform.position = TrueRightHand().position;
                    //partDelay = Time.time + 0.1f;
                }
                if (GorillaLocomotion.Player.Instance.wasLeftHandTouching && GorillaLocomotion.Player.Instance.wasRightHandTouching)
                {
                    stickpart.transform.position = Vector3.zero;
                    //partDelay = Time.time;
                }
            }
        }

        public static void DisableStickyHands()
        {
            if (stickpart != null)
            {
                UnityEngine.Object.Destroy(stickpart);
                stickpart = null;
            }
        }

        private static bool leftisclimbing = false;
        private static bool rightisclimbing = false;
        private static GameObject climb = null;
        public static void ClimbyHands()
        {
            if (climb == null)
            {
                climb = new GameObject("GR");
                climb.AddComponent<GorillaClimbable>();
            }
            if (leftGrab)
            {
                if (GorillaLocomotion.Player.Instance.wasLeftHandTouching && !leftisclimbing)
                {
                    climb.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    leftisclimbing = true;
                    GorillaLocomotion.Player.Instance.BeginClimbing(climb.AddComponent<GorillaClimbable>(), GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/GorillaHandClimber").GetComponent<GorillaHandClimber>());
                }
            } else
            {
                leftisclimbing = false;
            }
            if (rightGrab)
            {
                if (GorillaLocomotion.Player.Instance.wasRightHandTouching && !rightisclimbing)
                {
                    climb.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    rightisclimbing = true;
                    GorillaLocomotion.Player.Instance.BeginClimbing(climb.AddComponent<GorillaClimbable>(), GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/RightHand Controller/GorillaHandClimber").GetComponent<GorillaHandClimber>());
                }
            }
            else
            {
                rightisclimbing = false;
            }
        }

        public static void DisableClimbyHands()
        {
            if (climb != null)
            {
                UnityEngine.Object.Destroy(climb);
                climb = null;
            }
        }

        

        public static Vector3[] lastLeft = new Vector3[] { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };
        public static Vector3[] lastRight = new Vector3[] { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };

        public static void PunchMod()
        {
            int index = -1;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    index++;

                    Vector3 they = vrrig.rightHandTransform.position;
                    Vector3 notthem = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
                    float distance = Vector3.Distance(they, notthem);

                    if (distance < 0.25f)
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(vrrig.rightHandTransform.position - lastRight[index]) * 10f;
                    }
                    lastRight[index] = vrrig.rightHandTransform.position;

                    they = vrrig.leftHandTransform.position;
                    distance = Vector3.Distance(they, notthem);

                    if (distance < 0.25f)
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(vrrig.leftHandTransform.position - lastLeft[index]) * 10f;
                    }
                    lastLeft[index] = vrrig.leftHandTransform.position;
                }
            }
        }

        private static VRRig sithlord = null;
        private static bool sithright = false;
        private static float sithdist = 1f;
        public static void Telekinesis()
        {
            if (sithlord == null)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    try
                    {
                        if (vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            if (vrrig.rightIndex.calcT < 0.5f && vrrig.rightMiddle.calcT > 0.5f)
                            {
                                Vector3 dir = vrrig.transform.Find("RigAnchor/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").up;
                                Physics.SphereCast(vrrig.rightHandTransform.position + (dir * 0.1f), 0.3f, dir, out var Ray, 512f, NoInvisLayerMask());
                                {
                                    VRRig possibly = Ray.collider.GetComponentInParent<VRRig>();
                                    if (possibly && possibly == GorillaTagger.Instance.offlineVRRig)
                                    {
                                        sithlord = vrrig;
                                        sithright = true;
                                        sithdist = Ray.distance;
                                    }
                                }
                            }
                            if (vrrig.leftIndex.calcT < 0.5f && vrrig.leftMiddle.calcT > 0.5f)
                            {
                                Vector3 dir = vrrig.transform.Find("RigAnchor/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L").up;
                                Physics.SphereCast(vrrig.leftHandTransform.position + (dir * 0.1f), 0.3f, dir, out var Ray, 512f, NoInvisLayerMask());
                                {
                                    VRRig possibly = Ray.collider.GetComponentInParent<VRRig>();
                                    if (possibly && possibly == GorillaTagger.Instance.offlineVRRig)
                                    {
                                        sithlord = vrrig;
                                        sithright = false;
                                        sithdist = Ray.distance;
                                    }
                                }
                            }
                        }
                    } catch { }
                }
            } else
            {
                if (sithright ? (sithlord.rightIndex.calcT < 0.5f && sithlord.rightMiddle.calcT > 0.5f) : (sithlord.leftMiddle.calcT < 0.5f && sithlord.leftMiddle.calcT > 0.5f))
                {
                    Transform hand = sithright ? sithlord.rightHandTransform : sithlord.leftHandTransform;
                    Vector3 dir = sithright ? sithlord.transform.Find("RigAnchor/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").up : sithlord.transform.Find("RigAnchor/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L").up;
                    TeleportPlayer(Vector3.Lerp(GorillaTagger.Instance.bodyCollider.transform.position, hand.position + dir * sithdist, 0.1f));
                    GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    ZeroGravity();
                } else
                {
                    sithlord = null;
                }
            }
        }

        


        public static GameObject leftThrow = null;
        public static GameObject rightThrow = null;
      

      
        private static float preBounciness = 0f;
        private static PhysicMaterialCombine whateverthisis = PhysicMaterialCombine.Maximum;
        private static float preFrictiness = 0f;

        public static void PreBouncy()
        {
            preBounciness = GorillaTagger.Instance.bodyCollider.material.bounciness;
            whateverthisis = GorillaTagger.Instance.bodyCollider.material.bounceCombine;
            preFrictiness = GorillaTagger.Instance.bodyCollider.material.dynamicFriction;
        }

        public static void Bouncy()
        {
            GorillaTagger.Instance.bodyCollider.material.bounciness = 1f;
            GorillaTagger.Instance.bodyCollider.material.bounceCombine = PhysicMaterialCombine.Maximum;
            GorillaTagger.Instance.bodyCollider.material.dynamicFriction = 0f;
        }

        public static void PostBouncy()
        {
            GorillaTagger.Instance.bodyCollider.material.bounciness = preBounciness;
            GorillaTagger.Instance.bodyCollider.material.bounceCombine = whateverthisis;
            GorillaTagger.Instance.bodyCollider.material.dynamicFriction = preFrictiness;
        }

        public static List<ForceVolume> fvol = new List<ForceVolume> { };

    }
}
