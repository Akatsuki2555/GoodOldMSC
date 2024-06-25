using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GoodOldMSC.Mods.OldTruckSounds
{
    internal class Gifu : MonoBehaviour
    {
        public GameObject GifuRadioPivot;
        public GameObject GifuLod;
        public GameObject GifuCabin;
        public GameObject GifuMesh;
        public GameObject GifuAudioEngine;

        public SoundController Controller;
        public Drivetrain Drivetrain;

        public AudioSource LowAudioSource;
        public AudioSource HighAudioSource;

        private void Start()
        {
            GifuRadioPivot = gameObject.transform.Find("RadioPivot").gameObject;
            GifuLod = gameObject.transform.Find("LOD").gameObject;
            GifuCabin = gameObject.transform.Find("Cabin").gameObject;
            GifuMesh = gameObject.transform.Find("MESH").gameObject;
            GifuAudioEngine = UnityEngine.Resources.FindObjectsOfTypeAll<GameObject>()
                .First(x => x.name == "AudioEngineGifu");
            Controller = gameObject.GetComponent<SoundController>();
            Drivetrain = gameObject.GetComponent<Drivetrain>();

                switch (OldTruckSounds.RadioPosNumber.GetValue())
                {
                    case 1:
                        GifuRadioPivot.transform.localPosition = new Vector3(-0.178f, 1.729f, 3.388f);
                        GifuRadioPivot.transform.localRotation =
                            Quaternion.Euler(new Vector3(-85.645f, -4.8f, 184.795f));
                        break;
                    case 2:
                        GifuRadioPivot.SetActive(false);
                        break;
                }

            if (OldTruckSounds.RemovePedalsToggle.GetValue())
            {
                    GifuLod.transform.Find("Dashboard/Pedals").gameObject.SetActive(false);
            }

            if (OldTruckSounds.ReplaceShitTankWithLogsToggle.GetValue())
            {
                GifuMesh.transform.Find("shit_tank 1").gameObject.SetActive(false);
                GifuLod.transform.Find("ShitTank").gameObject.SetActive(false);
                GifuLod.transform.Find("work_lights").gameObject.SetActive(false);
                transform.Find("ShitTank").gameObject.SetActive(false);
                transform.Find("ActivateHose").gameObject.SetActive(false);

                GameObject logsHolder = Instantiate(OldTruckSounds.TruckLogBed1);
                logsHolder.transform.parent = GifuMesh.transform;
                logsHolder.transform.position = Vector3.zero;
                logsHolder.transform.rotation = Quaternion.identity;
                logsHolder.transform.localPosition = new Vector3(-0.08f, 1.52f, 0.8f);
                logsHolder.transform.localRotation =
                    new Quaternion(-5.960465E-08f, 2.107342E-08f, -2.107343E-08f, 1f);
                logsHolder.transform.localScale = new Vector3(0.95f, 0.98f, 0.74f);
                GameObject logs = Instantiate(OldTruckSounds.TruckLogBed2);
                logs.transform.parent = GifuMesh.transform;
                logs.transform.position = Vector3.zero;
                logs.transform.rotation = Quaternion.identity;
                logs.transform.localPosition = new Vector3(-0.08f, 1.52f, 1.47F);
                logs.transform.localRotation = new Quaternion(-5.960465E-08f, 2.107342E-08f, -2.107343E-08f, 1f);
                logs.transform.localScale = new Vector3(0.95f, 0.98f, 0.74f);
            }

            if (OldTruckSounds.EngineNumber.GetValue().ToString() != "0")
            {
                foreach (PlayMakerFSM fsm in GifuAudioEngine.GetComponents<PlayMakerFSM>())
                {
                    if (fsm.name != "Throttle")
                    {
                        fsm.enabled = false;
                    }
                }
            }

            if (OldTruckSounds.EngineNumber.GetValue().ToString() != "0")
            {
                GameObject go1 = new GameObject("LowSound");
                LowAudioSource = go1.AddComponent<AudioSource>();
                LowAudioSource.spatialBlend = 1f;
                LowAudioSource.maxDistance = 25f;
                GameObject go2 = new GameObject("HighSound");
                HighAudioSource = go2.AddComponent<AudioSource>();
                HighAudioSource.spatialBlend = 1f;
                HighAudioSource.maxDistance = 35f;
                switch (OldTruckSounds.EngineNumber.GetValue().ToString())
                {
                    case "1":
                        LowAudioSource.clip = OldTruckSounds.NewEngineIdle;
                        HighAudioSource.clip = OldTruckSounds.NewEngineAccel;
                        break;
                    case "2":
                        LowAudioSource.clip = OldTruckSounds.EngineIdle;
                        HighAudioSource.clip = OldTruckSounds.EngineAccel;
                        break;
                    default:
                        throw new InvalidOperationException("What the fuck?");
                }

                LowAudioSource.loop = true;
                HighAudioSource.loop = true;
                LowAudioSource.Play();
                HighAudioSource.Play();
            }

            if (OldTruckSounds.PaintExteriorRedToggle.GetValue())
            {
                GifuMesh.transform.Find("truck_frame/truck_cabin 1").GetComponent<Renderer>().sharedMaterial =
                    OldTruckSounds.TruckCabin;
                Transform doorL = transform.Find("Cabin/DriverDoors/doorl/door");
                Transform doorR = transform.Find("Cabin/DriverDoors/doorr/door");
                doorL.GetComponent<Renderer>().sharedMaterial = OldTruckSounds.TruckCabin;
                doorR.GetComponent<Renderer>().sharedMaterial = OldTruckSounds.TruckCabin;
                doorL.Find("truck_cabin_door_panel").GetComponent<Renderer>().sharedMaterial = OldTruckSounds.TruckCabin;
                doorR.Find("truck_cabin_door_panel 1").GetComponent<Renderer>().sharedMaterial = OldTruckSounds.TruckCabin;
                doorL.Find("truck_cabin_door_parts").GetComponent<Renderer>().sharedMaterial = OldTruckSounds.TruckCabin;
                doorR.Find("truck_cabin_door_parts 1").GetComponent<Renderer>().sharedMaterial = OldTruckSounds.TruckCabin;
                doorL.Find("opener/mesh").GetComponent<Renderer>().sharedMaterial = OldTruckSounds.TruckCabin;
                GifuMesh.transform.Find("truck_frame").GetComponent<Renderer>().sharedMaterial =
                    OldTruckSounds.TruckCabin;
            }

            if (OldTruckSounds.PaintInteriorBlackToggle.GetValue())
            {
                Transform truckInterior = GifuLod.transform.Find("truck_interior");
                truckInterior.GetComponent<Renderer>().sharedMaterial = OldTruckSounds.Paint4;
                truckInterior.Find("truck_interior_parts").GetComponent<Renderer>().sharedMaterial =
                    OldTruckSounds.Paint4;
                GifuLod.transform.Find("Dashboard/GearLever/Pivot/Lever/truck_dash_gearstick")
                    .GetComponent<Renderer>().sharedMaterial = OldTruckSounds.Paint4;
                GifuLod.transform.Find("Dashboard/GearLever/Pivot/Lever/Range/RangeButton/truck_dash_gearstick 1")
                    .GetComponent<Renderer>().sharedMaterial = OldTruckSounds.Paint4;
            }

            if (OldTruckSounds.HideMudFlapsToggle.GetValue())
            {
                GifuLod.transform.Find("truck_accessories").gameObject.SetActive(false);
            }

            if (OldTruckSounds.HideSPZToggle.GetValue())
            {
                GifuLod.transform.GetChild(3).gameObject.SetActive(false);
                GifuLod.transform.GetChild(4).gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (OldTruckSounds.EngineNumber.GetValue() != 0)
            {
                float num1 = Drivetrain.rpm / Drivetrain.maxRPM;
                float engineThrottleVolume;
                float engineNoThrottleVolume;
                float engineThrottlePitchFactor;
                float engineNoThrottlePitchFactor;

                if (Drivetrain.rpm < 300)
                {
                    LowAudioSource.volume = 0f;
                    HighAudioSource.volume = 0f;
                }
                else
                {
                    LowAudioSource.transform.position = transform.position;
                    HighAudioSource.transform.position = transform.position;
                    switch (OldTruckSounds.EngineNumber.GetValue())
                    {
                        case 1:
                            engineThrottleVolume = 1f;
                            engineNoThrottleVolume = 0.5F;
                            engineThrottlePitchFactor = .65f;
                            engineNoThrottlePitchFactor = 1.5f;
                            LowAudioSource.volume = Math.Abs(1f - Drivetrain.throttle) * engineNoThrottleVolume * num1;
                            LowAudioSource.pitch = 0.5f + engineNoThrottlePitchFactor * num1;
                            HighAudioSource.volume = Drivetrain.throttle * engineThrottleVolume + num1 * 0.200000002980232f;
                            HighAudioSource.pitch = 0.5f + engineThrottlePitchFactor * num1;
                            break;
                        case 2:
                            engineThrottleVolume = 1f;
                            engineNoThrottleVolume = .5f;
                            engineThrottlePitchFactor = .6f;
                            engineNoThrottlePitchFactor = 1f;
                            LowAudioSource.volume = Math.Abs(1f - Drivetrain.throttle) * engineNoThrottleVolume * num1;
                            LowAudioSource.pitch = 0.5f + engineNoThrottlePitchFactor * num1;
                            HighAudioSource.volume = Drivetrain.throttle * engineThrottleVolume + num1 * 0.200000002980232f;
                            HighAudioSource.pitch = 0.5f + engineThrottlePitchFactor * num1;
                            break;
                        default:
                            throw new InvalidOperationException("This is not a valid engine state...");
                    }
                }
            }
        }
        
    }
}
