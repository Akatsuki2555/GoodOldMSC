using UnityEngine;

namespace GoodOldMSC.Mods.OldCarSounds {

    public class RPMGauge : MonoBehaviour {

        private void Start() {
            if (OldCarSounds.OldRpmGaugeSettings.GetValue()) {
                GameObject o = transform.FindChild("Pivot/needle").gameObject;
                o.transform.localScale = new Vector3(0.64f, 1, 0.8f);
            }
        }
    }
}
