using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioS : MonoBehaviour

{
	
	public AudioSource AudioSource ;
	private float musicVolume = 1f ;

	void Start(){
		AudioSource.Play();
	}
	/*
	void Awake(){

		DontDestroyOnLoad(transform.gameObject);

	}
	*/

	void Update(){
		AudioSource.volume = musicVolume;


	}

	public void updateVolume(float volume){
		musicVolume = volume;

	}
}
