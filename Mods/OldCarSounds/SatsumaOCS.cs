using System;

using MSCLoader;

using UnityEngine;

namespace GoodOldMSC.Mods.OldCarSounds {

    public class SatsumaOcs : MonoBehaviour {
        public static GameObject knobLights;
        public static GameObject knobWipers;
        public static GameObject knobHazards;
        public static GameObject knobChoke;
        public static GameObject triggerHazard;
        public static GameObject triggerChoke;
        public static GameObject triggerButtonWiper;
        public static GameObject triggerLightModes;
        public static RadioCore radioCoreInstance;
        public static GameObject powerKnob;
        public static GameObject volumeKnob;
        public static GameObject switchKnob;
        private Drivetrain _drivetrain;
        private SoundController _soundController;
        private GameObject _carKeysIn;
        private GameObject _carKeysOut;
        private GameObject _carKeysSwitch;
        private GameObject _closeDoorSound;
        private GameObject _closeHoodSound;
        private GameObject _closeTrunkSound;
        private AudioSource _dashButtonAudio;
        private GameObject _openDoorSound;
        private GameObject _openHoodSound;
        private GameObject _openTrunkSound;
        private GameObject _radio1Instantiated;
        private GameObject _walkingSoundsParent;

        private void Start() {
            try {
                _soundController = GetComponent<SoundController>();
                _drivetrain = GetComponent<Drivetrain>();

                // if the user selected "old alpha 2014" sounds
                if (OldCarSounds.EngineSoundsTypeSettings.Value.ToString() == "2") {

                    // Change sounds.
                    _soundController.engineNoThrottle = OldCarSounds.Clip2;
                    _soundController.engineThrottle = OldCarSounds.Clip2;
                    OldCarSounds.PrintF("Applied extra sound effects.", "load");

                    // Change the pitches.
                    OldCarSounds.PrintF("Loading audio pitch change.", "load");
                    _soundController.engineThrottlePitchFactor = 1f;
                    _soundController.engineThrottleVolume = 1f;
                    _soundController.engineNoThrottlePitchFactor = 0.6f;

                    // Change more audio clips.
                    gameObject.transform.GetChild(40).GetComponent<AudioSource>().clip = OldCarSounds.Clip2;
                    gameObject.transform.GetChild(41).GetComponent<AudioSource>().clip = OldCarSounds.Clip2;
                    OldCarSounds.PrintF("Loaded in engine sound effects.", "load");

                    // Play these audio clips otherwise the sound will be quiet.
                    // In Unity, when you change the clip, the sound will not play automatically.
                    gameObject.transform.GetChild(40).GetComponent<AudioSource>().Play();
                    gameObject.transform.GetChild(41).GetComponent<AudioSource>().Play();

                    // Set exhaust sounds.
                    gameObject.transform.Find("CarSimulation/Exhaust/FromMuffler").GetComponent<AudioSource>().clip =
                        OldCarSounds.Clip1;
                    gameObject.transform.Find("CarSimulation/Exhaust/FromHeaders").GetComponent<AudioSource>().clip =
                        OldCarSounds.Clip1;
                    gameObject.transform.Find("CarSimulation/Exhaust/FromPipe").GetComponent<AudioSource>().clip =
                        OldCarSounds.Clip1;
                    gameObject.transform.Find("CarSimulation/Exhaust/FromEngine").GetComponent<AudioSource>().clip =
                        OldCarSounds.Clip1;
                    OldCarSounds.PrintF("Applied exhaust sound to the exhaust.", "load");
                }

                // if the user selected "first release 2016" sounds
                if (OldCarSounds.EngineSoundsTypeSettings.Value.ToString() == "1") {

                    // adjust pitches
                    _soundController.engineThrottlePitchFactor = 1.0f;
                }

                OldCarSounds.PrintF("Applied sound effects for engine.", "load");

                OldCarSounds.PrintF("Loading old sounds for removing/attaching parts", "load");

                //Only apply assemble sound if the user enabled it.
                if ((bool)OldCarSounds.AssembleSounds.Value) {

                    //Find the container of assemble and disassemble sounds.
                    GameObject go1 = GameObject.Find("MasterAudio/CarBuilding");

                    //Set the disassemble clip.
                    go1.transform.Find("disassemble").GetComponent<AudioSource>().clip = OldCarSounds.Clip3;

                    //Set the assemble clip.
                    go1.transform.Find("assemble").GetComponent<AudioSource>().clip = OldCarSounds.Clip3;
                }

                // Load old dash texture  if the user has chosen to
                if ((bool)OldCarSounds.OldDashTexturesSettings.Value) {
                    OldCarSounds.PrintF("Loading old car textures.", "LOAD");

                    // Create the old reflective material.
                    Material theMaterial = OldCarSounds.Material1;

                    // Apply to dashboard.
                    GameObject dashboardClone = GameObject.Find("dashboard(Clone)");
                    dashboardClone.GetComponent<MeshRenderer>().material = theMaterial;

                    // Apply to stock steering wheel.
                    GameObject steeringWheelClone = GameObject.Find("stock steering wheel(Clone)");
                    steeringWheelClone.GetComponent<MeshRenderer>().material = theMaterial;

                    // Apply to dashboard meters.
                    GameObject dashboardMetersClone = GameObject.Find("dashboard meters(Clone)");
                    dashboardMetersClone.GetComponent<MeshRenderer>().material = theMaterial;

                    // Define game object variables for knobs.
                    triggerHazard = dashboardMetersClone.transform.Find("Knobs/ButtonsDash/Hazard").gameObject;
                    triggerButtonWiper =
                        dashboardMetersClone.transform.Find("Knobs/ButtonsDash/ButtonWipers").gameObject;
                    triggerChoke = dashboardMetersClone.transform.Find("Knobs/ButtonsDash/Choke").gameObject;
                    triggerLightModes = dashboardMetersClone.transform.Find("Knobs/ButtonsDash/LightModes").gameObject;
                    knobChoke = dashboardMetersClone.transform.Find("Knobs/KnobChoke/knob").gameObject;
                    knobChoke.GetComponent<Renderer>().material = theMaterial;
                    knobHazards = dashboardMetersClone.transform.Find("Knobs/KnobHazards/knob").gameObject;
                    knobHazards.GetComponent<Renderer>().material = theMaterial;
                    knobWipers = dashboardMetersClone.transform.Find("Knobs/KnobWasher/knob").gameObject;
                    knobWipers.GetComponent<Renderer>().material = theMaterial;
                    knobLights = dashboardMetersClone.transform.Find("Knobs/KnobLights/knob").gameObject;
                    knobLights.GetComponent<Renderer>().material = theMaterial;
                }

                OldCarSounds.PrintF("Adjusting drivetrain sounds.", "load");

                //Make drivetrain quieter.
                _soundController.transmissionVolume = 0.08f;
                _soundController.transmissionVolumeReverse = 0.08f;
                OldCarSounds.PrintF("Adjusting drivetrain done.", "load");

                OldCarSounds.PrintF("Adjusting shift delay.", "load");

                // Shift delay selection load
                if (OldCarSounds.ShiftDelaySelectionSettings.Value.ToString() != "0") {
                    if (OldCarSounds.ShiftDelaySelectionSettings.Value.ToString() == "1") {

                        // Old shift delay
                        _drivetrain.shiftTime = 0;
                    }

                    if (OldCarSounds.ShiftDelaySelectionSettings.Value.ToString() == "2") {

                        // No shift delay
                        _drivetrain.shiftTime = 0.0000001f;
                    }
                }

                OldCarSounds.PrintF("Adjusting shift delay done.", "load");

                //If the user enabled the old radio
                if ((bool)OldCarSounds.OldRadioEnabled.Value) {
                    OldCarSounds.PrintF("Loading old radio.", "LOAD");

                    // Spawn old car radio
                    OldCarSounds.PrintF("Spawning cube radio.", "load");
                    _radio1Instantiated = Instantiate(OldCarSounds.Radio1);

                    // Define knobs
                    powerKnob = _radio1Instantiated.transform.Find("trigger_ocs_power1").gameObject;
                    volumeKnob = _radio1Instantiated.transform.Find("trigger_ocs_volume1").gameObject;
                    switchKnob = _radio1Instantiated.transform.Find("trigger_ocs_switch1").gameObject;

                    // Add a script to the radio
                    OldCarSounds.PrintF("Adding script to cube radio.", "load");
                    radioCoreInstance = _radio1Instantiated.AddComponent<RadioCore>();
                }

                OldCarSounds.PrintF("Finished loading old radio.", "load");

                // Disable dashboard knob sounds when the user enables it.
                if ((bool)OldCarSounds.DisableKnobSoundsSettings.Value) {
                    OldCarSounds.PrintF("Disabling knob sounds: Definition.", "load");

                    // Define the audio source
                    _dashButtonAudio = GameObject.Find("CarFoley/dash_button").GetComponent<AudioSource>();
                    OldCarSounds.PrintF("Disabling knob sounds: Definition done.", "load");
                }

                OldCarSounds.PrintF("Defining key sounds.", "load");

                // Define the key sounds
                if (OldCarSounds.KeySoundSelectionSettings.Value.ToString() != "0") {
                    _carKeysIn = GameObject.Find("CarFoley/carkeys_in");
                    _carKeysOut = GameObject.Find("CarFoley/carkeys_out");
                    _carKeysSwitch = GameObject.Find("CarFoley/ignition_keys");
                }

                // Define door sounds
                if ((bool)OldCarSounds.DisableDoorSoundsSettings.Value) {
                    _openDoorSound = GameObject.Find("CarFoley/open_door1");
                    _openHoodSound = GameObject.Find("CarFoley/open_hood1");
                    _openTrunkSound = GameObject.Find("CarFoley/open_trunk1");
                    _closeDoorSound = GameObject.Find("CarFoley/close_door1");
                    _closeHoodSound = GameObject.Find("CarFoley/close_hood1");
                    _closeTrunkSound = GameObject.Find("CarFoley/close_trunk1");
                }

                if ((bool)OldCarSounds.DisableFootSoundsSettings.Value) {
                    _walkingSoundsParent = GameObject.Find("Walking");
                }
            }
            catch (Exception e) {
                OldCarSounds.PrintF(e.Message, "ERR", true);
            }
        }

        private void Update() {
            if (ModLoader.GetCurrentScene() == CurrentScene.Game) {

                // Car key sounds
                if (OldCarSounds.KeySoundSelectionSettings.Value.ToString() != "0") {

                    // Old key sounds (2016)
                    if (OldCarSounds.KeySoundSelectionSettings.Value.ToString() == "1" || OldCarSounds.KeySoundSelectionSettings.Value.ToString() == "2") {

                        // Disable the carkeysin and carkeysout sounds
                        if (_carKeysIn.GetComponent<AudioSource>().isPlaying) {
                            _carKeysIn.GetComponent<AudioSource>().Stop();
                        }

                        if (_carKeysOut.GetComponent<AudioSource>().isPlaying) {
                            _carKeysOut.GetComponent<AudioSource>().Stop();
                        }
                    }

                    if (OldCarSounds.KeySoundSelectionSettings.Value.ToString() == "2") {
                        if (_carKeysSwitch.GetComponent<AudioSource>().isPlaying) {
                            _carKeysSwitch.GetComponent<AudioSource>().Stop();
                        }
                    }
                }

                // If the user has chosen to
                if ((bool)OldCarSounds.DisableKnobSoundsSettings.Value) {

                    // Disable the dashboard sound constantly.
                    if (_dashButtonAudio.isPlaying) {
                        _dashButtonAudio.Stop();
                    }
                }

                if ((bool)OldCarSounds.DisableFootSoundsSettings.Value) {
                    foreach (AudioSource item in _walkingSoundsParent.GetComponentsInChildren<AudioSource>()) {
                        if (item.isPlaying) {
                            item.Stop();
                        }
                    }
                }

                if ((bool)OldCarSounds.DisableDoorSoundsSettings.Value) {
                    if (_openDoorSound.GetComponent<AudioSource>().isPlaying) {
                        _openDoorSound.GetComponent<AudioSource>().Stop();
                    }

                    if (_openHoodSound.GetComponent<AudioSource>().isPlaying) {
                        _openHoodSound.GetComponent<AudioSource>().Stop();
                    }

                    if (_openTrunkSound.GetComponent<AudioSource>().isPlaying) {
                        _openTrunkSound.GetComponent<AudioSource>().Stop();
                    }

                    if (_closeDoorSound.GetComponent<AudioSource>().isPlaying) {
                        _closeDoorSound.GetComponent<AudioSource>().Stop();
                    }

                    if (_closeHoodSound.GetComponent<AudioSource>().isPlaying) {
                        _closeHoodSound.GetComponent<AudioSource>().Stop();
                    }

                    if (_closeTrunkSound.GetComponent<AudioSource>().isPlaying) {
                        _closeTrunkSound.GetComponent<AudioSource>().Stop();
                    }
                }

                if ((bool)OldCarSounds.OldDelaySettings.Value) {
                    _drivetrain.revLimiterTime = 0.1f;
                }
            }

            foreach (AudioSource componentsInChild in GetComponentsInChildren<AudioSource>()) {
                if (componentsInChild == null) {
                    continue;
                }

                if (componentsInChild.clip == null) {
                    continue;
                }

                if (componentsInChild.clip.name == "cooldown_tick") {
                    componentsInChild.Stop();

                    // ModConsole.Print("Disabled " + componentsInChild.clip.name + " on " + OldCarSoundsOld.GameObjectPath(componentsInChild.gameObject));
                }
            }
        }
    }
}
