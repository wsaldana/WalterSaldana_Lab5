using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour{

    public AudioClip shot;
    public AudioClip reload;
    public AudioClip death;

    public Slider volumeSlider;

    private AudioSource audioSource;
    private AudioSource audioSourceTrack;

    void Start(){
        AudioSource[] sources = GetComponents<AudioSource>();
        audioSource = sources[0];
        audioSourceTrack = sources[1];
    }

    private void Update() {
        audioSourceTrack.volume = volumeSlider.value;
    }

    public void playShot() {
        if (shot) audioSource.PlayOneShot(shot);
    }

    public void playReload() {
        if (reload) audioSource.PlayOneShot(reload);
    }

    public void playDeath() {
        if (death) audioSource.PlayOneShot(death);
        //if(audioSource.isPlaying == death) 
           
    }
}
