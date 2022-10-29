using MSCLoader;
using System.Diagnostics;
using UnityEngine;

namespace GoodOldMSC.Mods {
    public class OldCarSounds {
        Mod mod;

        SoundController _satsumaSound;
        Drivetrain _drivetrain;

        SettingsDropDownList engineSoundsType;
        SettingsCheckBox oldAssembleSounds, oldDashboard, oldInformation;
        SettingsSlider drivetrainVolume, drivetrainVolumeReverse;

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
            _drivetrain = shitsuma.GetComponent<Drivetrain>();

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

            _satsumaSound.transmissionVolume *= drivetrainVolume.GetValue() / 100;
            _satsumaSound.transmissionVolumeReverse *= drivetrainVolumeReverse.GetValue() / 100;

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

        float fps = 0;

        public void Update() {
            fps = 1 / Time.deltaTime;
        }
        
        public void OnGUI() {
            if (oldInformation.GetValue() && Application.loadedLevelName == "GAME") {
                GUI.Label(new Rect(0, 0, 500, 20), $"GoodOldMSC {mod.Version}");
                GUI.Label(new Rect(0, 20, 500, 20), $"FPS: {fps}");
                GUI.Label(new Rect(0, 40, 500, 20),
                    $"Lake run current time: {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
                GUI.Label(new Rect(0, 60, 500, 20), "Lake run last time: ");
            }
        }

        public void ModSettings(Mod mod) {
            this.mod = mod;
            ModConsole.Log("Loading ModSettings from OldCarSounds");
            engineSoundsType = Settings.AddDropDownList(mod, "engType", "Engine sound type", new string[] {
                "No change",
                "Old pitch (2016)",
                "From old alpha (2013-2014)"
            });

            drivetrainVolume = Settings.AddSlider(mod, "drivetrain", "Drivetrain volume", 0f, 100f, 100f);
            drivetrainVolumeReverse = Settings.AddSlider(mod, "drivetrainr", "Drivetrain volume (Reverse)", 0f, 100f, 100f);

            oldInformation = Settings.AddCheckBox(mod, "info", "Information in left top corner");
            oldAssembleSounds = Settings.AddCheckBox(mod, "assemble", "Old assemble sounds");
            oldDashboard = Settings.AddCheckBox(mod, "dash", "Old dashboard texture");
        }

        private Stopwatch _stopwatch;

        
    }
}