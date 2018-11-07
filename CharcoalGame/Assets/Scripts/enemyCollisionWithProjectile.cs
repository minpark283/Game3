using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollisionWithProjectile : MonoBehaviour {
    public int projectileDamage;

     void OnCollisionEnter(Collision hitBy) {
        if (hitBy.gameObject.layer == 13) { // collision with player projectile
            gameObject.SendMessage("Hit", projectileDamage);
            Destroy(hitBy.gameObject);
            // possible projectile animation on destroy
        }
    }
}
