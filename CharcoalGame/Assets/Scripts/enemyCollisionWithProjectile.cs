using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollisionWithProjectile : MonoBehaviour {
    public float peaPodDamage;
    private GameObject player;
    private playerGlobals globals;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        globals = player.GetComponent<playerGlobals>();
    }

    private void OnCollisionEnter(Collision hitBy) {
        /*if(hitBy.gameObject.layer == 12) { // collision with projectile
            // take health from enemy
            // possible projectile animation on destroy
            Destroy(hitBy.gameObject);
        }*/
    }
}
