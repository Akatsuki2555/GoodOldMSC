using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class RemoveRearAxle
    {
        internal static void ApplyRemoveRearAxle(SettingsCheckBox removeRearAxle)
        {
            if (!removeRearAxle.GetValue()) return;
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(15)
                .GetChild(0)
                .gameObject
                .SetActive(false);
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(16)
                .GetChild(0)
                .gameObject
                .SetActive(false);
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(6)
                .gameObject
                .SetActive(false);
        }
    }
}
