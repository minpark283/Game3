using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemySpawn : MonoBehaviour {
    public GameObject enemySpawn;
    public List<GameObject> spawnList;
    public Terrain land;
    public Vector3 landdimension;
    //Spawn Data
    public float numSpawn;
    public float timeBetweenSpawn;

	// Use this for initialization
	void Start () {
        landdimension = land.terrainData.size;
        spawnList = new List<GameObject>();
	}
	
	public IEnumerator spawn(float numofSpawn, int quad)
    {
        Vector3 location = new Vector3(0, 0, 0);
        switch (quad)
        {
            case 1:
                location.x = (Random.Range(1.25f * (landdimension.x / 2), (landdimension.x)));
                location.z = (Random.Range(1.25f * (landdimension.z / 2), (landdimension.z)));
                break;
            case 2:
                location.x = (Random.Range(0, .75f * (landdimension.x / 2)));
                location.z = (Random.Range(1.25f * (landdimension.z / 2), (landdimension.z)));
                break;
            case 3:
                location.x = (Random.Range(0, .75f * (landdimension.x / 2)));
                location.z = (Random.Range(0, .75f * (landdimension.z /2)));
                break;
            case 4:
                location.x = (Random.Range(1.25f * (landdimension.x / 2), (landdimension.x)));
                location.z = (Random.Range(0, .75f * (landdimension.z / 2)));
                break;
        }
        for (int i = 0; i < numofSpawn; i++)
        {
            Debug.Log("Spawn!");
            Vector3 randomize = new Vector3(Random.Range(-7, 7), 0, Random.Range(-7, 7));
            location = location + randomize;
            GameObject s = (GameObject)Instantiate(enemySpawn, location, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

    }
	
}
