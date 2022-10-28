using System.Diagnostics;
using System;
using System.IO;
using System.Reflection;
using HutongGames.PlayMaker;
using MSCLoader;
using UnityEngine;
using HutongGames.PlayMaker.Actions;
using Object = UnityEngine.Object;
using OldCarSounds.Stuff;

namespace GoodOldMSC.Mods {
	public class OldCarSounds {

        public OldCarSounds() {
            _stopwatch = Stopwatch.StartNew();
        }

        public void Load() {
		}

		public void Update() {
		}

		public void ModSettings(Mod mod) {
        }

        private Stopwatch _stopwatch;

        public void OnGUI() {
        }
    }
}