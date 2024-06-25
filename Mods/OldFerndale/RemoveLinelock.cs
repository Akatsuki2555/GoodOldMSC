using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class RemoveLinelock
    {
        internal static void ApplyRemoveLinelock(SettingsCheckBox removeLinelockButton)
        {
            if (!removeLinelockButton.GetValue()) return;
            var go = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(3)
                .GetChild(7)
                .GetChild(0)
                .GetChild(2)
                .gameObject;
            go.SetActive(false);
        }
    }
}
