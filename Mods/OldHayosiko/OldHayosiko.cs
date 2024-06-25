using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldHayosiko
{
    internal class OldHayosiko
    {
        private SettingsCheckBox _removeDashboard;
        private SettingsCheckBox _steeringWheel;
        private SettingsCheckBox _disableHorn;
        private SettingsCheckBox _oldEngine;
        private SettingsCheckBox _oldOutsideTexture;
        private SettingsCheckBox _oldInsideTexture;

        internal void OnLoad()
        {
            byte[] numArray;
            using (var manifestResourceStream = Assembly.GetExecutingAssembly()
                       .GetManifestResourceStream("GoodOldMSC.Resources.oldhayoso.unity3d"))
            {
                if (manifestResourceStream == null)
                    throw new Exception("The mod DLL is corrupted, unable to load oldhayoso.unity3d. Cannot continue");
                numArray = new byte[manifestResourceStream.Length];
                _ = manifestResourceStream.Read(numArray, 0, numArray.Length);
            }

            var assetBundle = numArray.Length != 0
                ? AssetBundle.CreateFromMemoryImmediate(numArray)
                : throw new Exception("The mod DLL is corrupted, unable to load oldhayoso.unity3d. Cannot continue");
            ModConsole.Print("Loading OldHayosiko");

            SteeringWheel.ApplySteeringWheel(assetBundle, _steeringWheel.GetValue());
            RemoveDashboard.ApplyRemoveDashboard(_removeDashboard.GetValue());
            DisableHorn.ApplyDisableHorn(_disableHorn.GetValue());
            OldEngine.ApplyOldEngine(assetBundle, _oldEngine.GetValue());
            OldInsideTextures.ApplyOldInsideTextures(assetBundle, _oldInsideTexture.GetValue(), _removeDashboard.GetValue());
            OldOutsideTextures.ApplyOldOutsideTexture(assetBundle, _oldOutsideTexture.GetValue());
        }

        internal void ModSettings(Mod mod)
        {
            _removeDashboard = Settings.AddCheckBox(mod, "dashboard", "Remove Dashboard");
            _steeringWheel = Settings.AddCheckBox(mod, "wheel", "Old steering wheel");
            _disableHorn = Settings.AddCheckBox(mod, "horn", "Disable horn");
            Settings.AddCheckBox(mod, "shift", "Instant Shifting");
            _oldEngine = Settings.AddCheckBox(mod, "engine", "Old engine sound");
            _oldOutsideTexture = Settings.AddCheckBox(mod, "texture", "Old body texture");
            _oldInsideTexture = Settings.AddCheckBox(mod, "texture2", "Old inside textures");
        }

    }
}
