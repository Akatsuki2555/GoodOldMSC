using MSCLoader;

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
			if ((bool) _ocsEnabled.Value) {
				_oldCarSounds.OnGUI();
            }
		}

		public override void Update() {
			if ((bool) _ocsEnabled.Value) {
				_oldCarSounds.Update();
			}
		}

		public override void ModSettings() {
			Settings.AddText(this, "Since the mod is in alpha, more features will be added in the future.");
			Settings.AddHeader(this, "Satsuma");

			#region Satsuma

			Settings.AddCheckBox(this, _ocsEnabled);
			_oldCarSounds.ModSettings(this);

			#endregion
		}
	}
}