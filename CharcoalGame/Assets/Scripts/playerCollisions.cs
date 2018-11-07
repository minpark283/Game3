using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollisions : MonoBehaviour {
    public float peaPodDamage;
    public float broccoliDamage;
    public float carrotDamage;
    public float fuelGain;
    private playerGlobals globals;
    private charcoalSpawner charcoalSpawnerScript;
    [Range(0.1f, 1.0f)]
    public float volume;
    public AudioClip splatSound;
    public AudioSource audioSource;

    // Use this for initialization
    void Start() {
        globals = GetComponent<playerGlobals>();
        charcoalSpawnerScript = GetComponent<charcoalSpawner>();
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("CARROT ATTK");
        if (collision.gameObject.layer == 12) { // collision with enemy projectile
            globals.health -= peaPodDamage;
            audioSource.PlayOneShot(splatSound, volume);
            Destroy(collision.gameObject);
            // possible projectile animation on destroy
        } else if (collision.gameObject.layer == 14) { // collision with charcoal
            globals.fuel += fuelGain;
            if (globals.fuel > 100) { globals.fuel = 100; }
            // animation for eating charcoal with spatula
            // spawn another charcoal
            Destroy(collision.gameObject);
            charcoalSpawnerScript.currentNumberOfCharcoal -= 1;
        } else if (collision.gameObject.layer == 15) { // collision with broccoli
            globals.health -= broccoliDamage;
            // play broccoli attack sound
            collision.collider.gameObject.SendMessage("turn hitbox off");
        } else if (collision.gameObject.layer == 16) { // collision with carrot
            Debug.Log("CARROT ATTK");
            globals.health -= carrotDamage;
            collision.collider.gameObject.SendMessage("turn hitbox off");
        }
    }
}
