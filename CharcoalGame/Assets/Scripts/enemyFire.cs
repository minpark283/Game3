using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFire : MonoBehaviour {
    public float fireCooldown;
    public float fireRange;
    public float fireSpeed;
    public float fireRangeTimer;
    private float cooldown;
    public GameObject projectileObject;
    private GameObject player;
    [Range(0.1f, 1.0f)]
    public float volume;
    public AudioClip shootSound;
    public AudioSource audioSource;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        float distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);
        if ((distanceFromPlayer <= fireRange) && (Time.time > cooldown)) {
            GameObject projectile = (GameObject)Instantiate(projectileObject, transform.position, transform.rotation);
            projectile.layer = 12;
            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * fireSpeed;
            Destroy(projectile, fireRangeTimer);

            audioSource.PlayOneShot(shootSound, volume);
            cooldown = Time.time + fireCooldown;
        }
    }
}
