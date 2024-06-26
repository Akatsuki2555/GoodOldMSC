using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldKekmet
{
    internal class SoundImprovement : MonoBehaviour
    {
        AudioSource throttle, noThrottle;

        void Start()
        {
            noThrottle = transform.GetChild(21).GetComponent<AudioSource>();
            throttle = transform.GetChild(22).GetComponent<AudioSource>();
        }

        void Update()
        { 
            if (throttle.volume > 0.5f) noThrottle.Stop();
            else if (!noThrottle.isPlaying) noThrottle.Play();
        }
    }
}
