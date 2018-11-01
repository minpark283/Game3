using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBeam : MonoBehaviour {
    public float beamRange;
    public float beamLength;
    public float beamCooldown;
    public float beamDamage;
    private float cooldown;
    private GameObject player;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        float distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);
        if ((distanceFromPlayer <= beamRange) && (Time.time > cooldown)) {
            RaycastHit hit;
            int layerMaskTerrain = 1 << 10;
            int layerMaskPlayer = 1 << 9;

            // does the ray intersect any objects on the terrain layer, player layer, or nothing
            if (Physics.Raycast(transform.position, player.transform.position, out hit, beamLength, layerMaskTerrain)) {


                Debug.DrawRay(transform.position, player.transform.position * hit.distance, Color.blue, 5f, true);
                Debug.Log("Hit Terrain");
            } else if (Physics.Raycast(transform.position, player.transform.position, out hit, beamLength, layerMaskPlayer)) {
                // hit.collider -= (beamDamage); // take health from player hit

                Debug.DrawRay(transform.position, player.transform.position * hit.distance, Color.red, 5f, true);
                Debug.Log("Hit Player");
            } else {
                Debug.DrawRay(transform.position, player.transform.position * 10, Color.blue, 5f, true);
                Debug.Log("Did not Hit");
            }

            cooldown = Time.time + beamCooldown;
        }
    }
}
