using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionWithPeapodShot : MonoBehaviour {
    public AudioClip splatSound;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == 12) { // collision with enemy projectile
            audioSource.PlayOneShot(splatSound);
            Destroy(collision.gameObject);
        }
    }
}
