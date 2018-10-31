using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBeam : MonoBehaviour {
    public float beamLength;
    public float beamCost;
    public float beamDamage;
    private GameObject player;
    private playerGlobals globals;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        globals = player.GetComponent<playerGlobals>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && (globals.fuel > 0)) {
            RaycastHit hit;
            int layerMaskTerrain = 1 << 10;
            int layerMaskEnemies = 1 << 11;

            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, beamLength, layerMaskTerrain)) {


                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue, 5f, true);
                Debug.Log("Hit Terrain");
            } else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, beamLength, layerMaskEnemies)) {
                // hit.collider -= (beamDamage * Time.deltaTime); // take health from enemy hit

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red, 5f, true);
                Debug.Log("Hit Enemy");
            } else {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.blue, 100f, true);
                Debug.Log("Did not Hit");
            }
            globals.fuel -= (beamCost * Time.deltaTime);
        }
        Debug.Log(globals.fuel);
    }
}
