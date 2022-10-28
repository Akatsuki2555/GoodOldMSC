using System.Diagnostics;
using MSCLoader;
using UnityEngine;

namespace GoodOldMSC.Mods {
    public class OldCarSounds {
        SoundController _satsumaSound;

        SettingsDropDownList engineSoundsType;

        AudioClip accelSound, deaccelSound;

        public OldCarSounds() {
            _stopwatch = Stopwatch.StartNew();
        }

        public void Load() {
            AssetBundle assetBundle = AssetBundle.CreateFromMemoryImmediate(Resources.oldcarsounds);
            accelSound = assetBundle.LoadAsset<AudioClip>("idle_sisa");
            deaccelSound = assetBundle.LoadAsset<AudioClip>("idle");
            assetBundle.Unload(false);

            GameObject shitsuma = GameObject.Find("SATSUMA(557kg, 248)");
            _satsumaSound = shitsuma.GetComponent<SoundController>();

            #region Engine sounds

            switch (engineSoundsType.GetSelectedItemIndex()) {
                case 2:
                    AudioSource accelSource = shitsuma.transform.GetChild(40).GetComponent<AudioSource>();
                    AudioSource deaccelSource = shitsuma.transform.GetChild(41).GetComponent<AudioSource>();

                    _satsumaSound.engineThrottle = accelSound;
                    accelSource.clip = accelSound;
                    accelSource.Play();

                    _satsumaSound.engineNoThrottle = deaccelSound;
                    deaccelSource.clip = deaccelSound;
                    deaccelSource.Play();

                    shitsuma.transform.Find("CarSimulation/Exhaust/FromMuffler").GetComponent<AudioSource>().clip = deaccelSound;
                    shitsuma.transform.Find("CarSimulation/Exhaust/FromHeaders").GetComponent<AudioSource>().clip = deaccelSound;
                    shitsuma.transform.Find("CarSimulation/Exhaust/FromPipe").GetComponent<AudioSource>().clip = deaccelSound;
                    shitsuma.transform.Find("CarSimulation/Exhaust/FromEngine").GetComponent<AudioSource>().clip = deaccelSound;

                    _satsumaSound.engineThrottleVolume = 1f;
                    goto case 1;
                case 1:
                    _satsumaSound.engineThrottlePitchFactor = 1;
                    _satsumaSound.engineNoThrottlePitchFactor = 0.5f;
                    break;
            }

            #endregion
        }

        public void Update() {
        }

        public void ModSettings(Mod mod) {
            ModConsole.Log("Loading ModSettings from OldCarSounds");
            engineSoundsType = Settings.AddDropDownList(mod, "engType", "Engine sound type", new string[] {
                "No change",
                "Old pitch (2016)",
                "From old alpha (2013-2014)"
            });
        }

        private Stopwatch _stopwatch;

        public void OnGUI() {
        }
    }
}