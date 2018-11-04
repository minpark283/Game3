using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMelee : MonoBehaviour {
    public float meleeLength;
    public float meleeDamage;
    public float meleeCooldown;
    private float cooldown;
    private GameObject player;
    private playerGlobals globals;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        globals = player.GetComponent<playerGlobals>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(1) && (Time.time > cooldown)) {
            RaycastHit hit;
            int layerMaskTerrain = 1 << 10;
            int layerMaskEnemies = 1 << 11;

            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, meleeLength, layerMaskTerrain)) {


                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue, 5f, true);
                Debug.Log("Hit Terrain");
            } else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, meleeLength, layerMaskEnemies)) {
                // hit.collider -= (meleeDamage * Time.deltaTime); // take health from enemy hit

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red, 5f, true);
                Debug.Log("Hit Enemy");
            } else {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * meleeLength, Color.green, 100f, true);
                Debug.Log("Did not Hit");
            }

            cooldown = Time.time + meleeCooldown;
        }
    }
}