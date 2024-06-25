using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldHayosiko
{
    internal class OldOutsideTextures
    {
        internal static void ApplyOldOutsideTexture(AssetBundle assetBundle, bool isOldOutsideTextureOn)
        {
            if (!isOldOutsideTextureOn)
                return;
            // GameObject.Find("HAYOSIKO(1500kg, 250)/body").GetComponent<Renderer>().material =
            //     assetBundle.LoadAsset<Material>("body_mat");
            GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(15)
                .gameObject
                .GetComponent<Renderer>()
                .material = assetBundle.LoadAsset<Material>("body_mat");

            // GameObject.Find("HAYOSIKO(1500kg, 250)/SideDoor/door").GetComponent<Renderer>().material =
            //     assetBundle.LoadAsset<Material>("body_mat");
            GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(14)
                .GetChild(0)
                .gameObject
                .GetComponent<Renderer>()
                .material = assetBundle.LoadAsset<Material>("body_mat");

            // GameObject.Find("HAYOSIKO(1500kg, 250)/RearDoor/doorear/door").GetComponent<Renderer>().material =
            //     assetBundle.LoadAsset<Material>("body_mat");
            GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(13)
                .GetChild(0)
                .GetChild(2)
                .gameObject
                .GetComponent<Renderer>()
                .material = assetBundle.LoadAsset<Material>("body_mat");

            // GameObject.Find("HAYOSIKO(1500kg, 250)/RearDoor/doorear/GlassRear").SetActive(false);
            GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(13)
                .GetChild(0)
                .GetChild(1)
                .gameObject
                .SetActive(false);

            // GameObject.Find("HAYOSIKO(1500kg, 250)/DriverDoors/doorl/door").GetComponent<Renderer>().material =
            //     assetBundle.LoadAsset<Material>("body_mat");
            GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(12)
                .GetChild(0)
                .GetChild(1)
                .gameObject
                .GetComponent<Renderer>()
                .material = assetBundle.LoadAsset<Material>("body_mat");

            // GameObject.Find("HAYOSIKO(1500kg, 250)/DriverDoors/doorl/Window").SetActive(false);
            GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(12)
                .GetChild(0)
                .GetChild(2)
                .gameObject
                .SetActive(false);

            // GameObject.Find("HAYOSIKO(1500kg, 250)/DriverDoors/doorr/door").GetComponent<Renderer>().material =
            //     assetBundle.LoadAsset<Material>("body_mat");                
            GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(12)
                .GetChild(1)
                .GetChild(3)
                .gameObject
                .GetComponent<Renderer>()
                .material = assetBundle.LoadAsset<Material>("body_mat");

            // GameObject.Find("HAYOSIKO(1500kg, 250)/DriverDoors/doorr/Window").SetActive(false);
            GameObject.Find("HAYOSIKO(1500kg, 250)")
                .transform
                .GetChild(12)
                .GetChild(1)
                .GetChild(0)
                .gameObject
                .SetActive(false);

            // Fix interior hole
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = GameObject.Find("HAYOSIKO(1500kg, 250)").transform;
            cube.transform.localPosition = new Vector3(0, 1.494f, 0.958f);
            cube.transform.localScale = new Vector3(1.203f, 0.0368f, 0.7835f);
            cube.transform.localRotation = Quaternion.Euler(0, 0, 0);
            cube.GetComponent<Renderer>().material = assetBundle.LoadAsset<Material>("body_mat");
        }
    }
}
