using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using GoodOldMSC.Mods;
using MSCLoader;
using UnityEngine;

namespace GoodOldMSC {
	// ReSharper disable once UnusedType.Global
	public class GoodOldMsc : Mod {
		public override string ID => "GoodOldMSC";
		public override string Version => "1.0";
		public override string Author => "mldkyt";

		public override bool UseAssetsFolder => true;

		private readonly Mods.OldCarSounds _oldCarSounds = new Mods.OldCarSounds();

		private readonly Settings _ocsEnabled = new Settings("ocs", "OldCarSounds enabled", false);

		public override void OnLoad() {
			if ((bool)_ocsEnabled.Value) {
				_oldCarSounds.Load();
			}
		}
		
		public override void OnGUI() {
		}

		public override void Update() {
			_oldCarSounds.Update();
		}

		public override void ModSettings() {
			Settings.AddHeader(this, "Satsuma");

			#region Satsuma

			Settings.AddCheckBox(this, _ocsEnabled);
			Settings.AddText(this, "These are settings from OldCarSounds.");

			#endregion
		}
	}
}