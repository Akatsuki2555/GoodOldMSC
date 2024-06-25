using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class RemoveYellowBars
    {
        internal static void ApplyRemoveYellowBars(AssetBundle bundle, SettingsCheckBox isRemoveYellowBarsOn,
            SettingsCheckBox isRemoveMudflapsOn)
        {
            if (!isRemoveYellowBarsOn.GetValue()) return;
            var obj1 = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(15)
                .GetChild(0)
                .GetChild(0)
                .GetChild(0)
                .gameObject;
            obj1
                .GetComponent<MeshFilter>()
                .sharedMesh = bundle.LoadAsset<Mesh>("rear_axle_old.obj");
            obj1.GetComponent<MeshRenderer>().material = bundle.LoadAsset<Material>("rear_axle.mat");

            if (!isRemoveMudflapsOn.GetValue()) return;
            var chassis1 = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(14)
                .GetChild(6)
                .gameObject;

            var mat = chassis1
                .transform
                .parent
                .GetChild(0)
                .gameObject
                .GetComponent<MeshRenderer>()
                .material;

            chassis1
                .GetComponent<MeshFilter>()
                .sharedMesh = bundle.LoadAsset<Mesh>("rear_axle_old_chassis.obj");

            chassis1
                .GetComponent<MeshRenderer>()
                .material = mat;
        }
    }
}
