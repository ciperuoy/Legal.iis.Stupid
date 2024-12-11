using LegallyStupid.Classes;
using LegallyStupid.Mods;
using LegallyStupid.Notifications;
using UnityEngine;
using static LegallyStupid.Menu.Main;

namespace LegallyStupid.Menu
{
    public class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Stuff [0]
                new ButtonInfo { buttonText = "Settings", method =() => Settings.EnableSettings(), isTogglable = false, toolTip = "Opens the settings menu."},
                new ButtonInfo { buttonText = "Favorite Mods", method =() => Settings.EnableFavorites(), isTogglable = false, toolTip = "Opens your favorite mods. Favorite mods with left grip."},
                new ButtonInfo { buttonText = "Enabled Mods", method =() => Settings.EnableEnabled(), isTogglable = false, toolTip = "Shows all mods you have enabled."},
               
                new ButtonInfo { buttonText = "Movement Mods", method =() => Settings.EnableMovement(), isTogglable = false, toolTip = "Opens the movement mods."},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Exit Settings", method =() => Settings.ReturnToMain(), isTogglable = false, toolTip = "Returns you back to the main page."},
                new ButtonInfo { buttonText = "Menu Settings", method =() => Settings.EnableMenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement Settings", method =() => Settings.EnableMovementSettings(), isTogglable = false, toolTip = "Opens the settings for the movement mods."},
                new ButtonInfo { buttonText = "Visual Settings", method =() => Settings.EnableVisualSettings(), isTogglable = false, toolTip = "Opens the settings for the visual mods."},
            },

            new ButtonInfo[] { // Menu (in Settings) [2]
                new ButtonInfo { buttonText = "Exit Menu Settings", method =() => Settings.EnableSettings(), isTogglable = false, toolTip = "Returns you back to the settings menu."},

                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => Settings.RightHand(), disableMethod =() => Settings.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Both Hands", enableMethod =() => Settings.BothHandsOn(), disableMethod =() => Settings.BothHandsOff(), toolTip = "Puts the menu on your both of your hands."},
                new ButtonInfo { buttonText = "One Handed Menu", enableMethod =() => Settings.BarkMenuOn(), disableMethod =() => Settings.BarkMenuOff(), toolTip = "Makes the menu open in front of you, so you can use it with one hand."},
                new ButtonInfo { buttonText = "Joystick Menu", enableMethod =() => Settings.JoystickMenuOn(), disableMethod =() => Settings.JoystickMenuOff(), toolTip = "Makes the menu like Colossal, click your joysticks to open, joysticks to move between mods and pages, and click your left joystick to toggle a mod."},
                new ButtonInfo { buttonText = "Inner Outline Menu", toolTip = "Gives the menu an outline on the inside."},
                new ButtonInfo { buttonText = "Outline Menu", enableMethod =() => Settings.OutlineMenuOn(), disableMethod =() => Settings.OutlineMenuOff(), toolTip = "Gives the menu objects an outline."},
                new ButtonInfo { buttonText = "Wrist Menu", enableMethod =() => Settings.WristThingOn(), disableMethod =() => Settings.WristThingOff(), toolTip = "Makes the menu like a weird wrist watch, click your hand to open it."},
                new ButtonInfo { buttonText = "Watch Menu", enableMethod =() => Settings.WatchMenuOn(), disableMethod =() => Settings.WatchMenuOff(), toolTip = "Makes the menu like pocket watch, click your joystick to toggle, and move your joystick to select a mod."},
                new ButtonInfo { buttonText = "Shiny Menu", enableMethod =() => Settings.ShinyMenu(), disableMethod =() => Settings.NoShinyMenu(), toolTip = "Makes the menu's textures use the old shader."},
                new ButtonInfo { buttonText = "Thick Menu", enableMethod =() => Settings.ThinMenuOn(), disableMethod =() => Settings.ThinMenuOff(), toolTip = "Makes the menu thin."},
                new ButtonInfo { buttonText = "Long Menu", enableMethod =() => Settings.LongMenuOn(), disableMethod =() => Settings.LongMenuOff(), toolTip = "Makes the menu long."},
                new ButtonInfo { buttonText = "Flip Menu", enableMethod =() => Settings.FlipMenu(), disableMethod =() => Settings.NonFlippedMenu(), toolTip = "Flips the menu to the back of your hand."},
                new ButtonInfo { buttonText = "Change Menu Language", overlapText = "Change Menu Language <color=grey>[</color><color=green>English</color><color=grey>]</color>", method =() => Settings.ChangeMenuLanguage(), isTogglable = false, toolTip = "Changes the language of the menu."},
                new ButtonInfo { buttonText = "Zero Gravity Menu", toolTip = "Disables gravity on the menu when dropping it."},
               
                new ButtonInfo { buttonText = "Alphabetize Menu", toolTip = "Alphabetizes the entire menu."},
                new ButtonInfo { buttonText = "Custom Menu Name", enableMethod =() => Settings.CustomMenuName(), disableMethod =() => Settings.NoCustomMenuName(), toolTip = "Changes the name of the menu to whatever. You can change the text inside of your Gorilla Tag files (iisStupidMenu/iiMenu_CustomMenuName.txt)."},
                new ButtonInfo { buttonText = "Dynamic Animations", enableMethod =() => Settings.DynamicAnimations(), disableMethod =() => Settings.NoDynamicAnimations(), toolTip = "Adds more animations to the menu, giving you a better sense of control."},
                new ButtonInfo { buttonText = "Dynamic Sounds", enableMethod =() => Settings.DynamicSounds(), disableMethod =() => Settings.NoDynamicSounds(), toolTip = "Adds more sounds to the menu, giving you a better sense of control."},
                new ButtonInfo { buttonText = "Voice Commands", enableMethod =() => Settings.VoiceRecognitionOn(), disableMethod =() => Settings.VoiceRecognitionOff(), toolTip = "Enable and disable sounds with your voice. Activate it like how you would any other voice assistant, like \"Jarvis\"."},
                new ButtonInfo { buttonText = "Chain Voice Commands", toolTip = "Makes voice commands chain together, so you don't have to repeatedly ask it to listen to you."},
                new ButtonInfo { buttonText = "Annoying Mode", enableMethod =() => Settings.AnnoyingModeOn(), disableMethod =() => Settings.AnnoyingModeOff(), toolTip = "Turns on the April Fools 2024 settings."},
                new ButtonInfo { buttonText = "Lowercase Mode", enableMethod =() => Settings.LowercaseMode(), disableMethod =() => Settings.NoLowercaseMode(), toolTip = "Makes the entire menu's text lowercase."},
                new ButtonInfo { buttonText = "Overflow Mode", enableMethod =() => Settings.OverflowMode(), disableMethod =() => Settings.NoOverflowMode(), toolTip = "Makes the entire menu's text overflow."},
                new ButtonInfo { buttonText = "Change Menu Theme", method =() => Settings.ChangeMenuTheme(), isTogglable = false, toolTip = "Changes the theme of the menu."},
                new ButtonInfo { buttonText = "Custom Menu Theme", enableMethod =() => Settings.CustomMenuTheme(), disableMethod =() => Settings.FixTheme(), toolTip = "Changes the theme of the menu to a custom one."},
                new ButtonInfo { buttonText = "Change Custom Menu Theme", method =() => Settings.ChangeCustomMenuTheme(), isTogglable = false, toolTip = "Changes the theme of custom the menu."},
                new ButtonInfo { buttonText = "Custom Menu Background", enableMethod =() => Settings.CustomMenuBackground(), disableMethod =() => Settings.FixMenuBackground(), toolTip = "Changes the background of the menu to a custom image. You can change the photo inside of your Gorilla Tag File (iisStupidMenu/iiMenu_CustomMenuBackground.txt)."},
                new ButtonInfo { buttonText = "Change Page Type", method =() => Settings.ChangePageType(), isTogglable = false, toolTip = "Changes the type of page buttons."},
                new ButtonInfo { buttonText = "Change Arrow Type", method =() => Settings.ChangeArrowType(), isTogglable = false, toolTip = "Changes the type of arrows on the page buttons."},
                new ButtonInfo { buttonText = "Change Font Type", method =() => Settings.ChangeFontType(), isTogglable = false, toolTip = "Changes the type of font."},
                new ButtonInfo { buttonText = "Change Font Style Type", method =() => Settings.ChangeFontStyleType(), isTogglable = false, toolTip = "Changes the style of the font."},
                new ButtonInfo { buttonText = "Change Notification Time", overlapText = "Change Notification Time <color=grey>[</color><color=green>1</color><color=grey>]</color>", method =() => Settings.ChangeNotificationTime(), isTogglable = false, toolTip = "Changes the time before a notification is removed."},
                new ButtonInfo { buttonText = "Change Pointer Position", method =() => Settings.ChangePointerPosition(), isTogglable = false, toolTip = "Changes the position of the pointer."},
                new ButtonInfo { buttonText = "Swap GUI Colors", toolTip = "Swaps the GUI colors to the enabled color, for darker themes."},
                new ButtonInfo { buttonText = "Checkbox Buttons", enableMethod =() => Settings.CheckboxButtons(), disableMethod =() => Settings.CheckboxButtonsOff(), toolTip = "Makes the buttons like checkboxes."},
                new ButtonInfo { buttonText = "cbsound", overlapText  = "Change Button Sound <color=grey>[</color><color=green>Wood</color><color=grey>]</color>", method =() => Settings.ChangeButtonSound(), isTogglable = false, toolTip = "Changes the button click sound."},
                new ButtonInfo { buttonText = "cbvol", overlapText  = "Change Button Volume <color=grey>[</color><color=green>4</color><color=grey>]</color>", method =() => Settings.ChangeButtonVolume(), isTogglable = false, toolTip = "Changes the volume of the buttons."},
                new ButtonInfo { buttonText = "Clear Notifications on Disconnect", toolTip = "Clears all notifications on disconnect."},
                new ButtonInfo { buttonText = "Hide Notifications on Camera", toolTip = "Makes notifications only render in VR."},
                new ButtonInfo { buttonText = "Disable Notifications", enableMethod =() => Settings.DisableNotifications(), disableMethod =() => Settings.EnableNotifications(), toolTip = "Disables all notifications."},
                new ButtonInfo { buttonText = "Disable Enabled GUI", overlapText = "Disable Arraylist GUI", enableMethod =() => Settings.DisableEnabledGUI(), disableMethod =() => Settings.EnableEnabledGUI(), toolTip = "Disables the GUI that shows the enabled mods."},
                new ButtonInfo { buttonText = "Disable Disconnect Button", enableMethod =() => Settings.DisableDisconnectButton(), disableMethod =() => Settings.EnableDisconnectButton(), toolTip = "Disables the disconnect button at the top of the menu."},
                new ButtonInfo { buttonText = "Disable Search Button", enableMethod =() => Settings.DisableSearchButton(), disableMethod =() => Settings.EnableSearchButton(), toolTip = "Disables the search button at the bottom of the menu."},
                new ButtonInfo { buttonText = "Disable Return Button", enableMethod =() => Settings.DisableReturnButton(), disableMethod =() => Settings.EnableReturnButton(), toolTip = "Disables the return button at the bottom of the menu."},
                new ButtonInfo { buttonText = "Disable Page Buttons", enableMethod =() => Settings.DisablePageButtons(), disableMethod =() => Settings.EnablePageButtons(), toolTip = "Disables the page buttons. Recommended with Joystick Menu."},
                new ButtonInfo { buttonText = "Disable Page Number", enableMethod =() => Settings.DisablePageText(), disableMethod =() => Settings.EnablePageText(), toolTip = "Disables the current page number in the title text."},
                new ButtonInfo { buttonText = "Disable FPS Counter", enableMethod =() => Settings.DisableFPSCounter(), disableMethod =() => Settings.EnableFPSCounter(), toolTip = "Disables the FPS counter."},
                new ButtonInfo { buttonText = "Disable Drop Menu", enableMethod =() => Settings.DropMenu(), disableMethod =() => Settings.DropMenuOff(), toolTip = "Makes the menu despawn instead of falling."},
                new ButtonInfo { buttonText = "Disable Board Colors", overlapText = "Disable Custom Boards", enableMethod =() => Settings.DisableBoardColors(), disableMethod =() => Settings.EnableBoardColors(), toolTip = "Disables the board colors to look legitimate on screen share."},
                new ButtonInfo { buttonText = "Disable Custom Text Colors", enableMethod =() => Settings.DisableBoardTextColors(), disableMethod =() => Settings.EnableBoardTextColors(), toolTip = "Disables the text colors to look like how it used to."},
                new ButtonInfo { buttonText = "Hide Text on Camera", toolTip = "Makes the menu's text only render on VR."},
                new ButtonInfo { buttonText = "No Global Search", enableMethod =() => Settings.NoGlobalSearch(), disableMethod =() => Settings.PleaseGlobalSearch(), toolTip = "Makes the search button only search for mods in the current subcategory, unless on the main page."},
                new ButtonInfo { buttonText = "Disable Autosave", enableMethod =() => Settings.SavePreferences(), method =() => Settings.NoAutoSave(), toolTip = "Disables the auto save mechanism."},
                new ButtonInfo { buttonText = "Panic", method =() => Settings.Panic(), isTogglable = false, toolTip = "Disables every single active mod."},
            },


            new ButtonInfo[] { // Movement (in Settings) [3]
                new ButtonInfo { buttonText = "Exit Movement Settings", method =() => Settings.EnableSettings(), isTogglable = false, toolTip = "Returns you back to the settings menu."},

                new ButtonInfo { buttonText = "Change Platform Type", overlapText = "Change Platform Type <color=grey>[</color><color=green>Normal</color><color=grey>]</color>", method =() => Movement.ChangePlatformType(), isTogglable = false, toolTip = "Changes the type of the platforms."},
                new ButtonInfo { buttonText = "Change Platform Shape", overlapText = "Change Platform Shape <color=grey>[</color><color=green>Sphere</color><color=grey>]</color>", method =() => Movement.ChangePlatformShape(), isTogglable = false, toolTip = "Changes the shape of the platforms."},
                new ButtonInfo { buttonText = "Platform Gravity", toolTip = "Makes platforms fall instead of instantly deleting them."},
                new ButtonInfo { buttonText = "Platform Outlines", toolTip = "Makes platforms have outlines."},
                new ButtonInfo { buttonText = "Change Fly Speed", overlapText = "Change Fly Speed <color=grey>[</color><color=green>Normal</color><color=grey>]</color>", method =() => Movement.ChangeFlySpeed(), isTogglable = false, toolTip = "Changes the speed of the fly mods, including iron man."},
                new ButtonInfo { buttonText = "Change Speed Boost Amount", overlapText = "Change Speed Boost Amount <color=grey>[</color><color=green>Normal</color><color=grey>]</color>", method =() => Movement.ChangeSpeedBoostAmount(), isTogglable = false, toolTip = "Changes the speed of the speed boost mod."},
                new ButtonInfo { buttonText = "Factored Speed Boost", toolTip = "Factors your current speed into the speed boost, giving you a positive effect even if you're tagged."},
                new ButtonInfo { buttonText = "Disable Max Speed Modification", toolTip = "Makes your max speed not change, so you can't be detected of using a speed boost."},
                new ButtonInfo { buttonText = "Disable Size Changer Buttons", toolTip = "Disables the size changer's buttons, so hitting grip or trigger or whatever won't do anything."},

            },

          

            new ButtonInfo[] { // Important Mods [4]
                new ButtonInfo { buttonText = "Exit Important Mods", method =() => Settings.ReturnToMain(), isTogglable = false, toolTip = "Returns you back to the main page."},

                new ButtonInfo { buttonText = "Exit Gorilla Tag", method =() => Application.Quit(), isTogglable = false, toolTip = "Closes Gorilla Tag."},
                
                new ButtonInfo { buttonText = "Clear Notifications", method =() => NotifiLib.ClearAllNotifications(), isTogglable = false, toolTip = "Clears your notifications. Good for when they get stuck."},
            },


            new ButtonInfo[] { // Movement Mods [5]
                new ButtonInfo { buttonText = "Exit Movement Mods", method =() => Settings.ReturnToMain(), isTogglable = false, toolTip = "Returns you back to the main page."},

                new ButtonInfo { buttonText = "Platforms", method =() => Movement.Platforms(), toolTip = "Platforms, they do not show for other players."},
                new ButtonInfo { buttonText = "Trigger Platforms", method =() => Movement.TriggerPlatforms(), toolTip = "Platforms, they do not show for other players."},
                new ButtonInfo { buttonText = "Frozone", method =() => Movement.Frozone(), toolTip = "Spawns slippery blocks under your hands using <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Fly <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.Fly(), toolTip = "Sends your character forwards when holding <color=green>A</color>."},
                new ButtonInfo { buttonText = "Trigger Fly <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Movement.TriggerFly(), toolTip = "Sends your character forwards when holding <color=green>trigger</color>."},
                new ButtonInfo { buttonText = "Noclip Fly <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.NoclipFly(), toolTip = "Sends your character forwards and makes you go through objects when holding <color=green>A</color>."},
                new ButtonInfo { buttonText = "Joystick Fly <color=grey>[</color><color=green>J</color><color=grey>]</color>", method =() => Movement.JoystickFly(), toolTip = "Sends your character in whatever direction you are pointing your <color=green>joystick</color> in."},
                new ButtonInfo { buttonText = "Bark Fly <color=grey>[</color><color=green>J</color><color=grey>]</color>", method =() => Movement.BarkFly(), toolTip = "Acts like the fly that Bark has. Credits to KyleTheScientist."},
                new ButtonInfo { buttonText = "Hand Fly <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.HandFly(), toolTip = "Sends your character in your hand's direction when holding <color=green>A</color>."},
                new ButtonInfo { buttonText = "Iron Man", method =() => Movement.IronMan(), toolTip = "Turns you into iron man, rotate your hands around to change direction."},
                new ButtonInfo { buttonText = "Spider Man", method =() => Movement.SpiderMan(), disableMethod =() => Movement.DisableSpiderMan(), toolTip = "Turns you into spider man, use your <color=green>grips</color> to shoot webs."},
                new ButtonInfo { buttonText = "Grappling Hooks", method =() => Movement.GrapplingHooks(), disableMethod =() => Movement.DisableSpiderMan(), toolTip = "Gives you grappling hooks, use your <color=green>grips</color> to shoot them."},
                new ButtonInfo { buttonText = "Noclip <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Movement.Noclip(), toolTip = "Makes you go through objects when holding <color=green>trigger</color>."},
                new ButtonInfo { buttonText = "Size Changer", method =() => Movement.SizeChanger(), enableMethod =() => Movement.DisableSizeChanger(), disableMethod =() => Movement.DisableSizeChanger(), toolTip = "Increase your size by holding <color=green>trigger</color>, and decrease your size by holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Zero Gravity", method =() => Movement.ZeroGravity(), toolTip = "Disables gravity on your character."},
                new ButtonInfo { buttonText = "Weak Wall Walk <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Movement.WeakWallWalk(), toolTip = "Makes you get brought towards any wall you touch when holding <color=green>grip</color>, but weaker."},
                new ButtonInfo { buttonText = "Wall Walk <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Movement.WallWalk(), toolTip = "Makes you get brought towards any wall you touch when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Strong Wall Walk <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Movement.StrongWallWalk(), toolTip = "Makes you get brought towards any wall you touch when holding <color=green>grip</color>, but stronger."},
                new ButtonInfo { buttonText = "Teleport Gun", method =() => Movement.TeleportGun(), toolTip = "Teleports to wherever your hand desires."},
                new ButtonInfo { buttonText = "Checkpoint <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Movement.Checkpoint(), disableMethod =() => Movement.DisableCheckpoint(), toolTip = "Place a checkpoint with <color=green>grip</color> and teleport to it with <color=green>A</color>."},
                new ButtonInfo { buttonText = "Ender Pearl <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Movement.EnderPearl(), disableMethod =() => Movement.DestroyEnderPearl(), toolTip = "Gives you a throwable ender pearl when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Punch Mod", method =() => Movement.PunchMod(), toolTip = "Lets people punch you across the map."},
                new ButtonInfo { buttonText = "Telekinesis", method =() => Movement.Telekinesis(), toolTip = "Lets people control you with nothing but the power of their finger."},
                new ButtonInfo { buttonText = "Speed Boost", method =() => Movement.SpeedBoost(), toolTip = "Changes your speed to whatever you set it to."},
                new ButtonInfo { buttonText = "Grip Speed Boost <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Movement.GripSpeedBoost(), /*disableMethod =() => Movement.DisableSpeedBoost(),*/ toolTip = "Changes your speed to whatever you set it to when holding <color=green>grip</color>."},
                new ButtonInfo { buttonText = "Joystick Speed Boost <color=grey>[</color><color=green>J</color><color=grey>]</color>", method =() => Movement.JoystickSpeedBoost(), /*disableMethod =() => Movement.DisableSpeedBoost(),*/ toolTip = "Changes your speed to whatever you set it to when holding <color=green>joystick</color>."},
                new ButtonInfo { buttonText = "Slippery Hands", enableMethod =() => Movement.EnableSlipperyHands(), disableMethod =() => Movement.DisableSlipperyHands(), toolTip = "Makes everything ice, as in extremely slippery."},
                new ButtonInfo { buttonText = "Grippy Hands", enableMethod =() => Movement.EnableGrippyHands(), disableMethod =() => Movement.DisableGrippyHands(), toolTip = "Covers your hands in grip tape, letting you wallrun as high as you want."},
                new ButtonInfo { buttonText = "Sticky Hands", method =() => Movement.StickyHands(), disableMethod =() => Movement.DisableStickyHands(), toolTip = "Makes your hands really sticky."},
                new ButtonInfo { buttonText = "Climby Hands", method =() => Movement.ClimbyHands(), disableMethod =() => Movement.DisableClimbyHands(), toolTip = "Lets you climb everything like a rope."},
                new ButtonInfo { buttonText = "Bouncy", enableMethod =() => Movement.PreBouncy(), method =() => Movement.Bouncy(), disableMethod =() => Movement.PostBouncy(), toolTip = "Makes you really bouncy when on the ground."},
            },


            new ButtonInfo[] { // Visual Mods [6]
                new ButtonInfo { buttonText = "Exit Visual Mods", method =() => Settings.ReturnToMain(), isTogglable = false, toolTip = "Returns you back to the main page."},
                new ButtonInfo { buttonText = "Remove Leaves", enableMethod =() => Visuals.EnableRemoveLeaves(), disableMethod =() => Visuals.DisableRemoveLeaves(), toolTip = "Removes leaves on trees, good for branching."},
                new ButtonInfo { buttonText = "Casual Tracers", method =() => Visuals.CasualTracers(), toolTip = "Puts tracers on your right hand. Shows untagged when tagged, vice versa."},
                new ButtonInfo { buttonText = "Infection Tracers", method =() => Visuals.InfectionTracers(), toolTip = "Puts tracers on your right hand. Shows everyone."},
                new ButtonInfo { buttonText = "Hunt Tracers", method =() => Visuals.HuntTracers(), toolTip = "Puts tracers on your right hand. Shows your target and who is hunting you."},
                new ButtonInfo { buttonText = "Casual Box ESP", method =() => Visuals.CasualBoxESP(), toolTip = "Acts like casual tracers color wise, but with boxes."},
                new ButtonInfo { buttonText = "Infection Box ESP", method =() => Visuals.InfectionBoxESP(), toolTip = "Acts like infection tracers color wise, but with boxes."},
                new ButtonInfo { buttonText = "Hunt Box ESP", method =() => Visuals.HuntBoxESP(), toolTip = "Acts like hunt tracers color wise, but with boxes."},
                new ButtonInfo { buttonText = "Casual Hollow Box ESP", method =() => Visuals.CasualHollowBoxESP(), toolTip = "Acts like casual box ESP, except the box is hollow."},
                new ButtonInfo { buttonText = "Infection Hollow Box ESP", method =() => Visuals.HollowInfectionBoxESP(), toolTip = "Acts like infection box ESP, except the box is hollow."},
                new ButtonInfo { buttonText = "Hunt Hollow Box ESP", method =() => Visuals.HollowHuntBoxESP(), toolTip = "Acts like hunt box ESP, except the box is hollow."},
                new ButtonInfo { buttonText = "Casual Breadcrumbs", method =() => Visuals.CasualBreadcrumbs(), toolTip = "Acts like casual tracers color wise, but with breadcrumbs."},
                new ButtonInfo { buttonText = "Infection Breadcrumbs", method =() => Visuals.InfectionBreadcrumbs(), toolTip = "Acts like infection tracers color wise, but with breadcrumbs."},
                new ButtonInfo { buttonText = "Hunt Breadcrumbs", method =() => Visuals.HuntBreadcrumbs(), toolTip = "Acts like hunt tracers color wise, but with breadcrumbs."},
                new ButtonInfo { buttonText = "Casual Bone ESP", method =() => Visuals.CasualBoneESP(), toolTip = "Acts like casual tracers color wise, but with bones."},
                new ButtonInfo { buttonText = "Infection Bone ESP", method =() => Visuals.InfectionBoneESP(), toolTip = "Acts like infection tracers color wise, but with bones."},
                new ButtonInfo { buttonText = "Hunt Bone ESP", method =() => Visuals.HuntBoneESP(), toolTip = "Acts like hunt tracers color wise, but with bones."},
                new ButtonInfo { buttonText = "Casual Chams", method =() => Visuals.CasualChams(), disableMethod =() => Visuals.DisableChams(), toolTip = "Acts like casual tracers color wise, but lets you see their fur through walls."},
                new ButtonInfo { buttonText = "Infection Chams", method =() => Visuals.InfectionChams(), disableMethod =() => Visuals.DisableChams(), toolTip = "Acts like infection tracers color wise, but lets you see their fur through walls."},
                new ButtonInfo { buttonText = "Hunt Chams", method =() => Visuals.HuntChams(), disableMethod =() => Visuals.DisableChams(), toolTip = "Acts like hunt tracers color wise, but lets you see their fur through walls."},
                new ButtonInfo { buttonText = "Casual Beacons", method =() => Visuals.CasualBeacons(), toolTip = "Acts like casual tracers color wise, but it's just a giant line."},
                new ButtonInfo { buttonText = "Infection Beacons", method =() => Visuals.InfectionBeacons(), toolTip = "Acts like infection tracers color wise, but it's just a giant line."},
                new ButtonInfo { buttonText = "Hunt Beacons", method =() => Visuals.HuntBeacons(), toolTip = "Acts like hunt tracers color wise, but it's just a giant line."},
                new ButtonInfo { buttonText = "Casual Distance ESP", method =() => Visuals.CasualDistanceESP(), toolTip = "Shows your distance from players."},
                new ButtonInfo { buttonText = "Infection Distance ESP", method =() => Visuals.InfectionDistanceESP(), toolTip = "Acts like infection tracers color wise, but with text."},
                new ButtonInfo { buttonText = "Hunt Distance ESP", method =() => Visuals.HuntDistanceESP(), toolTip = "Acts like infection tracers color wise, but with text."},
            },


            


            new ButtonInfo[] { // Favorite Mods [7]
                new ButtonInfo { buttonText = "Exit Favorite Mods", method =() => Settings.ReturnToMain(), isTogglable = false, toolTip = "Returns you back to the main page."},
            },

            new ButtonInfo[] { // Visual (in Settings) [8]
                new ButtonInfo { buttonText = "Exit Visual Settings", method =() => Settings.EnableSettings(), isTogglable = false, toolTip = "Returns you back to the settings menu."},

                new ButtonInfo { buttonText = "Follow Menu Theme", toolTip = "Makes visual mods match the theme of the menu, rather than the color of the player."},
                new ButtonInfo { buttonText = "Transparent Theme", toolTip = "Makes visual mods transparent."},
                new ButtonInfo { buttonText = "Hidden on Camera", toolTip = "Makes visual mods only render on VR."},
                new ButtonInfo { buttonText = "Hidden Labels", toolTip = "Makes label mods only render on VR."},
                new ButtonInfo { buttonText = "Thin Tracers", toolTip = "Makes tracers thinner."},
            },

            new ButtonInfo[] { // Enabled Mods [9]
                new ButtonInfo { buttonText = "Exit Enabled Mods", method =() => Settings.ReturnToMain(), isTogglable = false, toolTip = "Returns you back to the main page."},
            },

            new ButtonInfo[] { // Internal Mods (hidden from user) [10]
                new ButtonInfo { buttonText = "Search", method =() => Settings.Search(), isTogglable = false, toolTip = "Lets you search for specific mods."},
                new ButtonInfo { buttonText = "Global Return", method =() => Settings.GlobalReturn(), isTogglable = false, toolTip = "Returns you to the main page."}
            },

         
            new ButtonInfo[] { // Temporary Category [11]

            },

       
        };
    }
}

/*
The mod cemetary
Every mod listed below has been removed from the menu, for one reason or another

new ButtonInfo { buttonText = "Crash Amount", overlapText = "Crash Amount <color=grey>[</color><color=green>2</color><color=grey>]</color>", method =() => Settings.CrashAmount(), isTogglable = false, toolTip = "Changes the amount of projectiles the crash mods send."},
new ButtonInfo { buttonText = "Projectile Gun", method =() => Projectiles.ProjectileGun(), toolTip = "Acts like the projectile spam, but the projectiles only show up for you and whoever your hand desires." },

new ButtonInfo { buttonText = "Anti Ban", overlapText = "Anti Ban <color=grey>[</color><color=red>Risky</color><color=grey>]</color>", method =() => Overpowered.AntiBan(), isTogglable = false, toolTip = "Prevents you from getting banned. This mod is very experimental, if you get banned, I take ZERO responsibility."},
new ButtonInfo { buttonText = "Anti Ban Check", method =() => Overpowered.AntiBanCheck(), isTogglable = false, toolTip = "Tests if the the room is modded or not."},

new ButtonInfo { buttonText = "Set Master", overlapText = "Set Master <color=grey>[</color><color=red>Risky</color><color=grey>]</color>", method =() => Overpowered.FastMaster(), isTogglable = false, toolTip = "Sets you as master client."},
new ButtonInfo { buttonText = "Set Master Gun", overlapText = "Set Master Gun <color=grey>[</color><color=red>Risky</color><color=grey>]</color>", method =() => Overpowered.SetMasterGun(), toolTip = "Sets whoever your hand desires as master client."},
new ButtonInfo { buttonText = "Auto Set Master", overlapText = "Auto Set Master <color=grey>[</color><color=red>Risky</color><color=grey>]</color>", method =() => Experimental.AutoSetMaster(), toolTip = "Sets you as master client when in modded lobbies or when using the anti ban."},

new ButtonInfo { buttonText = "Infection Gamemode", method =() => Overpowered.InfectionGamemode(), isTogglable = false, toolTip = "Sets the gamemode to infection."},
new ButtonInfo { buttonText = "Casual Gamemode", method =() => Overpowered.CasualGamemode(), isTogglable = false, toolTip = "Sets the gamemode to casual."},
new ButtonInfo { buttonText = "Hunt Gamemode", method =() => Overpowered.HuntGamemode(), isTogglable = false, toolTip = "Sets the gamemode to hunt."},
new ButtonInfo { buttonText = "Battle Gamemode", method =() => Overpowered.BattleGamemode(), isTogglable = false, toolTip = "Sets the gamemode to battle."},

new ButtonInfo { buttonText = "Break Network Triggers", method =() => Overpowered.SSDisableNetworkTriggers(), isTogglable = false, toolTip = "Disables network triggers for everyone."},
new ButtonInfo { buttonText = "Trap Stump", method =() => Overpowered.TrapStump(), isTogglable = false, toolTip = "Anyone who enters the stump will be kicked."},

new ButtonInfo { buttonText = "Make Room Private", method =() => Overpowered.MakeRoomPrivate(), isTogglable = false, toolTip = "Makes the room private."},
new ButtonInfo { buttonText = "Make Room Public", method =() => Overpowered.MakeRoomPublic(), isTogglable = false, toolTip = "Makes the room private."},

new ButtonInfo { buttonText = "Lag Gun", method =() => Experimental.LagGun(), toolTip = "Lags whoever your hand desires." },
new ButtonInfo { buttonText = "Lag All <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Experimental.LagAll(), toolTip = "Lags everyone when holding <color=green>trigger</color>." },

new ButtonInfo { buttonText = "Crash Gun", method =() => Experimental.CrashGun(), toolTip = "Crashes whoever your hand desires." },
new ButtonInfo { buttonText = "Crash All <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Experimental.CrashAll(), toolTip = "Crashes everyone when holding <color=green>trigger</color>." },

new ButtonInfo { buttonText = "Change Name Gun", method =() => Experimental.ChangeNameGun(), toolTip = "Changes whoever your hand desires' name to your name. Credits to kman for creating the original method." },
new ButtonInfo { buttonText = "Change Name All <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Experimental.ChangeNameAll(), toolTip = "Changes everyone's name to your name. Credits to kman for creating the original method." },

new ButtonInfo { buttonText = "Destroy Gun", method =() => Overpowered.DestroyGun(), toolTip = "Makes new players not see whoever your hand desires." },
new ButtonInfo { buttonText = "Destroy All", method =() => Overpowered.DestroyAll(), isTogglable = false, toolTip = "Every player that joins after you will not be able to see anyone." },

new ButtonInfo { buttonText = "Acid Self", method =() => Overpowered.AcidSelf(), isTogglable = false, toolTip = "Turns you into acid." },
new ButtonInfo { buttonText = "Acid Gun", method =() => Overpowered.AcidGun(), toolTip = "Turns whoever your hand desires into acid." },
new ButtonInfo { buttonText = "Acid All", method =() => Overpowered.AcidAll(), isTogglable = false, toolTip = "Turns everyone into acid." },

new ButtonInfo { buttonText = "Lag Gun <color=grey>[</color><color=purple>Experimental</color><color=grey>]</color>", method =() => Overpowered.LagGun(), toolTip = "Lags whoever your hand desires." },
new ButtonInfo { buttonText = "Lag All <color=grey>[</color><color=purple>Experimental</color><color=grey>]</color> <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Overpowered.LagAll(), toolTip = "Lags everyone when holding <color=green>trigger</color>." },

new ButtonInfo { buttonText = "Crash Gun <color=grey>[</color><color=purple>Experimental</color><color=grey>]</color>", method =() => Overpowered.CrashGun(), toolTip = "Crashes whoever your hand desires." },
new ButtonInfo { buttonText = "Crash All <color=grey>[</color><color=purple>Experimental</color><color=grey>]</color> <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Overpowered.CrashAll(), toolTip = "Crashes everyone when holding <color=green>trigger</color>." },

new ButtonInfo { buttonText = "Unacid Self", method =() => Fun.UnacidSelf(), isTogglable = false, toolTip = "Unturns you into acid." },
new ButtonInfo { buttonText = "Unacid Gun", method =() => Fun.UnacidGun(), toolTip = "Unturns whoever your hand desires into acid." },
new ButtonInfo { buttonText = "Unacid All", method =() => Fun.UnacidAll(), isTogglable = false, toolTip = "Unturns everyone into acid." },

new ButtonInfo { buttonText = "Anti Report <color=grey>[</color><color=green>Lag</color><color=grey>]</color>", method =() => Safety.AntiReportLag(), toolTip = "Lags whoever comes near your report button."},
new ButtonInfo { buttonText = "Anti Report <color=grey>[</color><color=green>Crash</color><color=grey>]</color>", method =() => Safety.AntiReportCrash(), toolTip = "Crashes whoever comes near your report button."}

new ButtonInfo { buttonText = "Crash Gun", method =() => Overpowered.CrashGun(), toolTip = "Crashes or lags whoever your hand desires." },
new ButtonInfo { buttonText = "Crash All <color=grey>[</color><color=green>T</color><color=grey>]</color>", method =() => Overpowered.CrashAll(), toolTip = "Crashes every quest player, and lags/crashes every steam player when holding <color=green>trigger</color>" },
new ButtonInfo { buttonText = "Random Color Snowballs", enableMethod =() => Projectiles.RandomColorSnowballs(), disableMethod =() => Projectiles.NoRandomColorSnowballs(), toolTip = "Makes your snowballs random colors." },
new ButtonInfo { buttonText = "Black Snowballs", enableMethod =() => Projectiles.BlackSnowballs(), disableMethod =() => Projectiles.FixBlackSnowballs(), toolTip = "Makes your snowballs black." },

new ButtonInfo { buttonText = "Lag Gun", method =() => Overpowered.BubbleGun(), toolTip = "Spawns a massive bubble which lags whoever your hand desires." },
new ButtonInfo { buttonText = "Lag All", method =() => Overpowered.BubbleAll(), toolTip = "Spawns a massive bubble which lags everyone." },

new ButtonInfo { buttonText = "Break Bug", method =() => Fun.BreakBug(), isTogglable = false, toolTip = "Breaks the bug." },
new ButtonInfo { buttonText = "Break Bat", method =() => Fun.BreakBat(), isTogglable = false, toolTip = "Breaks the bat." },

new ButtonInfo { buttonText = "Steal Bug", method =() => Fun.StealBug(), toolTip = "Steals the bug." },
new ButtonInfo { buttonText = "Steal Bat", method =() => Fun.StealBat(), toolTip = "Steals the bat." },

new ButtonInfo { buttonText = "Spaz Voice", method =() => Fun.SpazVoice(), disableMethod =() => Fun.UnspazVoice(), toolTip = "Spazzes your voice out. Only works with monke speak on."},

new ButtonInfo { buttonText = "Acid Self", method =() => Basement.SodaSelf(), isTogglable = false, toolTip = "Turns you into soda."},
new ButtonInfo { buttonText = "Unacid Self", method =() => Basement.UnsodaSelf(), isTogglable = false, toolTip = "Turns you not into soda."},

new ButtonInfo { buttonText = "Grab Train", method =() => Fun.GrabTrain(), toolTip = "Puts the train in your hand." },
new ButtonInfo { buttonText = "Train Gun", method =() => Fun.TrainGun(), toolTip = "Moves the train to wherever your hand desires." },
new ButtonInfo { buttonText = "Destroy Train", method =() => Fun.DestroyTrain(), isTogglable = false, toolTip = "Sends the train to hell." },
new ButtonInfo { buttonText = "Slow Train", enableMethod =() => Fun.SlowTrain(), disableMethod =() => Fun.FixTrain(), toolTip = "Makes the train slower." },
new ButtonInfo { buttonText = "Fast Train", enableMethod =() => Fun.FastTrain(), disableMethod =() => Fun.FixTrain(), toolTip = "Makes the train faster." },

new ButtonInfo { buttonText = "Lava Splash Hands <color=grey>[</color><color=green>G</color><color=grey>]</color>", method =() => Fun.LavaSplashHands(), toolTip = "Splashes lava when holding <color=green>grip</color>."},
new ButtonInfo { buttonText = "Lava Splash Aura", method =() => Fun.LavaSplashAura(), toolTip = "Splashes lava around you at random positions."},
new ButtonInfo { buttonText = "Lava Splash Gun", method =() => Fun.LavaSplashGun(), toolTip = "Splashes lava wherever your hand desires."},

new ButtonInfo { buttonText = "Force Erupt Lava", method =() => Overpowered.ForceEruptLava(), isTogglable = false, toolTip = "Forcibly rises the lava." },
new ButtonInfo { buttonText = "Force Drain Lava", method =() => Overpowered.ForceUneruptLava(), isTogglable = false, toolTip = "Forcibly drains the lava." },
new ButtonInfo { buttonText = "Instant Rise Lava", method =() => Overpowered.ForceRiseLava(), isTogglable = false, toolTip = "Instantly rises the lava." },
new ButtonInfo { buttonText = "Instant Drain Lava", method =() => Overpowered.ForceDrainLava(), isTogglable = false, toolTip = "Instantly drains the lava." },
new ButtonInfo { buttonText = "Spaz Lava", method =() => Overpowered.SpazLava(), toolTip = "Spazzes out the lava." },

new ButtonInfo { buttonText = "Kill Bees", method =() => Fun.KillBees(), isTogglable = false, toolTip = "Sends the bees to hell."},
new ButtonInfo { buttonText = "Anger Bees Self", method =() => Fun.AngerBees(), isTogglable = false, toolTip = "Angers the bees on you."},
new ButtonInfo { buttonText = "Anger Bees Gun", method =() => Fun.AngerBeesGun(), toolTip = "Angers the bees wherever your hand desires."},
new ButtonInfo { buttonText = "Anger Bees All", method =() => Fun.AngerBeesAll(), toolTip = "Angers the bees on everyone."},

new ButtonInfo { buttonText = "Sting Self", method =() => Fun.StingSelf(), isTogglable = false, toolTip = "Makes the bees attack you."},
new ButtonInfo { buttonText = "Sting Gun", method =() => Fun.StingGun(), toolTip = "Makes the bees attack whoever your hand desires."},
new ButtonInfo { buttonText = "Sting All", method =() => Fun.StingAll(), toolTip = "Makes the bees attack everyone."},

new ButtonInfo { buttonText = "Remove Christmas Lights", enableMethod =() => Advantages.EnableRemoveChristmasLights(), disableMethod =() => Advantages.DisableRemoveChristmasLights(), toolTip = "Removes lights, good for walls."},
new ButtonInfo { buttonText = "Remove Winter Decorations", enableMethod =() => Advantages.EnableRemoveChristmasDecorations(), disableMethod =() => Advantages.DisableRemoveChristmasDecorations(), toolTip = "Removes snowmen and such, good for anyone but very obvious."},
new ButtonInfo { buttonText = "Projectile Bomb <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Projectiles.ProjectileBomb(), disableMethod =() => Projectiles.DisableProjectileBomb(), toolTip = "Acts like C4, but instead of launching you, it spawns 5 projectiles in random directions." },

new ButtonInfo { buttonText = "Gorilla Voice <color=grey>[</color><color=green>A</color><color=grey>]</color>", method =() => Fun.GorillaVoice(), toolTip = "Turns your voice into the gorilla voice when holding <color=green>A</color>."},
new ButtonInfo { buttonText = "Spam Eat Honey Comb", method =() => Fun.HoneycombSpam(), toolTip = "Spam eats the honey comb when holding <color=green>grip</color>."},
new ButtonInfo { buttonText = "Remove Cherry Blossoms", enableMethod = () => Visuals.EnableRemoveCherryBlossoms(), disableMethod = () => Visuals.DisableRemoveCherryBlossoms(), toolTip = "Removes cherry blossoms on trees, good for branching." }

new ButtonInfo { buttonText = "Remove Self from Leaderboard", method =() => Overpowered.RemoveSelfFromLeaderboard(), isTogglable = false, toolTip = "Removes yourself from the leaderboard." },

new ButtonInfo { buttonText = "Start Moon Event", method =() => Overpowered.StartMoonEvent(), isTogglable = false, toolTip = "Starts the moon event."},
new ButtonInfo { buttonText = "End Moon Event", method =() => Overpowered.EndMoonEvent(), isTogglable = false, toolTip = "Ends the moon event."},
new ButtonInfo { buttonText = "Spaz Moon Event", method =() => Overpowered.FlashScreen(), toolTip = "Spazzes out the moon event."},

new ButtonInfo { buttonText = "Spawn Red Lucy", method =() => Overpowered.SpawnRedLucy(), isTogglable = false, toolTip = "Summons the red Lucy in forest." },
new ButtonInfo { buttonText = "Spawn Blue Lucy", method =() => Overpowered.SpawnBlueLucy(), isTogglable = false, toolTip = "Summons the blue Lucy in forest." },
new ButtonInfo { buttonText = "Despawn Lucy", method =() => Overpowered.DespawnLucy(), isTogglable = false, toolTip = "Despawns the ghost Lucy in forest." },
new ButtonInfo { buttonText = "Spaz Lucy", method =() => Overpowered.SpazLucy(), toolTip = "Gives the ghost Lucy a seizure." },

new ButtonInfo { buttonText = "Lucy Chase Self", method =() => Overpowered.LucyChaseSelf(), isTogglable = false, toolTip = "Makes the ghost Lucy chase you." },
new ButtonInfo { buttonText = "Lucy Chase Gun", method =() => Overpowered.LucyChaseGun(), toolTip = "Makes the ghost Lucy chase whoever your hand desires." },
                
new ButtonInfo { buttonText = "Lucy Attack Self", method =() => Overpowered.LucyAttackSelf(), isTogglable = false, toolTip = "Makes the ghost Lucy attack you." },
new ButtonInfo { buttonText = "Lucy Attack Gun", method =() => Overpowered.LucyAttackGun(), toolTip = "Makes the ghost Lucy attack whoever your hand desires." },
new ButtonInfo { buttonText = "Annoying Lucy", method =() => Overpowered.AnnoyingLucy(), toolTip = "Makes the ghost Lucy really annoying, by attacking everyone and making sounds of the bells." },

new ButtonInfo { buttonText = "Fast Lucy", method =() => Overpowered.FastLucy(), toolTip = "Makes the ghost Lucy become really fast." },
new ButtonInfo { buttonText = "Slow Lucy", method =() => Overpowered.SlowLucy(), toolTip = "Makes the ghost Lucy become really slow." },
 */

// ciperuoy: im too lazy to add the mods I deleted here, so deal with it and stuff ig
     
