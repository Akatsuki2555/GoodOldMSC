using System.IO;
using System.Reflection;
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
	}
}