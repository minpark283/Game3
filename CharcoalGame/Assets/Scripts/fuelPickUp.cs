using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelPickUp : MonoBehaviour {
    public float fuelGain;
    private GameObject player;
    private playerGlobals globals;
    private charcoalSpawner charcoalSpawnerScript;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        globals = player.GetComponent<playerGlobals>();
        charcoalSpawnerScript = player.GetComponent<charcoalSpawner>();
    }

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.layer == 14) { // collision with charcoal
            globals.fuel += fuelGain;
            if(globals.fuel > 100) { globals.fuel = 100; }
            // animation for eating charcoal with spatula
            // spawn another charcoal
            Destroy(col.gameObject);
            charcoalSpawnerScript.currentNumberOfCharcoal -= 1;
        }
    }
}
