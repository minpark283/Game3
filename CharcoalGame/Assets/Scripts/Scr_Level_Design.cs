using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Level_Design : MonoBehaviour {

    Scr_EnemySpawn spawn1;

	// Use this for initialization
	void Start () {
        spawn1 = transform.GetComponent<Scr_EnemySpawn>();
        StartCoroutine(Phase1());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Phase1()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(spawn1.spawn(new Vector3(5, 5, 5), 10));







    }
}
