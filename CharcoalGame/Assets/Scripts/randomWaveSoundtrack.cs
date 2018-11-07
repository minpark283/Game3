using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomWaveSoundtrack : MonoBehaviour {
    public List<AudioClip> soundtrackList;
    public AudioSource audioSource;
    bool playing = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*if (!playing) {
            int randomIndex = Random.Range(0, soundtrackList.Count);
            AudioClip audioClip = soundtrackList[randomIndex];
            audioSource.clip = audioClip;
            audioSource.Play();
            playing = true;
        }
        */
    }
}
