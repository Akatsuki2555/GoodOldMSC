using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class RedInterior
    {
        internal static void ApplyRedInterior(AssetBundle resource, SettingsCheckBox redInterior)
        {
            if (!redInterior.GetValue()) return;
            var mat = resource.LoadAsset<Material>("legacy_red.mat");

            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(14)
                .GetChild(3)
                .GetComponent<Renderer>()
                .material = mat;
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(14)
                .GetChild(4)
                .GetComponent<Renderer>()
                .material = mat;
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(8)
                .GetChild(0)
                .GetChild(0)
                .GetChild(2)
                .GetComponent<Renderer>()
                .material = mat;
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(8)
                .GetChild(1)
                .GetChild(0)
                .GetChild(2)
                .GetComponent<Renderer>()
                .material = mat;
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(12)
                .GetChild(0)
                .GetComponent<Renderer>()
                .material = mat;
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(12)
                .GetChild(1)
                .GetComponent<Renderer>()
                .material = mat;
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(3)
                .GetChild(7)
                .GetChild(0)
                .GetChild(1)
                .GetComponent<Renderer>().material = resource.LoadAsset<Material>("white.mat");
        }
    }
}
