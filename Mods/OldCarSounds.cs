using System.Diagnostics;
using MSCLoader;
using UnityEngine;

namespace GoodOldMSC.Mods {
    public class OldCarSounds {
        SoundController _satsumaSound;

        SettingsDropDownList engineSoundsType;
        SettingsCheckBox oldAssembleSounds, oldDashboard;

        AudioClip accelSound, deaccelSound, attachDetachSound;
        Material black, white, selection;

        GameObject triggerHazard, triggerWasher, triggerChoke, triggerLight;
        GameObject knobHazard, knobWasher, knobChoke, knobLight;

        public OldCarSounds() {
            _stopwatch = Stopwatch.StartNew();
        }

        public void Load() {
            AssetBundle assetBundle = AssetBundle.CreateFromMemoryImmediate(Resources.oldcarsounds);
            accelSound = assetBundle.LoadAsset<AudioClip>("idle_sisa");
            deaccelSound = assetBundle.LoadAsset<AudioClip>("idle");
            attachDetachSound = assetBundle.LoadAsset<AudioClip>("assemble");

            black = assetBundle.LoadAsset<Material>("black");
            white = assetBundle.LoadAsset<Material>("white");
            selection = assetBundle.LoadAsset<Material>("selection");
            assetBundle.Unload(false);

            GameObject shitsuma = GameObject.Find("SATSUMA(557kg, 248)");
            _satsumaSound = shitsuma.GetComponent<SoundController>();

            #region Engine sounds

            switch (engineSoundsType.GetSelectedItemIndex()) {
                case 2:
                    AudioSource accelSource = shitsuma.transform.GetChild(40).GetComponent<AudioSource>();
                    AudioSource deaccelSource = shitsuma.transform.GetChild(41).GetComponent<AudioSource>();

                    _satsumaSound.engineThrottle = accelSound;
                    _satsumaSound.engineThrottleVolume = 1f;
                    accelSource.clip = accelSound;
                    accelSource.Play();

                    _satsumaSound.engineNoThrottle = accelSound;
                    deaccelSource.clip = accelSound;
                    deaccelSource.Play();

                    shitsuma.transform.Find("CarSimulation/Exhaust/FromMuffler").GetComponent<AudioSource>().clip = deaccelSound;
                    shitsuma.transform.Find("CarSimulation/Exhaust/FromHeaders").GetComponent<AudioSource>().clip = deaccelSound;
                    shitsuma.transform.Find("CarSimulation/Exhaust/FromPipe").GetComponent<AudioSource>().clip = deaccelSound;
                    shitsuma.transform.Find("CarSimulation/Exhaust/FromEngine").GetComponent<AudioSource>().clip = deaccelSound;

                    goto case 1;
                case 1:
                    _satsumaSound.engineThrottlePitchFactor = 1;
                    _satsumaSound.engineNoThrottlePitchFactor = 0.5f;
                    break;
            }

            #endregion

            if (oldAssembleSounds.GetValue()) {
                GameObject buildSounds = GameObject.Find("MasterAudio/CarBuilding");
                buildSounds.transform.Find("disassemble").GetComponent<AudioSource>().clip = attachDetachSound;
                buildSounds.transform.Find("assemble").GetComponent<AudioSource>().clip = attachDetachSound;
            }

            if (oldDashboard.GetValue()) {
                GameObject dash = GameObject.Find("dashboard(Clone)");
                dash.GetComponent<MeshRenderer>().material = black;
                GameObject steeringWheel = GameObject.Find("stock steering wheel(Clone)");
                steeringWheel.GetComponent<MeshRenderer>().material = black;
                GameObject dashMeters = GameObject.Find("dashboard meters(Clone)");
                dashMeters.GetComponent<MeshRenderer>().material = black;

                triggerHazard = dashMeters.transform.Find("Knobs/ButtonsDash/Hazard").gameObject;
                triggerWasher = dashMeters.transform.Find("Knobs/ButtonsDash/ButtonWipers").gameObject;
                triggerChoke = dashMeters.transform.Find("Knobs/ButtonsDash/Choke").gameObject;
                triggerLight = dashMeters.transform.Find("Knobs/ButtonsDash/LightModes").gameObject;

                knobChoke = dashMeters.transform.Find("Knobs/KnobChoke/knob").gameObject;
                knobChoke.GetComponent<Renderer>().material = black;
                knobHazard = dashMeters.transform.Find("Knobs/KnobHazards/knob").gameObject;
                knobHazard.GetComponent<Renderer>().material = black;
                knobWasher = dashMeters.transform.Find("Knobs/KnobWasher/knob").gameObject;
                knobWasher.GetComponent<Renderer>().material = black;
                knobLight = dashMeters.transform.Find("Knobs/KnobLights/knob").gameObject;
                knobLight.GetComponent<Renderer>().material = black;
            }
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
            oldAssembleSounds = Settings.AddCheckBox(mod, "assemble", "Old assemble sounds");
        }

        private Stopwatch _stopwatch;

        public void OnGUI() {
        }
    }
}