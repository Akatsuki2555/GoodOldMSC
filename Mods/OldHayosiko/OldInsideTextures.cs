using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldHayosiko
{
    internal class OldInsideTextures
    {
        internal static void ApplyOldInsideTextures(AssetBundle assetBundle, bool isOldInsideTextureOn,
            bool isRemoveDashboardOn)
        {
            if (!isOldInsideTextureOn) return;
            if (isRemoveDashboardOn) return;
            // GameObject.Find("HAYOSIKO(1500kg, 250)/LOD/generalPivot/van_interior").GetComponent<Renderer>()
            //     .material = assetBundle.LoadAsset<Material>("dashboard_old");

            GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(6)
                .GetChild(10)
                .GetChild(6)
                .gameObject
                .GetComponent<Renderer>()
                .material = assetBundle.LoadAsset<Material>("dashboard_old");
        }
    }
}
