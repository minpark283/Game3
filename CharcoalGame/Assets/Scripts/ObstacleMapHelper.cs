using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMapHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MapConstructionCall(GameObject mapper)
    {
        mapper.SendMessage("UpdateGrid", this.GetComponent<MeshCollider>());
    }
}
