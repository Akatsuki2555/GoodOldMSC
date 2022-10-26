using System.IO;
using MSCLoader;

namespace GoodOldMSC {
	public class Util {
		public static string GetPathForMod(Mod mod, string fileName) {
			return Path.Combine(ModLoader.GetModAssetsFolder(mod), fileName);
		}
	}
}