using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class OldRearWheelsSize
    {
        internal static void ApplyOldRearWheelsSize(SettingsCheckBox oldRearWheelsSize)
        {
            if (!oldRearWheelsSize.GetValue()) return;

            GameObject.Find("FERNDALE(1630kg)").transform
                .GetChild(15)
                .GetChild(1)
                .GetChild(0)
                .localScale = Vector3.one;

            GameObject.Find("FERNDALE(1630kg)").transform
                .GetChild(16)
                .GetChild(1)
                .GetChild(0)
                .localScale = Vector3.one;
        }

    }
}
