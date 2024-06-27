using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using MSCLoader;
using UnityEngine;

namespace GoodOldMSC.Mods.OldHighwayCars
{
    internal class OldHighwayCars
    {
        private Mesh datsunMesh;

        public void OnLoad()
        {
            byte[] numArray;
            using (var manifestResourceStream = Assembly.GetExecutingAssembly()
                       .GetManifestResourceStream("GoodOldMSC.Resources.highwaysatsuma.unity3d"))
            {
                if (manifestResourceStream == null)
                    throw new Exception("The mod DLL is corrupted, unable to load highwaysatsuma.unity3d. Cannot continue");
                numArray = new byte[manifestResourceStream.Length];
                _ = manifestResourceStream.Read(numArray, 0, numArray.Length);
            }

            var assetBundle = numArray.Length != 0
                ? AssetBundle.CreateFromMemoryImmediate(numArray)
                : throw new Exception("The mod DLL is corrupted, unable to load highwaysatsuma.unity3d. Cannot continue");
            datsunMesh = assetBundle.LoadAsset<Mesh>("datsun_body");
            assetBundle.Unload(false);

            GameObject gameObject = GameObject.Find("TRAFFIC").transform.Find("VehiclesHighway").gameObject;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                GameObject gameObject2 = gameObject.transform.GetChild(i).gameObject;
                if (gameObject2.gameObject.name == "VICTRO" || gameObject2.gameObject.name == "MENACE")
                {
                    gameObject2.transform.Find("victro_interior").gameObject.SetActive(false);
                    gameObject2.transform.Find("victro_parts").gameObject.SetActive(false);
                    gameObject2.transform.Find("LOD").gameObject.SetActive(false);
                    MeshFilter component = gameObject2.transform.Find("body").GetComponent<MeshFilter>();
                    component.mesh = datsunMesh;
                    Transform transform = component.transform;
                    transform.localPosition = new Vector3(0f, 0.47749f, -0.014f);
                    transform.localScale = new Vector3(1.112602f, 1.112602f, 1.112602f);
                }
                if (gameObject2.gameObject.name == "SVOBODA")
                {
                    gameObject2.transform.Find("LOD").gameObject.SetActive(false);
                    gameObject2.transform.Find("PIVOT/parts").gameObject.SetActive(false);
                    gameObject2.transform.Find("PIVOT/parts 3").gameObject.SetActive(false);
                    MeshFilter component2 = gameObject2.transform.Find("PIVOT/body").GetComponent<MeshFilter>();
                    component2.mesh = datsunMesh;
                    Transform transform2 = component2.transform;
                    transform2.localPosition = new Vector3(0f, -0.047f, 0.221f);
                    transform2.localScale = new Vector3(1.112602f, 1.112602f, 1.112602f);
                }
                if (gameObject2.gameObject.name == "POLSA")
                {
                    gameObject2.transform.Find("LOD").gameObject.SetActive(false);
                    gameObject2.transform.Find("MESH/police_interior").gameObject.SetActive(false);
                    gameObject2.transform.Find("MESH/police_parts").gameObject.SetActive(false);
                    MeshFilter component3 = gameObject2.transform.Find("MESH/police_body").GetComponent<MeshFilter>();
                    component3.mesh = datsunMesh;
                    Transform transform3 = component3.transform;
                    transform3.localPosition = new Vector3(3.3204E-05f, 0.5f, 0.0057537f);
                    transform3.localScale = new Vector3(1.12f, 1.12f, 1.12f);
                }
            }

            ModConsole.Print("[OldHighwayCars] Load successful!");
        }

    }
}
