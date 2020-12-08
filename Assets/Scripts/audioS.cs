using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class audioS : MonoBehaviour

{
	
	public AudioSource AudioSource ;
	public Slider AudioSlider;
	private float musicVolume = 1f ;

	void Start(){
		AudioSource.Play();
		AudioSlider.value = PlayerPrefs.GetFloat("volume");
	}
	

	void Update(){
		AudioSource.volume = musicVolume;


	}

	public void updateVolume(float volume){
		PlayerPrefs.SetFloat("volume", volume);
		AudioListener.volume = PlayerPrefs.GetFloat("volume");

	}
}
