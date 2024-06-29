using System;
using GoodOldMSC.Mods.OldCarSounds;
using GoodOldMSC.Mods.OldFerndale;
using GoodOldMSC.Mods.OldHayosiko;
using GoodOldMSC.Mods.OldHighwayCars;
using GoodOldMSC.Mods.OldKekmet;
using GoodOldMSC.Mods.OldTruckSounds;
using GoodOldMSC.Mods.OldWorld;

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
		private OldFerndale _of = new OldFerndale();
		private OldKekmet _ok = new OldKekmet();
		private OldWorld _ow = new OldWorld();
		private OldHighwayCars _ohc = new OldHighwayCars();
			
		private SettingsCheckBox _ocsEnabled;
		private SettingsCheckBox _ohEnabled;
		private SettingsCheckBox _otEnabled;
		private SettingsCheckBox _ofEnabled;
		private SettingsCheckBox _okEnabled;
		private SettingsCheckBox _owEnabled;
		private SettingsCheckBox _ohcEnabled;

        public override void ModSetup()
        {
            base.ModSetup();
			// Let's register all of the methods here

			SetupFunction(Setup.OnLoad, Mod_Load);
			SetupFunction(Setup.OnGUI, Mod_OnGUI);
			SetupFunction(Setup.Update, Mod_Update);
        }

        private void Mod_Load() {
			try
			{
                if (_ocsEnabled.GetValue())
                {
                    _ocs.OnLoad(this);
                }
            }
			catch (Exception e)
			{
				ModConsole.LogError("OldCarSounds");
				ModConsole.LogError(e.Message);
				ModConsole.LogError(e.StackTrace.ToString());
			}

			try
			{
                if (_ohEnabled.GetValue())
                {
                    _oh.OnLoad();
                }
            }
            catch (Exception e)
            {
                ModConsole.LogError("OldCarSounds");
                ModConsole.LogError(e.Message);
                ModConsole.LogError(e.StackTrace.ToString());
            }

            try
			{
                if (_otEnabled.GetValue())
                {
                    _ot.OnLoad();
                }
            }
            catch (Exception e)
            {
                ModConsole.LogError("OldCarSounds");
                ModConsole.LogError(e.Message);
                ModConsole.LogError(e.StackTrace.ToString());
            }

            try
			{
                if (_ofEnabled.GetValue())
                {
                    _of.Mod_Load();
                }
            }
            catch (Exception e)
            {
                ModConsole.LogError("OldCarSounds");
                ModConsole.LogError(e.Message);
                ModConsole.LogError(e.StackTrace.ToString());
            }

            try
			{
                if (_okEnabled.GetValue())
                {
                    _ok.Mod_Load();
                }
            }
            catch (Exception e)
            {
                ModConsole.LogError("OldCarSounds");
                ModConsole.LogError(e.Message);
                ModConsole.LogError(e.StackTrace.ToString());
            }

            try
			{
                if (_owEnabled.GetValue())
                {
                    _ow.OnLoad();
                }
            }
            catch (Exception e)
            {
                ModConsole.LogError("OldCarSounds");
                ModConsole.LogError(e.Message);
                ModConsole.LogError(e.StackTrace.ToString());
            }

            try
			{
                if (_ohcEnabled.GetValue())
                {
                    _ohc.OnLoad();
                }
            }
            catch (Exception e)
            {
                ModConsole.LogError("OldCarSounds");
                ModConsole.LogError(e.Message);
                ModConsole.LogError(e.StackTrace.ToString());
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

			_ofEnabled = Settings.AddCheckBox(this, "ofEnable", "Enable Old Ferndale", false);
			_of.ModSettings(this);

			_okEnabled = Settings.AddCheckBox(this, "okEnable", "Enable Old Kekmet", false);
			_ok.ModSettings(this);

            _owEnabled = Settings.AddCheckBox(this, "owEnable", "Enable Old World", false);
            _ow.ModSettings(this);

            _ohcEnabled = Settings.AddCheckBox(this, "ohcEnable", "Enable Old Highway Cars", false);
        }
	}
}