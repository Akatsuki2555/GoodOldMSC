using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class OldLicensePlate
    {
        internal static void ApplyOldLicensePlate(SettingsCheckBox oldLicensePlate)
        {
            if (!oldLicensePlate.GetValue()) return;
            var hayoRegPlate = GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(6)
                .GetChild(14)
                .gameObject;

            var ferndaleFrontRegPlate = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(11)
                .gameObject;

            var ferndaleRearRegPlate = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(12)
                .gameObject;

            ferndaleFrontRegPlate.GetComponent<Renderer>()
                .material = hayoRegPlate.GetComponent<Renderer>()
                .material;

            ferndaleRearRegPlate.GetComponent<Renderer>()
                .material = hayoRegPlate.GetComponent<Renderer>()
                .material;
        }
    }
}
