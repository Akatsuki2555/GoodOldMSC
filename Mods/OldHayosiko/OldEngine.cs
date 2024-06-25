using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldHayosiko
{
    internal class OldEngine
    {
        internal static void ApplyOldEngine(AssetBundle assetBundle, bool isOldEngineOn)
        {
            if (!isOldEngineOn) return;
            var component =
                GameObject.Find("HAYOSIKO(1500kg, 250)").GetComponent<SoundController>();
            component.engineThrottle = assetBundle.LoadAsset<AudioClip>("van_engine");
            component.engineThrottlePitchFactor = 1.3f;
            component.engineNoThrottle = assetBundle.LoadAsset<AudioClip>("van_engine");
            component.engineNoThrottlePitchFactor = 1.3f;
            foreach (var componentsInChild in
                     component.gameObject.GetComponentsInChildren<AudioSource>())
            {
                if (componentsInChild == null || componentsInChild.clip == null ||
                    componentsInChild.clip.name != "diesel_idle") continue;
                componentsInChild.clip = assetBundle.LoadAsset<AudioClip>("van_engine");
                componentsInChild.Play();
            }
        }
    }
}
