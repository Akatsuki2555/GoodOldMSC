using System.Collections.Generic;
using UnityEngine;

namespace OldCarSounds.Stuff
{
	public class RadioCore : MonoBehaviour
	{
		private void Start()
		{
			GameObject gameObject = GameObject.Find("dashboard meters(Clone)");
			Transform transform = this.transform;
			transform.parent = gameObject.transform;
			transform.position = gameObject.transform.position + new Vector3(0.283f, 0.082f, 0.133f);
			transform.rotation = gameObject.transform.rotation;
			transform.localPosition = new Vector3(-0.28482f, 0.05314599f, 0.0317383f);
			transform.localScale = new Vector3(0.148f, 0.05f, 0.04300001f);
			_source = this.gameObject.AddComponent<AudioSource>();
			_source.clip = Clips[0];
			_source.loop = true;
			_source.maxDistance = 10f;
			_source.spatialBlend = 1f;
			_source.Play();
			this.gameObject.name = "ocs_old_radio(Clone)";
		}

		private void Update()
		{
			if (volume > 1f)
			{
				volume = 1f;
			}
			if (volume < 0f)
			{
				volume = 0f;
			}
			if (!_source.isPlaying)
			{
				_source.clip = Clips[_currentClipIndex];
				_source.Play();
			}
			if (on)
			{
				_source.volume = volume;
				return;
			}
			_source.volume = 0f;
		}

		public void EnableRadio()
		{
			on = true;
			if (_source.clip == null)
			{
				_source.clip = Clips[0];
			}
			_source.volume = volume;
			_source.Play();
		}

		public void DisableRadio()
		{
			on = false;
		}

		public void IncreaseVolume()
		{
			volume += 0.05f;
			if (volume > 1f)
			{
				volume = 1f;
			}
		}

		public void DecreaseVolume()
		{
			volume -= 0.05f;
			if (volume < 0f)
			{
				volume = 0f;
			}
		}

		public void SetClip(int clip)
		{
			_source.clip = Clips[clip];
			_source.volume = 0f;
			_source.Play();
		}

		public void NextClip()
		{
			_currentClipIndex++;
			if (_currentClipIndex > Clips.Count - 1)
			{
				_currentClipIndex = 0;
			}
			_source.clip = Clips[_currentClipIndex];
			_source.Play();
		}

		public static List<AudioClip> Clips = new List<AudioClip>();

		public float volume = 0.3f;

		public bool on;

		private int _currentClipIndex;

		private AudioSource _source;
	}
}
