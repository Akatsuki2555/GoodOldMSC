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
            _soundController = GetComponent<SoundController>();
            _drivetrain = GetComponent<Drivetrain>();

            // if the user selected "old alpha 2014" sounds
            if (OldCarSounds.EngineSoundsTypeSettings.GetValue() == 2) {

                // Change sounds.
                _soundController.engineNoThrottle = OldCarSounds.Clip2;
                _soundController.engineThrottle = OldCarSounds.Clip2;

                // Change the pitches.
                _soundController.engineThrottlePitchFactor = 1f;
                _soundController.engineThrottleVolume = 1f;
                _soundController.engineNoThrottlePitchFactor = 0.6f;

                // Change more audio clips.
                gameObject.transform.GetChild(40).GetComponent<AudioSource>().clip = OldCarSounds.Clip2;
                gameObject.transform.GetChild(41).GetComponent<AudioSource>().clip = OldCarSounds.Clip2;

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
            }

            // if the user selected "first release 2016" sounds
            if (OldCarSounds.EngineSoundsTypeSettings.GetValue() == 1) {

                // adjust pitches
                _soundController.engineThrottlePitchFactor = 1.0f;
            }

            //Only apply assemble sound if the user enabled it.
            if (OldCarSounds.AssembleSounds.GetValue()) {

                //Find the container of assemble and disassemble sounds.
                GameObject go1 = GameObject.Find("MasterAudio/CarBuilding");

                //Set the disassemble clip.
                go1.transform.Find("disassemble").GetComponent<AudioSource>().clip = OldCarSounds.Clip3;

                //Set the assemble clip.
                go1.transform.Find("assemble").GetComponent<AudioSource>().clip = OldCarSounds.Clip3;
            }

            // Load old dash texture  if the user has chosen to
            if (OldCarSounds.OldDashTexturesSettings.GetValue()) {
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

            //Make drivetrain quieter.
            _soundController.transmissionVolume = 0.08f;
            _soundController.transmissionVolumeReverse = 0.08f;

            // Shift delay selection load
            if (OldCarSounds.ShiftDelaySelectionSettings.GetValue() != 0) {
                if (OldCarSounds.ShiftDelaySelectionSettings.GetValue() == 1) {

                    // Old shift delay
                    _drivetrain.shiftTime = 0;
                }

                if (OldCarSounds.ShiftDelaySelectionSettings.GetValue() == 2) {

                    // No shift delay
                    _drivetrain.shiftTime = 0.0000001f;
                }
            }

            //If the user enabled the old radio
            if (OldCarSounds.OldRadioEnabled.GetValue()) {
                // Spawn old car radio
                _radio1Instantiated = Instantiate(OldCarSounds.Radio1);

                // Define knobs
                powerKnob = _radio1Instantiated.transform.Find("trigger_ocs_power1").gameObject;
                volumeKnob = _radio1Instantiated.transform.Find("trigger_ocs_volume1").gameObject;
                switchKnob = _radio1Instantiated.transform.Find("trigger_ocs_switch1").gameObject;

                // Add a script to the radio
                radioCoreInstance = _radio1Instantiated.AddComponent<RadioCore>();
            }

            // Disable dashboard knob sounds when the user enables it.
            if (OldCarSounds.DisableKnobSoundsSettings.GetValue()) {
                // Define the audio source
                _dashButtonAudio = GameObject.Find("CarFoley/dash_button").GetComponent<AudioSource>();
            }

            // Define the key sounds
            if (OldCarSounds.KeySoundSelectionSettings.GetValue() != 0) {
                _carKeysIn = GameObject.Find("CarFoley/carkeys_in");
                _carKeysOut = GameObject.Find("CarFoley/carkeys_out");
                _carKeysSwitch = GameObject.Find("CarFoley/ignition_keys");
            }

            // Define door sounds
            if (OldCarSounds.DisableDoorSoundsSettings.GetValue()) {
                _openDoorSound = GameObject.Find("CarFoley/open_door1");
                _openHoodSound = GameObject.Find("CarFoley/open_hood1");
                _openTrunkSound = GameObject.Find("CarFoley/open_trunk1");
                _closeDoorSound = GameObject.Find("CarFoley/close_door1");
                _closeHoodSound = GameObject.Find("CarFoley/close_hood1");
                _closeTrunkSound = GameObject.Find("CarFoley/close_trunk1");
            }

            if (OldCarSounds.DisableFootSoundsSettings.GetValue()) {
                _walkingSoundsParent = GameObject.Find("Walking");
            }
        }

        private void Update() {
            if (ModLoader.GetCurrentScene() == CurrentScene.Game) {

                // Car key sounds
                if (OldCarSounds.KeySoundSelectionSettings.GetValue() != 0) {

                    // Old key sounds (2016)
                    if (OldCarSounds.KeySoundSelectionSettings.GetValue() == 1 || OldCarSounds.KeySoundSelectionSettings.GetValue() == 2) {

                        // Disable the carkeysin and carkeysout sounds
                        if (_carKeysIn.GetComponent<AudioSource>().isPlaying) {
                            _carKeysIn.GetComponent<AudioSource>().Stop();
                        }

                        if (_carKeysOut.GetComponent<AudioSource>().isPlaying) {
                            _carKeysOut.GetComponent<AudioSource>().Stop();
                        }
                    }

                    if (OldCarSounds.KeySoundSelectionSettings.GetValue() == 2) {
                        if (_carKeysSwitch.GetComponent<AudioSource>().isPlaying) {
                            _carKeysSwitch.GetComponent<AudioSource>().Stop();
                        }
                    }
                }

                // If the user has chosen to
                if (OldCarSounds.DisableKnobSoundsSettings.GetValue()) {

                    // Disable the dashboard sound constantly.
                    if (_dashButtonAudio.isPlaying) {
                        _dashButtonAudio.Stop();
                    }
                }

                if (OldCarSounds.DisableFootSoundsSettings.GetValue()) {
                    foreach (AudioSource item in _walkingSoundsParent.GetComponentsInChildren<AudioSource>()) {
                        if (item.isPlaying) {
                            item.Stop();
                        }
                    }
                }

                if (OldCarSounds.DisableDoorSoundsSettings.GetValue()) {
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

                if (OldCarSounds.OldDelaySettings.GetValue()) {
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
