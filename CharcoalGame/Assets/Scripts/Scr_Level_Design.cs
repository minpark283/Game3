using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Level_Design : MonoBehaviour {

    Scr_EnemySpawn spawn1;
    public GameObject playerobj;
    Rigidbody playerbody;
    public Terrain land;
    public Vector3 landdimension;
	// Use this for initialization
	void Start () {
        spawn1 = transform.GetComponent<Scr_EnemySpawn>();
        playerbody = playerobj.GetComponent<Rigidbody>();
        landdimension = land.terrainData.size;
        Debug.Log(landdimension);
        playerobj.GetComponent<Rigidbody>().position = new Vector3 (landdimension.x / 2, playerbody.position.y, landdimension.z /2);
        StartCoroutine(Phase1());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Phase1()
    {
        int phase1spawnnumber = 100;
        int quadrant = 1;
        float waitbetweenwaves = 5;
        yield return new WaitForSeconds(2f);
       


        while (phase1spawnnumber > 0)
        {
            //quadrant 1
            if (playerbody.position.x <= landdimension.x / 2 && playerbody.position.z <= landdimension.z / 2)
            {
                quadrant = 1;
            }
            //quadrant 2
            else if (playerbody.position.x > landdimension.x / 2 && playerbody.position.z <= landdimension.z / 2)
            {
                quadrant = 2;
            }
            //quadrant 3
            else if (playerbody.position.x > landdimension.x / 2 && playerbody.position.z > landdimension.z / 2)
            {
                quadrant = 3;
            }
            //quadrant 4
            else
            {
                quadrant = 4;
            }
            StartCoroutine(spawn1.spawn(10, quadrant));
            phase1spawnnumber -= 10;
            yield return new WaitForSeconds(waitbetweenwaves);


        }



    }
}
