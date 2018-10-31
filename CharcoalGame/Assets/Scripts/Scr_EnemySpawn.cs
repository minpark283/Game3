using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemySpawn : MonoBehaviour {
    public GameObject enemySpawn;
    public List<GameObject> spawnList;

    //Spawn Data
    public float numSpawn;
    public float timeBetweenSpawn;

	// Use this for initialization
	void Start () {
        spawnList = new List<GameObject>();
	}
	
	public IEnumerator spawn(Vector3 location, float numofSpawn )
    {
        for(int i = 0; i < numofSpawn; i++)
        {
            Debug.Log("Spawn!");
            GameObject s = (GameObject)Instantiate(enemySpawn, location, Quaternion.identity);
            s.layer = 11;
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

    }
	
}
