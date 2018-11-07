using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcoalSpawner : MonoBehaviour {
    public List<Vector3> spawnPointList;
    public int maxNumberOfCharcoal;
    public int currentNumberOfCharcoal;
    public GameObject charcoalObject;
    private int currentQuadrant;
    private Dictionary<int, List<Vector3>> spawnPointDict;

    // Use this for initialization
    void Start () {
        spawnPointList = new List<Vector3>();
        spawnPointDict = new Dictionary<int, List<Vector3>>();
        currentNumberOfCharcoal = 0;

        // bottom left quadrant (0)
        spawnPointList.Add(new Vector3(50, 0, 50));
        spawnPointList.Add(new Vector3(10, 0, 40));
        spawnPointList.Add(new Vector3(40, 0, 70));
        spawnPointList.Add(new Vector3(60, 0, 35));
        spawnPointDict.Add(0, spawnPointList);
        spawnPointList = new List<Vector3>();

        // bottom middle quadrant (1)
        spawnPointList.Add(new Vector3(160, 0, 85));
        spawnPointList.Add(new Vector3(180, 0, 65));
        spawnPointList.Add(new Vector3(118, 0, 54));
        spawnPointList.Add(new Vector3(140, 0, 15));
        spawnPointDict.Add(1, spawnPointList);
        spawnPointList = new List<Vector3>();

        // bottom right quadrant (2)
        spawnPointList.Add(new Vector3(220, 0, 70));
        spawnPointList.Add(new Vector3(230, 0, 20));
        spawnPointList.Add(new Vector3(270, 0, 35));
        spawnPointList.Add(new Vector3(275, 0, 65));
        spawnPointDict.Add(2, spawnPointList);
        spawnPointList = new List<Vector3>();

        // middle left quadrant (3)
        spawnPointList.Add(new Vector3(61, 0, 70));
        spawnPointList.Add(new Vector3(60, 0, 130));
        spawnPointList.Add(new Vector3(25, 0, 150));
        spawnPointDict.Add(3, spawnPointList);
        spawnPointList = new List<Vector3>();

        // middle center quadrant (4)
        spawnPointList.Add(new Vector3(150, 0, 175));
        spawnPointList.Add(new Vector3(180, 0, 175));
        spawnPointList.Add(new Vector3(185, 0, 120));
        spawnPointList.Add(new Vector3(113, 0, 120));
        spawnPointList.Add(new Vector3(113, 0, 176));
        spawnPointDict.Add(4, spawnPointList);
        spawnPointList = new List<Vector3>();

        // middle right quadrant (5)
        spawnPointList.Add(new Vector3(280, 0, 175));
        spawnPointList.Add(new Vector3(280, 0, 125));
        spawnPointList.Add(new Vector3(235, 0, 130));
        spawnPointDict.Add(5, spawnPointList);
        spawnPointList = new List<Vector3>();

        // top left quadrant (6)
        spawnPointList.Add(new Vector3(60, 0, 255));
        spawnPointList.Add(new Vector3(35, 0, 220));
        spawnPointList.Add(new Vector3(82, 0, 220));
        spawnPointDict.Add(6, spawnPointList);
        spawnPointList = new List<Vector3>();

        // top middle quadrant (7)
        spawnPointList.Add(new Vector3(150, 0, 260));
        spawnPointList.Add(new Vector3(130, 0, 230));
        spawnPointList.Add(new Vector3(170, 0, 230));
        spawnPointList.Add(new Vector3(150, 0, 230));
        spawnPointDict.Add(7, spawnPointList);
        spawnPointList = new List<Vector3>();

        // top right quadrant (8)
        spawnPointList.Add(new Vector3(224, 0, 230));
        spawnPointList.Add(new Vector3(240, 0, 200));
        spawnPointList.Add(new Vector3(240, 0, 270));
        spawnPointList.Add(new Vector3(280, 0, 240));
        spawnPointDict.Add(8, spawnPointList);
        spawnPointList = new List<Vector3>();
    }
	
	// Update is called once per frame
	void Update () {
        List<Vector3> spawnQuadrantPointList;
		if(currentNumberOfCharcoal < maxNumberOfCharcoal) {
            currentQuadrant = Random.Range(0, 9);
            if(spawnPointDict.TryGetValue(currentQuadrant, out spawnQuadrantPointList)) {
                int randomIndex = Random.Range(0, spawnQuadrantPointList.Count);
                Vector3 spawnPoint = spawnQuadrantPointList[randomIndex];
                if(!Physics.CheckSphere(spawnPoint + new Vector3(0, 1, 0), .01f)) {
                    GameObject charcoal = (GameObject)Instantiate(charcoalObject, spawnPoint, transform.rotation);
                    charcoal.gameObject.layer = 14;
                    currentNumberOfCharcoal++;
                }
            }
        }
	}
}
