using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldWorld
{
    internal class OldWorld
    {
        internal void OnLoad()
        {
            byte[] numArray;
            using (var manifestResourceStream = Assembly.GetExecutingAssembly()
                       .GetManifestResourceStream("GoodOldMSC.Resources.oldenv.unity3d"))
            {
                if (manifestResourceStream == null)
                    throw new Exception("The mod DLL is corrupted, unable to load oldenv.unity3d. Cannot continue");
                numArray = new byte[manifestResourceStream.Length];
                _ = manifestResourceStream.Read(numArray, 0, numArray.Length);
            }

            var assetBundle = numArray.Length != 0
                ? AssetBundle.CreateFromMemoryImmediate(numArray)
                : throw new Exception("The mod DLL is corrupted, unable to load oldenv.unity3d. Cannot continue");
            Texture2D texture2D = assetBundle.LoadAsset<Texture2D>("dirtroad");
            Texture2D texture2D2 = assetBundle.LoadAsset<Texture2D>("gravel_road");
            Texture2D texture2D3 = assetBundle.LoadAsset<Texture2D>("house_concrete");
            GameObject.Find("MAP/MESH/TERRAIN_OBJ/Road").GetComponent<Renderer>().sharedMaterial.mainTexture = texture2D2;
            GameObject.Find("MAP/MESH/TERRAIN_OBJ/DirtRoad").GetComponent<Renderer>().sharedMaterial.mainTexture = texture2D;
            GameObject.Find("MAP/MESH/TERRAIN_OBJ/Gravel").GetComponent<Renderer>().sharedMaterial.mainTexture = texture2D;
            GameObject.Find("YARD/Building/Mesh/house_base_concrete").GetComponent<Renderer>().sharedMaterial.mainTexture = texture2D3;
            GameObject.Find("MAP/MESH/BRIDGE_dirt").SetActive(false);
            GameObject.Find("MAP/MESH/BRIDGE_highway").SetActive(false);
            GameObject gameObject = GameObject.Find("MAP/MESH");
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Transform child = gameObject.transform.GetChild(i);
                if (child.name == "LogwallLarge")
                {
                    child.gameObject.SetActive(false);
                }
            }
            assetBundle.Unload(false);
        }
    }
}
