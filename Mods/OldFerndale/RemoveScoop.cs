using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class RemoveScoop
    {
        internal static void ApplyRemoveScoop(SettingsCheckBox removeScoop)
        {
            if (!removeScoop.GetValue()) return;
            var scoop = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_Scoop");
            scoop.SetActive(false);
        }
    }
}
