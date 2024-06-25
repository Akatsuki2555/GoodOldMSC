using GoodOldMSC.Mods.OldCarSounds;
using GoodOldMSC.Mods.OldHayosiko;
using GoodOldMSC.Mods.OldTruckSounds;

using HutongGames.PlayMaker.Actions;

using MSCLoader;

namespace GoodOldMSC {
	// ReSharper disable once UnusedType.Global
	public class GoodOldMsc : Mod {
		public override string ID => "GoodOldMSC";
		public override string Version => "0.1";
		public override string Author => "アカツキ2555";

		public override bool UseAssetsFolder => true;

		private OldCarSounds _ocs = new OldCarSounds();
		private OldHayosiko _oh = new OldHayosiko();
		private OldTruckSounds _ot = new OldTruckSounds();

		private SettingsCheckBox _ocsEnabled;
		private SettingsCheckBox _ohEnabled;
		private SettingsCheckBox _otEnabled;

        public override void ModSetup()
        {
            base.ModSetup();
			// Let's register all of the methods here

			SetupFunction(Setup.OnLoad, Mod_Load);
			SetupFunction(Setup.OnGUI, Mod_OnGUI);
			SetupFunction(Setup.Update, Mod_Update);
        }

        private void Mod_Load() {
			if (_ocsEnabled.GetValue())
			{
				_ocs.OnLoad(this);
			}

			if (_ohEnabled.GetValue())
            {
                _oh.OnLoad();
            }

			if (_otEnabled.GetValue())
            {
                _ot.OnLoad();
            }
		}
		
		private void Mod_OnGUI() {
			if (_ocsEnabled.GetValue())
			{
				_ocs.OnGUI();
            }
		}

		private void Mod_Update() {
			if (_ocsEnabled.GetValue()) 
			{
				_ocs.Update();
			}
		}

		public override void ModSettings() {
			Settings.AddText(this, "Since the mod is in alpha, more features will be added in the future.");
			Settings.AddHeader(this, "Satsuma");

			_ocsEnabled = Settings.AddCheckBox(this, "ocsEnable", "Enable Old Car Sounds", false);
			_ocs.ModSettings(this);

			_ohEnabled = Settings.AddCheckBox(this, "ohEnable", "Enable Old Hayosiko", false);
			_oh.ModSettings(this);

			_otEnabled = Settings.AddCheckBox(this, "otEnable", "Enable Old Truck Sounds", false);
			_ot.ModSettings(this);
		}
	}
}