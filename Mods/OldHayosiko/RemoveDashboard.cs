using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldHayosiko
{
    internal class RemoveDashboard
    {
        internal static void ApplyRemoveDashboard(bool isRemoveDashboardOn)
        {
            if (!isRemoveDashboardOn) return;
            try
            {
                GameObject.Find("HAYOSIKO(1500kg, 250)")
                    .transform
                    .GetChild(6)
                    .GetChild(10)
                    .GetChild(6)
                    .gameObject
                    .SetActive(false);
            }
            catch
            {
                ModConsole.LogWarning("Unable to load \"Remove dashboard\"");
            }
        }
    }
}
