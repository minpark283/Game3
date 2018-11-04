using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcoalSpawner : MonoBehaviour {
    public List<Vector3> spawnPointList;
    public int maxNumberOfCharcoal;
    public int currentNumberOfCharcoal;
    public GameObject charcoalObject;

    // Use this for initialization
    void Start () {
        spawnPointList = new List<Vector3>();
        spawnPointList.Add(new Vector3(100, 0, 100));
        spawnPointList.Add(new Vector3(80, 0, 100));
        spawnPointList.Add(new Vector3(60, 0, 100));
        spawnPointList.Add(new Vector3(40, 0, 100));
        spawnPointList.Add(new Vector3(20, 0, 100));
        spawnPointList.Add(new Vector3(20, 0, 20));
        spawnPointList.Add(new Vector3(100, 0, 80));
        spawnPointList.Add(new Vector3(100, 0, 60));
        spawnPointList.Add(new Vector3(100, 0, 40));
        spawnPointList.Add(new Vector3(100, 0, 20));
        currentNumberOfCharcoal = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(currentNumberOfCharcoal < maxNumberOfCharcoal) {
            int randomIndex = Random.Range(0, spawnPointList.Count);
            Vector3 spawnPoint = spawnPointList[randomIndex];
            GameObject charcoal = (GameObject)Instantiate(charcoalObject, spawnPoint, transform.rotation);
            charcoal.gameObject.layer = 14;
            currentNumberOfCharcoal++;
        }
	}
}
