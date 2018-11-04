using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFire : MonoBehaviour {
    public float fireCost;
    public float fireDamage;
    public float fireSpeed;
    public float fireRangeTimer;
    public GameObject projectileObject;
    private GameObject player;
    private playerGlobals globals;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        globals = player.GetComponent<playerGlobals>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && (globals.fuel >= fireCost)) {
            GameObject projectile = (GameObject)Instantiate(projectileObject, player.transform.position, player.transform.rotation);
            projectile.layer = 12;
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * fireSpeed;
            Destroy(projectile, fireRangeTimer);

            globals.fuel -= fireCost;
        }
    }
}
