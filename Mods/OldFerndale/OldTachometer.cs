using HutongGames.PlayMaker.Actions;
using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class OldTachometer
    {
        internal static void ApplyOldTachometer(AssetBundle resource, SettingsSliderInt tachometer)
        {
            switch (tachometer.GetValue())
            {
                case 1:
                    ApplyOldTachometer_2016(resource);
                    break;
                case 2:
                    ApplyOldTachometer_Disable();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void ApplyOldTachometer_Disable()
        {
            GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(3)
                .GetChild(1)
                .GetChild(5)
                .gameObject
                .SetActive(false);
        }

        private static void ApplyOldTachometer_2016(AssetBundle resource)
        {
            var tachometer = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(1)
                .GetChild(3)
                .GetChild(1)
                .GetChild(5);

            var model = tachometer.GetChild(0);
            model.GetComponent<MeshFilter>().mesh = resource.LoadAsset<Mesh>("muscle_tacho.asset");

            var dash = model.GetChild(0);
            dash.GetComponent<MeshFilter>().mesh = resource.LoadAsset<Mesh>("muscle_tacho_dash.asset");
            dash.GetComponent<Renderer>().material = resource.LoadAsset<Material>("rpm_gauge.mat");

            var pivot = tachometer.GetChild(1);
            pivot.transform.localPosition = new Vector3(-0.012f, 0.004f, 0.01f);
            pivot.transform.localRotation = Quaternion.Euler(40.579f, 23.866f, 77.57f);

            var rpmMeter = pivot.GetComponent<PlayMakerFSM>()
                .GetState("State 1");

            rpmMeter.GetAction<FloatOperator>(1).float2.Value = 30f;
            rpmMeter.GetAction<FloatClamp>(2).maxValue.Value = 250;

            var needle = pivot.GetChild(0);
            needle.GetComponent<MeshFilter>().mesh = resource.LoadAsset<Mesh>("needle_minute.asset");
            var needleTransform = needle.transform;
            needleTransform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            needleTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            needleTransform.localScale = Vector3.one;
        }
    }
}
