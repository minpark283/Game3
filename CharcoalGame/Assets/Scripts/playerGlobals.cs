using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGlobals : MonoBehaviour {
    public float health = 100;
    public float fuel = 100;
    player_UI playerdata;
	// Use this for initialization
	void Start () {
        playerdata = transform.GetComponent<player_UI>();
        playerdata.HealthBar.value = health;
        playerdata.FuelBar.value = fuel;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(this.health);
            this.dmgHP(10);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(this.fuel);
            this.getfuel(-10);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log(this.fuel);
            this.getfuel(10);
        }
    }

    public void getfuel(int amount)
    {
        
        if(fuel <= 100)
        {
            fuel = Mathf.Min(fuel + amount, 100);
            playerdata.FuelBar.value = fuel;
        }
    }

    public void dmgHP(int amount)
    {
        health -= amount;
        playerdata.HealthBar.value = health;
    }


}


