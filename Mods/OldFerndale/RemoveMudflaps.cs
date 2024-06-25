using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class RemoveMudflaps
    {
        internal static void ApplyRemoveMudflaps(AssetBundle resource, SettingsCheckBox removeMudflaps, SettingsCheckBox removeYellowBarOnAxle)
        {
            if (!removeMudflaps.GetValue()) return;

            var chassis = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(14)
                .GetChild(0)
                .gameObject;

            chassis.GetComponent<MeshFilter>().sharedMesh = resource.LoadAsset<Mesh>("muscle_chassis.asset");

            if (removeYellowBarOnAxle.GetValue()) return;
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(14)
                .GetChild(6)
                .gameObject
                .SetActive(false);
            // chassis.GetComponent<Renderer>().materials = new Material[1] { new Material(Shader.Find("Diffuse")) { color = Color.white } };
        }
    }
}
