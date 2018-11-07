using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Level_Design : MonoBehaviour {

    Scr_EnemySpawn spawn1;
    public Text waveNuminfo;
    public GameObject playerobj;
    public int numEnemyinWaves;
    Rigidbody playerbody;
    public Terrain land;
    public Vector3 landdimension;
    int phasetracker = 1;

    int[] level2SpawnSeries = new int[100];
    int[] level3SpawnSeries = new int[150];
	// Use this for initialization
	void Start () {
        level2SpawnSeries = new int[]
          {1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 1, 1, 3, 3,
            1, 1, 1, 3, 3,
            1, 1, 1, 3, 3,
            1, 3, 3, 3, 3,
            1, 3, 3, 3, 3,
            1, 3, 3, 3, 3,
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 1, 2, 3, 3,
            1, 1, 2, 3, 3,
            1, 1, 2, 3, 3,
            1, 2, 2, 3, 3,
            1, 2, 2, 3, 3,
            3, 3, 3, 3, 3,
            2, 2, 2, 2, 2,
            1, 2, 3, 3, 3 };




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
        int phase1spawnnumber = 50;
        numEnemyinWaves = phase1spawnnumber;
        waveNuminfo.text = "Wave: " + numEnemyinWaves;
        int quadrant = 1;
        float waitbetweenwaves = 15;
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
            StartCoroutine(spawn1.spawn(5, quadrant, new int[5] { 1, 1, 1, 1, 1 }));
            phase1spawnnumber -= 5;
            yield return new WaitForSeconds(waitbetweenwaves);


        }
    }
    //brocolli peas carrot
    IEnumerator Phase2()
    {

        yield return new WaitForSeconds(2f);
        int phase2spawnnumber = 100;
        numEnemyinWaves = phase2spawnnumber;
        waveNuminfo.text = "Wave: " + numEnemyinWaves;
        int quadrant = 1;
        float waitbetweenwaves = 5;
        yield return new WaitForSeconds(2f);
        while (phase2spawnnumber > 0)
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
            StartCoroutine(spawn1.spawn(5, quadrant, new int[5] { level2SpawnSeries[phase2spawnnumber], level2SpawnSeries[phase2spawnnumber] + 1, level2SpawnSeries[phase2spawnnumber] + 2, level2SpawnSeries[phase2spawnnumber] + 3, level2SpawnSeries[phase2spawnnumber] + 4 }));
            phase2spawnnumber -= 5;
            yield return new WaitForSeconds(waitbetweenwaves);
        }

    }
    IEnumerator Phase3()
        {
            yield return new WaitForSeconds(2f);
            int phase1spawnnumber = 150;
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
            }
        }
    public void updateWaveText()
    {
        waveNuminfo.text = "Wave: " + numEnemyinWaves;
    }
}
