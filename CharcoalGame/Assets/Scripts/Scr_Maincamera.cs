using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Maincamera : MonoBehaviour {
    public GameObject target;
    Vector3 cameraoffset;
    // Use this for initialization
    void Start () {
        cameraoffset = transform.position - target.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 desiredPosition = target.transform.position + cameraoffset;
        transform.position = desiredPosition;
        transform.LookAt(target.transform);
	}
}
