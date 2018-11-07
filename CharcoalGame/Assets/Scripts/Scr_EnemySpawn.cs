using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemySpawn : MonoBehaviour {
    public GameObject spawn1;
    public GameObject spawnRange;
    public GameObject spawnAdv;
    public Terrain land;
    public Vector3 landdimension;
    //Spawn Data
    public float numSpawn;
    public float timeBetweenSpawn;

	// Use this for initialization
	void Start () {
        landdimension = land.terrainData.size;
       
	}
	
	public IEnumerator spawn(float numofSpawn, int quad, int id)
    {
        Vector3 location = new Vector3(0, 0, 0);
        switch (quad)
        {
            case 1:
                location.x = 260;
                location.z = 260;
                break;
            case 2:
                location.x = 60;
                location.z = 255;
                break;
            case 3:
                location.x = 40;
                location.z = 40;
                break;
            case 4:
                location.x = 260;
                location.z = 22;
                break;
        }
        for (int i = 0; i < numofSpawn; i++)
        {

            Vector3 randomize = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
            location = location + randomize;
            switch (id)
            {
                
                case 1:
                    GameObject b = (GameObject)Instantiate(spawn1, location, Quaternion.identity);
                    b.layer = 11;
                    break;
                case 2:
                    GameObject c = (GameObject)Instantiate(spawn1, location, Quaternion.identity);
                    c.layer = 11;
                    break;
                case 3:
                    GameObject p = (GameObject)Instantiate(spawn1, location, Quaternion.identity);
                    p.layer = 11;
                    break;
            }
           
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

    }
	
}
