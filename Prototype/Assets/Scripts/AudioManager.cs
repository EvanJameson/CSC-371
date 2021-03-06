﻿using UnityEngine.Audio;
using System;
using UnityEngine;

//Authors: Nick Sciacqua and Braden Saito with help from Brackeys Tutorials
public class AudioManager : MonoBehaviour {
	public Sound[] sounds;
	// Use this for initialization
	public static AudioManager instance;
	void Awake () {
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);

		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}

	}

	private void Start()
	{
		Play ("Sewer1");
	}

	public void Play(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("Sound: " + name + " was not found!");
			return;
		}
		s.source.Play();
	}

	public void Pause(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		s.source.Pause();
	}
}
