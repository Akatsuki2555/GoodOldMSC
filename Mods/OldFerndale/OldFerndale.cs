using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class OldFerndale
    {
        internal SettingsSliderInt SettingOldSkin;
        internal SettingsSliderInt SettingOldWheels;
        internal SettingsSliderInt SettingTachometer;
        internal SettingsCheckBox SettingRemoveScoop;
        internal SettingsCheckBox SettingOldEngine;
        internal SettingsCheckBox SettingRemoveLinelockButton;
        internal SettingsCheckBox SettingOldLicensePlate;
        internal SettingsCheckBox SettingRemoveMudflaps;
        internal SettingsCheckBox SettingOldSuspension;
        internal SettingsCheckBox SettingRemoveRearAxle;
        internal SettingsCheckBox SettingRedInterior;
        internal SettingsCheckBox SettingRemoveYellowBarOnAxle;
        internal SettingsCheckBox SettingOldRearWheelsSize;

        public void ModSettings(Mod mod)
        {
            Settings.AddHeader(mod, "Settings");
            SettingOldSkin = Settings.AddSlider(mod, "skin", "Skin", 0, 5, 1,
                textValues: new[] { "Leave as is", "2016", "build 178", "Red", "Blue", "Black" });
            SettingOldWheels = Settings.AddSlider(mod, "oldWheels", "Old Wheels", 0, 3, 1,
                textValues: new[] { "No change", "Wheels from 2016", "Wheels from Build 178", "Build <176" });
            SettingTachometer = Settings.AddSlider(mod, "tachometer", "Tachometer", 0, 2, 1,
                textValues: new[] { "Unchanged", "Old", "Remove" });
            SettingRemoveScoop = Settings.AddCheckBox(mod, "removeScoop", "Remove Scoop", true);
            SettingOldEngine = Settings.AddCheckBox(mod, "oldEngine", "Old Engine", true);
            SettingRemoveLinelockButton = Settings.AddCheckBox(mod, "linelock", "Remove Linelock Button", true);
            SettingRemoveMudflaps = Settings.AddCheckBox(mod, "removeMudflaps", "Remove Mudflaps", true);
            SettingOldSuspension = Settings.AddCheckBox(mod, "oldSuspension", "Old Suspension", true);
            SettingRemoveRearAxle = Settings.AddCheckBox(mod, "removeRearAxle", "Remove Rear Axle", true);
            SettingRedInterior = Settings.AddCheckBox(mod, "redInterior", "Red Interior");
            SettingOldLicensePlate = Settings.AddCheckBox(mod, "oldLicPlate", "Old License Plate");
            SettingRemoveYellowBarOnAxle = Settings.AddCheckBox(mod, "removeYellowBarOnAxle", "Remove Yellow Bar on Axle");
            SettingOldRearWheelsSize = Settings.AddCheckBox(mod, "oldRearWheelsSize", "Old Rear Wheels Size");

            Settings.AddButton(mod, "Suggest new features",
                () =>
                {
                    ModUI.ShowYesNoMessage("Open website: https://mldkyt.com/suggestions?type=oldferndale",
                        () => { Application.OpenURL("https://mldkyt.com/suggestions?type=oldferndale"); });
                });
            Settings.AddHeader(mod, "Thanks to");
            Settings.AddText(mod,
                "<b>wojskoda</b> - Suggested most of the features and sent some of the assets that are used in mod mod");
            Settings.AddText(mod,
                "<b>Amistech</b> - All of the models and textures used in this mod were originally made by Amistech");
        }

        internal void Mod_Load()
        {
            byte[] numArray;
            using (var manifestResourceStream = Assembly.GetExecutingAssembly()
                       .GetManifestResourceStream("GoodOldMSC.Resources.oldferndale.unity3d"))
            {
                if (manifestResourceStream == null)
                    throw new Exception("The mod DLL is corrupted, unable to load oldferndale.unity3d. Cannot continue");
                numArray = new byte[manifestResourceStream.Length];
                _ = manifestResourceStream.Read(numArray, 0, numArray.Length);
            }

            var resource = numArray.Length != 0
                ? AssetBundle.CreateFromMemoryImmediate(numArray)
                : throw new Exception("The mod DLL is corrupted, unable to load oldferndale.unity3d. Cannot continue");

            OldSkin.ApplyOldSkin(resource, SettingOldSkin);
            RemoveScoop.ApplyRemoveScoop(SettingRemoveScoop);
            OldEngine.ApplyOldEngine(SettingOldEngine);
            RemoveLinelock.ApplyRemoveLinelock(SettingRemoveLinelockButton);
            OldLicensePlate.ApplyOldLicensePlate(SettingOldLicensePlate);
            RemoveMudflaps.ApplyRemoveMudflaps(resource, SettingRemoveMudflaps, SettingRemoveYellowBarOnAxle);
            OldSuspension.ApplyOldSuspension(SettingOldSuspension);
            OldRims.ApplyOldRims(resource, SettingOldWheels);
            OldTachometer.ApplyOldTachometer(resource, SettingTachometer);
            RemoveRearAxle.ApplyRemoveRearAxle(SettingRemoveRearAxle);
            RedInterior.ApplyRedInterior(resource, SettingRedInterior);
            RemoveYellowBars.ApplyRemoveYellowBars(resource, SettingRemoveYellowBarOnAxle, SettingRemoveMudflaps);
            OldRearWheelsSize.ApplyOldRearWheelsSize(SettingOldRearWheelsSize);

            resource.Unload(false);
        }
    }
}
