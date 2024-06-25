using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class OldEngine
    {
        internal static void ApplyOldEngine(SettingsCheckBox oldEngine)
        {
            if (!oldEngine.GetValue()) return;
            var ferndale = GameObject.Find("FERNDALE(1630kg)");
            var drivetrain = ferndale.GetComponent<Drivetrain>();
            drivetrain.maxPower = 190;
            drivetrain.maxPowerRPM = 4400;
            drivetrain.maxTorque = 421;
            drivetrain.maxTorqueRPM = 2400;
            drivetrain.originalMaxPower = 210;
            drivetrain.maxNetPower = 0;
            drivetrain.maxNetPowerRPM = 0;
            drivetrain.maxNetTorque = 0;
            drivetrain.maxNetTorqueRPM = 0;
            drivetrain.torque = 0;
            drivetrain.wheelTireVelo = 0;
            drivetrain.minRPM = 730;
            var soundController = ferndale.GetComponent<SoundController>();
            soundController.engineThrottleVolume = 4;
            soundController.engineThrottlePitchFactor = 0.65f;
            soundController.engineNoThrottleVolume = 1.1f;
            soundController.engineNoThrottlePitchFactor = 0.45f;
        }
    }
}
