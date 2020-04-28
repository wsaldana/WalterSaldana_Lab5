using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour{

    public AudioClip soundTrack;
    public AudioClip water;
    public AudioClip shot;
    public AudioClip reload;

    private AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update(){
        
    }
}
