﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerGlobals : MonoBehaviour {
    public float health = 100;
    public float fuel = 100;
    player_UI playerdata;
    Scr_StageLoader stage;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Use this for initialization
    void Start () {
        playerdata = transform.GetComponent<player_UI>();
        playerdata.HealthBar.value = health;
        playerdata.FuelBar.value = fuel;
    }
	
	// Update is called once per frame
	void Update () {
        audioSource.clip = audioClip;
        audioSource.Play();

        playerdata.FuelBar.value = fuel;
        playerdata.HealthBar.value = health;

        if(health <= 0) {
            stage.ChangeScene("LoseScene");
            // Destroy player
            // go to game over screen
            // other death stuff
        }
    }
}


