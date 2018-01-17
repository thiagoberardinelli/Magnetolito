using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{

	public string name; // nome que será dado ao áudio.

	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume; // volume do AudioClip.
	[Range(0.1f, 3f)]
	public float pitch; // pitch do AudioClip.

	public bool loop;

	public enum SoundType { Music, SFX }
	public SoundType soundType;

	[HideInInspector]
	public AudioSource source; // AudioSource referente a cada AudioClip.

}