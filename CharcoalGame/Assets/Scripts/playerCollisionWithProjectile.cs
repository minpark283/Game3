using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollisionWithProjectile : MonoBehaviour {
    public float peaPodDamage;
    private playerGlobals globals;

    // Use this for initialization
    void Start() {
        globals = GetComponent<playerGlobals>();
    }

    private void OnCollisionEnter(Collision hitBy) {
        if (hitBy.gameObject.layer == 12) { // collision with projectile
            globals.health -= peaPodDamage;
            Destroy(hitBy.gameObject);
            // possible projectile animation on destroy
        }
    }
}
