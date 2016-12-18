using UnityEngine;
using System.Collections;

public class AudioPlay : MonoBehaviour
{

	public static void PlaySound(AudioSource _source, AudioClip _sound)
	{
		if (_source == null)
			throw new UnityException ("Source is null");

		if (_sound == null)
			throw new UnityException ("Sound is null");

		_source.Stop ();
		_source.clip = _sound;
		_source.Play ();

	}

	public static void PlayRandomSound(AudioSource _source, AudioClip[] _sounds)
	{
		if (_source == null)
			throw new UnityException ("Source is null");

		if (_sounds == null)
			throw new UnityException ("Sounds is null");

		if (_sounds.Length == 0)
			throw new UnityException ("Sounds length is 0");


		int randomNum = UnityEngine.Random.Range(0, _sounds.Length);

		AudioClip _sound = _sounds[randomNum];
			
		_source.Stop();
		_source.clip = _sound;
		_source.Play();
	}
}