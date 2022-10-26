using System.Diagnostics;
using System;
using System.IO;
using System.Reflection;
using HutongGames.PlayMaker;
using MSCLoader;
using UnityEngine;

namespace GoodOldMSC.Mods {
	public class OldCarSounds {
		private GameObject _satsuma;

		private AudioClip engineOff;
		private AudioClip engineOn;
		private AudioClip assemble;

		private Material noSelectionWhite;
		private Material noSelection;
		private Material selection;

        Settings AssembleSounds = new Settings("assembleSounds", "Assemble Sounds", false);
        Settings DisableDoorSoundsSettings = new Settings("doorSounds", "Disable Door Sounds", false);
        Settings DisableFootSoundsSettings = new Settings("footSounds", "Disable Foot Sounds", false);
        Settings DisableKnobSoundsSettings = new Settings("knobSounds", "Disable Knob Sounds", false);
        Settings OldDashTexturesSettings = new Settings("oldDash", "Old Dashboard", false);
        Settings InfoTextSettings = new Settings("info", "Information Text", false);
        Settings OldRadioSongsSettings = new Settings("radio", "Old Radio", false);
        Settings ShiftDelaySelectionSettings = new Settings("shiftDelay", "Shift Delay Selection", 0b0);
        Settings KeySoundSelectionSettings = new Settings("keySound", "Key Sound Selection", 0b0);
        Settings SelectionSelectionSettings = new Settings("selection", "Green selections", false);
        Settings EngineSoundsTypeSettings = new Settings("sounds", "Engine sound type", 0b0);
        Settings OldRpmGaugeSettings = new Settings("rpmgauge", "Old RPM Gauge", false);
        Settings OldDelaySettings = new Settings("oldrev", "Old engine revving", false);

        public OldCarSounds() {
            _stopwatch = Stopwatch.StartNew();
        }

        public void Load() {
			_satsuma = GameObject.Find("SATSUMA(557kg, 248)");

			byte[] bytes = null;
			using (Stream fs = Assembly.GetExecutingAssembly().GetManifestResourceStream("GoodOldMSC.Resources.oldcarsounds.unity3d")) {
				if (fs != null) {
					bytes = new byte[fs.Length];
					int read = fs.Read(bytes, 0, bytes.Length);
				}
				else {
					ModConsole.Log("Error while reading, isn't assembly corrupted?");
				}
			}
			
			AssetBundle assetBundle = AssetBundle.CreateFromMemoryImmediate(bytes);
			engineOn = assetBundle.LoadAsset<AudioClip>("idle_sisa");
			engineOff = assetBundle.LoadAsset<AudioClip>("idle");
			assemble = assetBundle.LoadAsset<AudioClip>("assemble");
		}

		public void Update() {
			
		}

		public void ModSettings(Mod mod) {
            Settings.AddSlider(mod, ShiftDelaySelectionSettings, 0, 2, new[] {
                "No change",
                "Build 172",
                "No delay"
            });
            Settings.AddSlider(mod, KeySoundSelectionSettings, 0, 2, new[] {
                "No change",
                "Old key sounds (2016)",
                "No key sounds (2014)"
            });
            Settings.AddSlider(mod, EngineSoundsTypeSettings, 0, 2, new[] {
                "No engine sound change",
                "Lower pitch (2016)",
                "Old alpha (2014)"
            });
            Settings.AddCheckBox(mod, SelectionSelectionSettings);
            Settings.AddCheckBox(mod, AssembleSounds);
            Settings.AddCheckBox(mod, DisableDoorSoundsSettings);
            Settings.AddCheckBox(mod, DisableFootSoundsSettings);
            Settings.AddCheckBox(mod, DisableKnobSoundsSettings);
            Settings.AddCheckBox(mod, OldDashTexturesSettings);
            Settings.AddCheckBox(mod, InfoTextSettings);
            Settings.AddCheckBox(mod, OldRadioSongsSettings);
            Settings.AddCheckBox(mod, OldRpmGaugeSettings);
        }

        private Stopwatch _stopwatch;

        public void OnGUI() {
            if (ModLoader.GetCurrentScene() != CurrentScene.Game) {
                return;
            }

            if (!(bool)InfoTextSettings.Value) {
                return;
            }

            float fps = (float)Math.Round(1f / Time.unscaledDeltaTime, 2);
            float wrenchSize = FsmVariables.GlobalVariables.GetFsmFloat("ToolWrenchSize").Value;
            GUI.Label(new Rect(0, 0, 1000, 20), $"FPS: {fps}");
            GUI.Label(new Rect(0, 20, 1000, 20), $"Wrench size: {wrenchSize}");
            GUI.Label(new Rect(0, 40, 1000, 20),
            $"Lake run current time: {_stopwatch.Elapsed.Minutes}:{_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
            GUI.Label(new Rect(0, 60, 1000, 20), "Lake run last time: ");
        }
	}
}