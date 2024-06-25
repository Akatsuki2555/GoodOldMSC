using MSCLoader;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldFerndale
{
    internal class OldSuspension
    {
        internal static void ApplyOldSuspension(SettingsCheckBox oldSuspension)
        {
            if (!oldSuspension.GetValue()) return;
            var axleController = GameObject.Find("FERNDALE(1630kg)").GetComponent<Axles>();

            axleController.frontAxle.suspensionTravel = 0.2f;
            axleController.frontAxle.suspensionRate = 50000;
            axleController.frontAxle.bumpRate = 1100;
            axleController.frontAxle.reboundRate = 1100;
            axleController.frontAxle.fastBumpFactor = 0.3f;
            axleController.frontAxle.fastReboundFactor = 0.3f;
            axleController.frontAxle.brakeFrictionTorque = 800;
            axleController.frontAxle.handbrakeFrictionTorque = 0;
            axleController.frontAxle.maxSteeringAngle = 22;
            axleController.frontAxle.forwardGripFactor = 1;
            axleController.frontAxle.sidewaysGripFactor = 1;
            axleController.frontAxle.camber = -1.4f;
            axleController.frontAxle.caster = 1.15f;
            axleController.frontAxle.deltaCamber = 0;

            axleController.rearAxle.suspensionTravel = 0.2f;
            axleController.rearAxle.suspensionRate = 50000;
            axleController.rearAxle.bumpRate = 1100;
            axleController.rearAxle.reboundRate = 1100;
            axleController.rearAxle.fastBumpFactor = 0.3f;
            axleController.rearAxle.fastReboundFactor = 0.3f;
            axleController.rearAxle.brakeFrictionTorque = 800;
            axleController.rearAxle.handbrakeFrictionTorque = 0;
            axleController.rearAxle.maxSteeringAngle = 22;
            axleController.rearAxle.forwardGripFactor = 1;
            axleController.rearAxle.sidewaysGripFactor = 1;
            axleController.rearAxle.camber = -1.4f;
            axleController.rearAxle.caster = 1.15f;
            axleController.rearAxle.deltaCamber = 0;

            axleController.frontAxle.wheels[0].transform.localPosition = new Vector3(-0.785f, 0.199f, 1.492f);
            axleController.frontAxle.wheels[0].suspensionTravel = 0.2f;
            axleController.frontAxle.wheels[0].suspensionRate = 50000;
            axleController.frontAxle.wheels[0].bumpRate = 1100;
            axleController.frontAxle.wheels[0].reboundRate = 1100;
            axleController.frontAxle.wheels[0].fastBumpFactor = 0.3f;
            axleController.frontAxle.wheels[0].fastReboundFactor = 0.3f;
            axleController.frontAxle.wheels[0].brakeFrictionTorque = 800;
            axleController.frontAxle.wheels[0].handbrakeFrictionTorque = 0;
            axleController.frontAxle.wheels[0].maxSteeringAngle = 22;
            axleController.frontAxle.wheels[0].forwardGripFactor = 1;
            axleController.frontAxle.wheels[0].sidewaysGripFactor = 1;
            axleController.frontAxle.wheels[0].camber = -1.4f;
            axleController.frontAxle.wheels[0].caster = 1.15f;
            axleController.frontAxle.wheels[0].deltaCamber = 0;

            axleController.frontAxle.wheels[1].transform.localPosition = new Vector3(0.785f, 0.199f, 1.492f);
            axleController.frontAxle.wheels[1].suspensionTravel = 0.2f;
            axleController.frontAxle.wheels[1].suspensionRate = 50000;
            axleController.frontAxle.wheels[1].bumpRate = 1100;
            axleController.frontAxle.wheels[1].reboundRate = 1100;
            axleController.frontAxle.wheels[1].fastBumpFactor = 0.3f;
            axleController.frontAxle.wheels[1].fastReboundFactor = 0.3f;
            axleController.frontAxle.wheels[1].brakeFrictionTorque = 800;
            axleController.frontAxle.wheels[1].handbrakeFrictionTorque = 0;
            axleController.frontAxle.wheels[1].maxSteeringAngle = 22;
            axleController.frontAxle.wheels[1].forwardGripFactor = 1;
            axleController.frontAxle.wheels[1].sidewaysGripFactor = 1;
            axleController.frontAxle.wheels[1].camber = -1.4f;
            axleController.frontAxle.wheels[1].caster = 1.15f;
            axleController.frontAxle.wheels[1].deltaCamber = 0;

            axleController.rearAxle.wheels[0].transform.localPosition = new Vector3(-0.82f, 0.15f, -1.492f);
            axleController.rearAxle.wheels[0].suspensionTravel = 0.2f;
            axleController.rearAxle.wheels[0].suspensionRate = 50000;
            axleController.rearAxle.wheels[0].bumpRate = 1100;
            axleController.rearAxle.wheels[0].reboundRate = 1100;
            axleController.rearAxle.wheels[0].fastBumpFactor = 0.3f;
            axleController.rearAxle.wheels[0].fastReboundFactor = 0.3f;
            axleController.rearAxle.wheels[0].brakeFrictionTorque = 500;
            axleController.rearAxle.wheels[0].handbrakeFrictionTorque = 1200;
            axleController.rearAxle.wheels[0].maxSteeringAngle = 0;
            axleController.rearAxle.wheels[0].forwardGripFactor = 0.95f;
            axleController.rearAxle.wheels[0].sidewaysGripFactor = 0.95f;
            axleController.rearAxle.wheels[0].camber = 0;
            axleController.rearAxle.wheels[0].caster = 0;
            axleController.rearAxle.wheels[0].deltaCamber = 0;

            axleController.rearAxle.wheels[1].transform.localPosition = new Vector3(0.82f, 0.15f, -1.492f);
            axleController.rearAxle.wheels[1].suspensionTravel = 0.2f;
            axleController.rearAxle.wheels[1].suspensionRate = 50000;
            axleController.rearAxle.wheels[1].bumpRate = 1100;
            axleController.rearAxle.wheels[1].reboundRate = 1100;
            axleController.rearAxle.wheels[1].fastBumpFactor = 0.3f;
            axleController.rearAxle.wheels[1].fastReboundFactor = 0.3f;
            axleController.rearAxle.wheels[1].brakeFrictionTorque = 500;
            axleController.rearAxle.wheels[1].handbrakeFrictionTorque = 1200;
            axleController.rearAxle.wheels[1].maxSteeringAngle = 0;
            axleController.rearAxle.wheels[1].forwardGripFactor = 0.95f;
            axleController.rearAxle.wheels[1].sidewaysGripFactor = 0.95f;
            axleController.rearAxle.wheels[1].camber = 0;
            axleController.rearAxle.wheels[1].caster = 0;
            axleController.rearAxle.wheels[1].deltaCamber = 0;
        }
    }
}
