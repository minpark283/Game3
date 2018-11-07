using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BroccoliBehavior : MonoBehaviour {
    public GameObject levelinfo;
    public float speed;
    public float attackRange;
    public float attackPerSecond;
    public float attackDamage;
    public GameObject player;
    public GameObject deathAnim;
    NavMeshAgent navAgent;
    Animator anim;
    public int health;
    public float[,] grid;
    float lastAttkTime = 0;

    
	// Use this for initialization
	void Start () {
        levelinfo = GameObject.Find("Enemy_Generator");
        player = GameObject.Find("Player");
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.Warp(this.transform.position);
        navAgent.speed = speed;
        navAgent.destination = player.transform.position;
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        if (Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x))
            + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z))) <= attackRange) {
            if (navAgent.isStopped != true)
                navAgent.isStopped = true;
            if (anim.applyRootMotion != false)
                anim.applyRootMotion = false;
            if (Time.time - lastAttkTime >= 1 / attackPerSecond)
            {
                anim.SetTrigger("attack");
                lastAttkTime = Time.time;
            }

        } else {
            navAgent.isStopped = false;
            anim.applyRootMotion = true;
            navAgent.destination = player.transform.position;
        }
	}

    public void Hit(int damage) {
        //Deal damage and check for death
        Debug.Log(health);
        health = health - damage;
        if(health <= 0) { this.Die(); }
    }

    public void Die() {
        //Put other stuff, like animations, in here
        levelinfo.GetComponent<Scr_Level_Design>().numEnemyinWaves -= 1;
        levelinfo.GetComponent<Scr_Level_Design>().updateWaveText();
      
        GameObject.Instantiate(deathAnim);
        deathAnim.transform.position = transform.position;
        Destroy(deathAnim, 3f);
        GameObject.Destroy(this.gameObject);
    }
}
