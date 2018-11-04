using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_UI : MonoBehaviour {
    playerGlobals playerinfo;
    public Slider HealthBar;
    public Slider FuelBar;
    // Use this for initialization
    void Start () {
       
       HealthBar.transform.position = new Vector3(156, 606.5f,0);
        FuelBar.transform.position = new Vector3(156, 526.5f, 0);
    }
	
	// Update is called once per frame
	void Update () {


    }
}
