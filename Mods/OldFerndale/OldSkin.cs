using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class OldSkin
    {
        internal static void ApplyOldSkin(AssetBundle resource, SettingsSliderInt oldSkin)
        {
            switch (oldSkin.GetValue())
            {
                case 1:
                    ApplyOldSkin_2016(resource);
                    break;
                case 2:
                    ApplyOldSkin_178(resource);
                    break;
                case 3:
                    ApplyOldSkin_Red(resource);
                    break;
                case 4:
                    ApplyOldSkin_Blue(resource);
                    break;
                case 5:
                    ApplyOldSkin_Black(resource);
                    break;
            }
        }

        private static void ApplyOldSkin_Black(AssetBundle resource)
        {
            var texture = resource.LoadAsset<Material>("black.mat");
            var ferndaleBody = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_body");
            ferndaleBody.GetComponent<Renderer>().material = texture;

            var leftDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(leftx)/door");
            leftDoor.GetComponent<Renderer>().material = texture;

            var rightDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(right)/door 1");
            rightDoor.GetComponent<Renderer>().material = texture;

            var bootlid = GameObject.Find("FERNDALE(1630kg)/Bootlid/Bootlid/muscle_bootlid");
            bootlid.GetComponent<Renderer>().material = texture;
        }

        private static void ApplyOldSkin_Blue(AssetBundle resource)
        {
            var texture = resource.LoadAsset<Material>("blue.mat");
            var ferndaleBody = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_body");
            ferndaleBody.GetComponent<Renderer>().material = texture;

            var leftDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(leftx)/door");
            leftDoor.GetComponent<Renderer>().material = texture;

            var rightDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(right)/door 1");
            rightDoor.GetComponent<Renderer>().material = texture;

            var bootlid = GameObject.Find("FERNDALE(1630kg)/Bootlid/Bootlid/muscle_bootlid");
            bootlid.GetComponent<Renderer>().material = texture;
        }

        private static void ApplyOldSkin_Red(AssetBundle resource)
        {
            var texture = resource.LoadAsset<Material>("red.mat");
            var ferndaleBody = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_body");
            ferndaleBody.GetComponent<Renderer>().material = texture;

            var leftDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(leftx)/door");
            leftDoor.GetComponent<Renderer>().material = texture;

            var rightDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(right)/door 1");
            rightDoor.GetComponent<Renderer>().material = texture;

            var bootlid = GameObject.Find("FERNDALE(1630kg)/Bootlid/Bootlid/muscle_bootlid");
            bootlid.GetComponent<Renderer>().material = texture;
        }

        private static void ApplyOldSkin_178(AssetBundle resource)
        {
            var texture = resource.LoadAsset<Material>("muscle_178.mat");
            var ferndaleBody = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_body");
            ferndaleBody.GetComponent<Renderer>().material = texture;

            var leftDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(leftx)/door");
            leftDoor.GetComponent<Renderer>().material = texture;

            var rightDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(right)/door 1");
            rightDoor.GetComponent<Renderer>().material = texture;

            var bootlid = GameObject.Find("FERNDALE(1630kg)/Bootlid/Bootlid/muscle_bootlid");
            bootlid.GetComponent<Renderer>().material = texture;
        }

        private static void ApplyOldSkin_2016(AssetBundle resource)
        {
            var texture = resource.LoadAsset<Material>("muscle_2016.mat");
            var ferndaleBody = GameObject.Find("FERNDALE(1630kg)/MESH/muscle_body");
            ferndaleBody.GetComponent<Renderer>().material = texture;

            var leftDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(leftx)/door");
            leftDoor.GetComponent<Renderer>().material = texture;

            var rightDoor = GameObject.Find("FERNDALE(1630kg)/DriverDoors/door(right)/door 1");
            rightDoor.GetComponent<Renderer>().material = texture;

            var bootlid = GameObject.Find("FERNDALE(1630kg)/Bootlid/Bootlid/muscle_bootlid");
            bootlid.GetComponent<Renderer>().material = texture;
        }
    }
}
