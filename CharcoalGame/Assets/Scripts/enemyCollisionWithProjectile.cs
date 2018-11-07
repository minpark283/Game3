using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollisionWithProjectile : MonoBehaviour {
    public float peaPodDamage;
    public GameObject player;
    private playerGlobals globals;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        globals = player.GetComponent<playerGlobals>();
    }

     void OnCollisionEnter(Collision hitBy) {
        Debug.Log("Outer");
        if (hitBy.gameObject.layer == 13)
        { // collision with projectile
            Debug.Log("Inner");
            gameObject.SendMessage("Hit", 5);
            // possible projectile animation on destroy
            Destroy(hitBy.gameObject);
        }
    }
}
