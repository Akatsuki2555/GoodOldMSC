using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldHayosiko
{
    internal class SteeringWheel
    {
        internal static void ApplySteeringWheel(AssetBundle assetBundle, bool isOldSteeringWheelOn)
        {
            if (!isOldSteeringWheelOn) return;
            // var steeringWheel = GameObject
            //     .Find("KEKMET(350-400psi)/LOD/Dashboard/Steering/TractorSteeringPivot/valmet_steering")
            //     .GetComponent<MeshFilter>().mesh;
            var steeringWheel = GameObject.Find("KEKMET(350-400psi)")
                .transform
                .Find("LOD/Dashboard/Steering/TractorSteeringPivot/valmet_steering")
                .gameObject
                .GetComponent<MeshFilter>()
                .mesh;
            // GameObject.Find("HAYOSIKO(1500kg, 250)/LOD/Dashboard/Steering/VanSteeringPivot/steering")
            //     .GetComponent<MeshFilter>().mesh = steeringWheel;
            var hayoSteering = GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .Find("LOD/Dashboard/Steering/VanSteeringPivot/steering")
                .gameObject;
            hayoSteering
                .GetComponent<MeshFilter>()
                .mesh = steeringWheel;
            // GameObject.Find("HAYOSIKO(1500kg, 250)/LOD/Dashboard/Steering/VanSteeringPivot/steering").transform
            //     .localPosition = new Vector3(0.0f, 0.0f, -0.13f);
            hayoSteering
                .transform
                .localPosition = new Vector3(0.0f, 0.0f, -0.13f);
            // GameObject.Find("HAYOSIKO(1500kg, 250)/LOD/Dashboard/Steering/VanSteeringPivot/steering")
            //     .GetComponent<Renderer>().material = assetBundle.LoadAsset<Material>("black");
            hayoSteering
                .GetComponent<Renderer>()
                .material = assetBundle.LoadAsset<Material>("black");
        }
    }
}
