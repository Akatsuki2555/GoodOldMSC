using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldKekmet
{
    internal class OldKekmet
    {
        private SettingsCheckBox engineSounds;
        private SettingsCheckBox startingSounds;
        private SettingsCheckBox disableDashboard;
        private SettingsCheckBox disableForkliftArm;
        private SettingsCheckBox makeForkliftWhite;
        private SettingsCheckBox oldStartingSystem;
        private SettingsCheckBox disableRadio;

        internal void ModSettings(Mod mod)
        {

            engineSounds = Settings.AddCheckBox(mod, "engineSounds", "Old Engine Sounds", true);
            startingSounds = Settings.AddCheckBox(mod, "engineStarting", "Old Engine Starting Sounds", true);
            disableDashboard = Settings.AddCheckBox(mod, "disableDashboard", "Disable Dashboard", false);
            disableForkliftArm = Settings.AddCheckBox(mod, "disableForkliftArm", "Disable Forklift Arm", false);
            makeForkliftWhite = Settings.AddCheckBox(mod, "makeForkliftWhite", "Make the forklift white", false);
            oldStartingSystem = Settings.AddCheckBox(mod, "startingSystem", "Old Starting System", true);
            disableRadio = Settings.AddCheckBox(mod, "radio", "Disable Radio", false);
        }

        internal void Mod_Load()
        {
            byte[] numArray;
            using (var manifestResourceStream = Assembly.GetExecutingAssembly()
                       .GetManifestResourceStream("GoodOldMSC.Resources.oldkekmet.unity3d"))
            {
                if (manifestResourceStream == null)
                    throw new Exception("The mod DLL is corrupted, unable to load oldkekmet.unity3d. Cannot continue");
                numArray = new byte[manifestResourceStream.Length];
                _ = manifestResourceStream.Read(numArray, 0, numArray.Length);
            }

            var resources = numArray.Length != 0
                ? AssetBundle.CreateFromMemoryImmediate(numArray)
                : throw new Exception("The mod DLL is corrupted, unable to load oldkekmet.unity3d. Cannot continue");

            var traktor = GameObject.Find("KEKMET(350-400psi)");
            var traktorSounds = traktor.GetComponent<SoundController>();
            if (engineSounds.GetValue())
            {
                var valmetIdle = resources.LoadAsset<AudioClip>("valmet_idle");

                traktorSounds.engineThrottle = valmetIdle;
                traktorSounds.engineNoThrottle = valmetIdle;

                traktorSounds.engineThrottleVolume = 3;
                traktorSounds.engineNoThrottleVolume = 2.5f;
                traktorSounds.engineThrottlePitchFactor = 1;
                traktorSounds.engineNoThrottlePitchFactor = 1;

                traktor.transform.GetChild(21).GetComponent<AudioSource>().clip = valmetIdle;
                traktor.transform.GetChild(22).GetComponent<AudioSource>().clip = valmetIdle;
                traktor.transform.GetChild(21).GetComponent<AudioSource>().Play();
                traktor.transform.GetChild(22).GetComponent<AudioSource>().Play();

                var si = traktor.AddComponent<SoundImprovement>();
            }

            if (startingSounds.GetValue())
            {
                var valmetStart = resources.LoadAsset<AudioClip>("valmet_start");
                var valmetStarting = resources.LoadAsset<AudioClip>("valmet_starting");

                var start1 = GameObject.Find("MasterAudio/Valmet/start1");
                start1.GetComponent<AudioSource>().clip = valmetStart;

                var start2 = GameObject.Find("MasterAudio/Valmet/start2");
                start2.GetComponent<AudioSource>().clip = valmetStarting;

                var start3 = GameObject.Find("MasterAudio/Valmet/start3");
                start3.GetComponent<AudioSource>().clip = valmetStarting;
            }

            if (disableDashboard.GetValue())
            {
                var dash1 = traktor.transform.GetChild(3);

                dash1.GetChild(2).gameObject.SetActive(false);

                var dash2 = traktor.transform.GetChild(5).GetChild(4);

                dash2.GetChild(7).gameObject.SetActive(false);
                dash2.GetChild(8).gameObject.SetActive(false);
            }

            if (disableForkliftArm.GetValue())
            {
                var forklift1 = GameObject.Find("KEKMET(350-400psi)/Frontloader/ArmPivot/Arm").transform;

                forklift1.GetChild(0).gameObject.SetActive(false);
                forklift1.GetChild(1).gameObject.SetActive(false);
                forklift1.GetChild(3).gameObject.SetActive(false);
                forklift1.GetChild(4).gameObject.SetActive(false);
                forklift1.GetChild(5).gameObject.SetActive(false);

                var forklift2 = traktor.transform.GetChild(5);

                for (var i = 17; i <= 20; i++)
                    forklift2.GetChild(i).gameObject.SetActive(false);
                var forklift3 = GameObject.Find("KEKMET(350-400psi)/Frontloader").transform;

                forklift3.GetChild(0).gameObject.SetActive(false);
                forklift3.GetChild(1).gameObject.SetActive(false);
                forklift3.GetChild(2).gameObject.SetActive(false);
                var forklift4 = GameObject.Find("KEKMET(350-400psi)/Frontloader/ArmPivot/Arm/LoaderPivot/Loader").transform;

                forklift4.GetChild(5).gameObject.SetActive(false);
                forklift4.GetChild(6).gameObject.SetActive(false);
            }

            if (makeForkliftWhite.GetValue())
            {
                GameObject.Find("KEKMET(350-400psi)/Frontloader/ArmPivot/Arm/LoaderPivot/Loader/mesh").GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"))
                {
                    color = new Color(43, 43, 43)
                };
            }

            if (disableRadio.GetValue())
            {
                traktor.transform.GetChild(14).gameObject.SetActive(false);
            }

            if (oldStartingSystem.GetValue())
            {
                var antiStall = traktor.AddComponent<AntiStall>();
            }

            resources.Unload(false);
        }
    }
}
