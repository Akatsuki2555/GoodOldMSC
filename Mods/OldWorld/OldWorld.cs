using MSCLoader;

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
        private SettingsCheckBox _oldRoad, _oldDirtRoad, _oldDirtRaceTrack, _removeBridges, _oldDrivewayTexture, _removeTreeWalls;

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
            if (_oldRoad.GetValue()) GameObject.Find("MAP")
                    .transform.Find("MESH/TERRAIN_OBJ/Road").GetComponent<Renderer>().sharedMaterial.mainTexture = texture2D2;
            if (_oldDirtRoad.GetValue()) GameObject.Find("MAP")
                    .transform.Find("MESH/TERRAIN_OBJ/DirtRoad").GetComponent<Renderer>().sharedMaterial.mainTexture = texture2D;
            if (_oldDirtRaceTrack.GetValue()) GameObject.Find("MAP")
                    .transform.Find("MESH/TERRAIN_OBJ/Gravel").GetComponent<Renderer>().sharedMaterial.mainTexture = texture2D;
            if (_oldDrivewayTexture.GetValue()) GameObject.Find("YARD")
                    .transform.Find("Building/MeshLOD/house_base_concrete").GetComponent<Renderer>().sharedMaterial.mainTexture = texture2D3;
            if (_removeBridges.GetValue())
            {
                GameObject.Find("MAP")
                    .transform.Find("MESH/BRIDGE_dirt").gameObject.SetActive(false);
                GameObject.Find("MAP")
                    .transform.Find("MESH/BRIDGE_highway").gameObject.SetActive(false);
            }
            if (_removeTreeWalls.GetValue())
            {
                Transform t= GameObject.Find("MAP")
                    .transform.Find("MESH");
                for (int i = 0; i < t.childCount; i++)
                {
                    Transform child = t.GetChild(i);
                    if (child.name == "LogwallLarge")
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
            assetBundle.Unload(false);
        }

        internal void ModSettings(Mod mod)
        {
            _oldRoad = Settings.AddCheckBox(mod, "oldRoad", "Old Road", false);
            _oldDirtRoad = Settings.AddCheckBox(mod, "oldDirtRoad", "Old Dirt Road", false);
            _oldDirtRaceTrack = Settings.AddCheckBox(mod, "oldDirtRaceTrack", "Old Dirt Race Track", false);
            _oldDrivewayTexture = Settings.AddCheckBox(mod, "oldDrivewayTexture", "Old Driveway Texture", false);
            _removeBridges = Settings.AddCheckBox(mod, "removeBridges", "Remove Bridges", false);
            _removeTreeWalls = Settings.AddCheckBox(mod, "removeTreeWalls", "Remove Tree Walls", false);
        }
    }
}
