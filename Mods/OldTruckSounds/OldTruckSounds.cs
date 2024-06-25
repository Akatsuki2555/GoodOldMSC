using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldTruckSounds
{
    internal class OldTruckSounds
    {   
        public GameObject Gifu;

        public static AudioClip EngineStart1;
        public static AudioClip EngineStart2;
        public static AudioClip EngineIdle;
        public static AudioClip EngineAccel;
        public static AudioClip NewEngineIdle;
        public static AudioClip NewEngineAccel;
        public static GameObject TruckLogBed1;
        public static GameObject TruckLogBed2;
        public static Material Paint4;
        public static Material TruckCabin;


        public static SettingsSliderInt RadioPosNumber;
        public static SettingsSliderInt EngineNumber;
        public static SettingsCheckBox RemovePedalsToggle;
        public static SettingsCheckBox RemoveDoorsToggle;
        public static SettingsCheckBox ReplaceShitTankWithLogsToggle;
        public static SettingsCheckBox OldStartingSoundToggle;
        public static SettingsCheckBox PaintInteriorBlackToggle;
        public static SettingsCheckBox PaintExteriorRedToggle;
        public static SettingsCheckBox HideSPZToggle;
        public static SettingsCheckBox HideMudFlapsToggle;

        public void OnLoad(Mod mod)
        {
            var assetBundle = LoadAssets.LoadBundle(mod, "oldtruck.unity3d");

            if (OldStartingSoundToggle.GetValue())
            {
                EngineStart1 = assetBundle.LoadAsset<AudioClip>("valmetstart");
                EngineStart2 = assetBundle.LoadAsset<AudioClip>("valmetstarting");
            }

            if (ReplaceShitTankWithLogsToggle.GetValue())
            {
                TruckLogBed1 = assetBundle.LoadAsset<GameObject>("trucklogbed.prefab");
                TruckLogBed2 = assetBundle.LoadAsset<GameObject>("trucklogs.prefab");
            }

            if (EngineNumber.GetValue() != 0)
            {
                switch (EngineNumber.GetValue())
                {
                    case 1:
                        NewEngineIdle = assetBundle.LoadAsset<AudioClip>("newcumminsidle");
                        NewEngineAccel = assetBundle.LoadAsset<AudioClip>("newcumminsaccel");
                        break;
                    case 2:
                        EngineIdle = assetBundle.LoadAsset<AudioClip>("cumminsidle");
                        EngineAccel = assetBundle.LoadAsset<AudioClip>("cumminsaccel");
                        break;
                }
            }

            if (PaintInteriorBlackToggle.GetValue())
            {
                Paint4 = assetBundle.LoadAsset<Material>("paint4");
            }

            if (PaintExteriorRedToggle.GetValue())
            {
                TruckCabin = assetBundle.LoadAsset<Material>("truckcabin");
            }
            assetBundle.Unload(false);

            Gifu = GameObject.Find("GIFU(750/450psi)");
            Gifu.AddComponent<Gifu>();

            // Start sounds
            if (OldStartingSoundToggle.GetValue())
            {
                GameObject truckSoundsGameObject = GameObject.Find("MasterAudio/Truck");
                truckSoundsGameObject.transform.Find("start1").GetComponent<AudioSource>().clip = EngineStart1;
                truckSoundsGameObject.transform.Find("start2").GetComponent<AudioSource>().clip = EngineStart2;
                truckSoundsGameObject.transform.Find("start3").GetComponent<AudioSource>().clip = EngineStart2;
                truckSoundsGameObject.transform.Find("start4").GetComponent<AudioSource>().clip = EngineStart2;
            }
        }

        public void ModSettings(Mod mod)
        {
            RadioPosNumber = Settings.AddSlider(mod, "radioPos", "Radio position", 0, 2, textValues: new[] {
                "Normal",
                "Put it next to wipers knob",
                "Remove radio"
            });
            EngineNumber = Settings.AddSlider(mod, "engineSel", "Engine type", 0, 2, textValues: new[] {
                "Keep these sounds",
                "Use pre-2018 sounds",
                "Use build 172 sounds"
            });
            RemovePedalsToggle = Settings.AddCheckBox(mod, "removePedals", "Remove pedals", false);
            RemoveDoorsToggle = Settings.AddCheckBox(mod, "removeDoors", "Remove doors", false);
            ReplaceShitTankWithLogsToggle = Settings.AddCheckBox(mod, "logs", "Replace shit tank with logs", false);
            OldStartingSoundToggle = Settings.AddCheckBox(mod, "oldStarting", "Old starting sound", false);
            PaintInteriorBlackToggle = Settings.AddCheckBox(mod, "blackInt", "Black interior", false);
            PaintExteriorRedToggle = Settings.AddCheckBox(mod, "redExt", "Red exterior", false);
            HideSPZToggle = Settings.AddCheckBox(mod, "spzHide", "Hide license plate", false);
            HideMudFlapsToggle = Settings.AddCheckBox(mod, "hideFlaps", "Hide mud flaps", false);
        }
    }
}
