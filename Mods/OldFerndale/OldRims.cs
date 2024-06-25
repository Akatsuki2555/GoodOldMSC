using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class OldRims
    {
        internal static void ApplyOldRims(AssetBundle resource, SettingsSliderInt oldWheels)
        {
            switch (oldWheels.GetValue())
            {
                case 1:
                    ApplyOldRims_2016(resource);
                    break;
                case 2:
                    ApplyOldRims_178(resource);
                    break;
                case 3:
                    ApplyOldRims_OlderThan176(resource);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invalid old wheels value: {oldWheels.GetValue()}");
            }
        }

        private static void ApplyOldRims_OlderThan176(AssetBundle resource)
        {
            var innerMesh = resource.LoadAsset<Mesh>("drag_rim_inner3.asset");
            var outerMesh = resource.LoadAsset<Mesh>("drag_rim_outer.asset");

            var wheelFl = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(13)
                .GetChild(1)
                .GetChild(0)
                .GetChild(1);

            var wheelFr = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(14)
                .GetChild(1)
                .GetChild(0)
                .GetChild(2);

            // FRONT LEFT
            wheelFl.GetChild(0).GetComponent<MeshFilter>().mesh = innerMesh;
            wheelFl.GetChild(0).localPosition = new Vector3(0f, 0f, 0f);
            wheelFl.GetChild(0).localRotation = Quaternion.Euler(0f, 180f, 0f);
            wheelFl.GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            wheelFl.GetComponent<MeshFilter>().mesh = outerMesh;
            wheelFl.localPosition = new Vector3(0f, 0f, 0f);
            wheelFl.localRotation = Quaternion.Euler(0f, 180f, 0f);
            wheelFl.localScale = new Vector3(0.95f, 1.1f, 1.1f);

            // FRONT RIGHT
            wheelFr.GetChild(0).GetComponent<MeshFilter>().mesh = innerMesh;
            wheelFr.GetChild(0).localPosition = new Vector3(0f, 0f, 0f);
            wheelFr.GetChild(0).localRotation = Quaternion.Euler(0f, 0f, 0f);
            wheelFr.GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            wheelFr.GetComponent<MeshFilter>().mesh = outerMesh;
            wheelFr.localPosition = new Vector3(0f, 0f, 0f);
            wheelFr.localRotation = Quaternion.Euler(0f, 0f, 0f);
            wheelFr.localScale = new Vector3(0.95f, 1.1f, 1.1f);

            var wheelRl = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(15)
                .GetChild(1)
                .GetChild(0)
                .GetChild(1);

            var wheelRr = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(16)
                .GetChild(1)
                .GetChild(0)
                .GetChild(1);

            // REAR LEFT
            wheelRl.GetChild(0).GetComponent<MeshFilter>().mesh = innerMesh;
            wheelRl.GetChild(0).localPosition = new Vector3(0f, 0f, 0f);
            wheelRl.GetChild(0).localRotation = Quaternion.Euler(0, 0, 0);
            wheelRl.GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            wheelRl.GetComponent<MeshFilter>().mesh = outerMesh;
            // wheelRL.localPosition = new Vector3(-0.015f, 0f, 0f);
            wheelRl.localPosition = new Vector3(0f, 0f, 0f);
            wheelRl.localRotation = Quaternion.Euler(0, 0, 0);
            wheelRl.localScale = new Vector3(0.95f, 1.1f, 1.1f);

            // REAR RIGHT
            wheelRr.GetChild(0).GetComponent<MeshFilter>().mesh = innerMesh;
            wheelRr.GetChild(0).localPosition = new Vector3(0f, 0f, 0f);
            wheelRr.GetChild(0).localRotation = Quaternion.Euler(0, 0, 0);
            wheelRr.GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            wheelRr.GetComponent<MeshFilter>().mesh = outerMesh;
            wheelRr.localPosition = new Vector3(0f, 0f, 0f);
            wheelRr.localRotation = Quaternion.Euler(0, 0, 0);
            wheelRr.localScale = new Vector3(0.95f, 1.1f, 1.1f);
        }

        private static void ApplyOldRims_178(AssetBundle resource)
        {
            var mesh = resource.LoadAsset<Mesh>("rim_old_1.asset");

            var wheelFl = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(13)
                .GetChild(1)
                .GetChild(0)
                .GetChild(1);

            var wheelFr = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(14)
                .GetChild(1)
                .GetChild(0)
                .GetChild(2);

            wheelFl.GetChild(0).gameObject.SetActive(false);
            wheelFl.GetComponent<MeshFilter>().mesh = mesh;
            wheelFr.GetChild(0).gameObject.SetActive(false);
            wheelFr.GetComponent<MeshFilter>().mesh = mesh;

            var wheelRl = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(15)
                .GetChild(1)
                .GetChild(0)
                .GetChild(1);

            var wheelRr = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(16)
                .GetChild(1)
                .GetChild(0)
                .GetChild(1);

            wheelRl.GetChild(0).gameObject.SetActive(false);
            wheelRl.GetComponent<MeshFilter>().mesh = mesh;
            wheelRr.GetChild(0).gameObject.SetActive(false);
            wheelRr.GetComponent<MeshFilter>().mesh = mesh;
        }

        private static void ApplyOldRims_2016(AssetBundle resource)
        {
            var frontMesh = resource.LoadAsset<Mesh>("rim_inner_front.asset");

            var wheelFl = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(13)
                .GetChild(1)
                .GetChild(0)
                .GetChild(1)
                .GetChild(0);

            var wheelFr = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(14)
                .GetChild(1)
                .GetChild(0)
                .GetChild(2)
                .GetChild(0);

            wheelFl.GetComponent<MeshFilter>().mesh = frontMesh;
            wheelFr.GetComponent<MeshFilter>().mesh = frontMesh;

            var rearMesh = resource.LoadAsset<Mesh>("rim_inner_rear.asset");

            var wheelRl = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(15)
                .GetChild(1)
                .GetChild(0)
                .GetChild(1)
                .GetChild(0);

            var wheelRr = GameObject.Find("FERNDALE(1630kg)")
                .transform
                .GetChild(16)
                .GetChild(1)
                .GetChild(0)
                .GetChild(1)
                .GetChild(0);

            wheelRl.GetComponent<MeshFilter>().mesh = rearMesh;
            wheelRr.GetComponent<MeshFilter>().mesh = rearMesh;
        }
    }
}
