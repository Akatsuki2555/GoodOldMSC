using System.Collections.Generic;

using UnityEngine;

namespace GoodOldMSC.Mods.OldCarSounds {

    public class RadioCore : MonoBehaviour {
        public static List<AudioClip> Clips = new List<AudioClip>(); // Set later

        public float volume = 0.3f;

        public bool on;
        private int _currentClipIndex;

        private AudioSource _source;

        private void Start() {

            // Set position and parent
            GameObject a = GameObject.Find("dashboard meters(Clone)");
            Transform b = transform;
            b.parent = a.transform;
            b.position = a.transform.position + new Vector3(0.283f, 0.082f, 0.133f);
            b.rotation = a.transform.rotation;
            b.localPosition = new Vector3(-0.28482f, 0.05314599f, 0.0317383f);
            b.localScale = new Vector3(0.148f, 0.05f, 0.04300001f);

            // Add sound
            _source = gameObject.AddComponent<AudioSource>();
            _source.clip = Clips[0];
            _source.loop = true;
            _source.maxDistance = 10;
            _source.spatialBlend = 1;
            _source.Play();

            // Change the name to something friendly
            gameObject.name = "ocs_old_radio(Clone)";

            /*
             *  localPosition = new Vector3 (-0.28482f, 0.05314599f, 0.0317383f);
             *  localEulerAngles = new Vector3 (0f, 0f, 0f);
             *  localScale = new Vector3 (0.148f, 0.05f, 0.04300001f);
             */
        }

        private void Update() {
            if (volume > 1f) {
                volume = 1f;
            }

            if (volume < 0f) {
                volume = 0f;
            }

            // Check if it's playing
            if (!_source.isPlaying) {

                // Adjust clip
                _source.clip = Clips[_currentClipIndex];

                // Play if not playing
                _source.Play();
            }

            // Check if on and adjust volume
            if (on) {
                _source.volume = volume; // On
            }
            else {
                _source.volume = 0; // Off
            }
        }

        public void EnableRadio() {
            on = true;
            if (_source.clip == null) {
                _source.clip = Clips[0];
            }

            _source.volume = volume;
            _source.Play();
        }

        public void DisableRadio() {
            on = false;
        }

        public void IncreaseVolume() {
            volume += 0.05f;
            if (volume > 1) {
                volume = 1;
            }
        }

        public void DecreaseVolume() {
            volume -= 0.05f;
            if (volume < 0) {
                volume = 0;
            }
        }

        public void SetClip(int clip) {
            _source.clip = Clips[clip];
            _source.volume = 0;
            _source.Play();
        }

        public void NextClip() {
            _currentClipIndex++;
            if (_currentClipIndex > Clips.Count - 1) {
                _currentClipIndex = 0;
            }

            _source.clip = Clips[_currentClipIndex];
            _source.Play();
        }
    }
}
