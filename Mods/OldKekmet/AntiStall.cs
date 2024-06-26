using HutongGames.PlayMaker;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldKekmet
{
    internal class AntiStall : MonoBehaviour
    {
        Drivetrain drivertrain;
        PlayMakerFSM ignition;
        FsmBool accState;

        void Start()
        {
            drivertrain = GetComponent<Drivetrain>();
            ignition = transform.GetChild(4).GetChild(0).GetComponents<PlayMakerFSM>()[0];
            accState = ignition.FsmVariables.GetFsmBool("ACC");
        }

        void Update()
        {
            if (accState.Value)
                drivertrain.minRPM = 500;
        }

        void LateUpdate()
        { 
            if (accState.Value)
                drivertrain.minRPM = 500;
        }
    }
}
