using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeaPodBehavior : MonoBehaviour {
    Scr_Level_Design levelinfo;
    public float speed;
    public float attackRange;
    public float fireCooldown;
    public float attackDamage;
    public GameObject player;
    public GameObject deathAnim;

    //public GameObject hitBox;
    public GameObject projectileObject;
    public float fireSpeed;
    public float fireRangeTimer;
    private float cooldown;
    private int layerMaskProjectile;
    public bool staggered = false;

    NavMeshAgent navAgent;
    Animator anim;

    public int health;

    float lastAttkTime = 0;

    // Use this for initialization
    void Start () {
        levelinfo = transform.GetComponent<Scr_Level_Design>();
        player = GameObject.Find("Player");
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.Warp(this.transform.position);
        navAgent.speed = speed;
        navAgent.destination = player.transform.position;
        anim = GetComponent<Animator>();
        //hitBox.GetComponent<BroccoliHitScript>().damage = attackDamage;
        layerMaskProjectile = 1 << 12;
        layerMaskProjectile = ~layerMaskProjectile;
    }
	
	// Update is called once per frame
	void Update () {
        navAgent.destination = player.transform.position;
        if(Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x))
            + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z))) <= attackRange && !staggered)
        {
            Quaternion direction = Quaternion.LookRotation(new Vector3(player.transform.position.x - transform.position.x, transform.position.y, player.transform.position.z - transform.position.z));
            transform.rotation = direction;
            RaycastHit hit;
            if(Physics.Raycast(transform.position, new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, player.transform.position.z - transform.position.z), out hit, Mathf.Infinity, layerMaskProjectile))
            {
               
                if(hit.transform.gameObject.tag.Equals("Player") && Time.time >= cooldown)
                {
                    GameObject projectile = (GameObject)Instantiate(projectileObject, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
                    projectile.layer = 12;
                    projectile.GetComponent<Rigidbody>().useGravity = false;
                    projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * fireSpeed;
                    Destroy(projectile, fireRangeTimer);
                    //Physics.IgnoreCollision(gameObject.GetComponentInChildren<Collider>(), projectile.GetComponent<Collider>());
                    cooldown = Time.time + fireCooldown;
                    navAgent.isStopped = true;
                }
            }
        }
        else if(!staggered)
        {
            navAgent.isStopped = false;
        }

        /*if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.SendMessage("Hit", 10);
        }*/
    }

    void Hit(int damage)
    {
        //Deal damage and check for death
        health = health - damage;
        if (health <= 0)
        {
            //play a death animation maybe?
            this.Die();
        }
        //Possibly a hit animation?
    }

    void Die()
    {
        //Put other stuff, like animations, in here
        levelinfo.numEnemyinWaves -= 1;
        levelinfo.updateWaveText();
        GameObject.Instantiate(deathAnim);
        deathAnim.transform.position = transform.position;
        GameObject.Destroy(this.gameObject);
    }
}
