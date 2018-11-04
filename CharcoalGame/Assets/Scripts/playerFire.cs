using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFire : MonoBehaviour {
    public float fireCost;
    public float fireDamage;
    public float fireSpeed;
    public float fireRangeTimer;
    public GameObject projectileObject;
    private playerGlobals globals;

    // Use this for initialization
    void Start() {
        globals = GetComponent<playerGlobals>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && (globals.fuel >= fireCost)) {
            GameObject projectile = (GameObject)Instantiate(projectileObject, transform.position, transform.rotation);
            projectile.layer = 13;
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * fireSpeed;
            Destroy(projectile, fireRangeTimer);
            Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());

            globals.fuel -= fireCost;
        }
    }
}
