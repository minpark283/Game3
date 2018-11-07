using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BroccoliBehavior : MonoBehaviour {
    Scr_Level_Design levelinfo;
    public float speed;
    public float attackRange;
    public float attackPerSecond;
    public float attackDamage;
    public GameObject player;
    public GameObject deathAnim;

    //public GameObject hitBox;

    NavMeshAgent navAgent;
    Animator anim;

    public int health;

    public float[,] grid;

    //bool doStuff = false;
    float lastAttkTime = 0;

    //public GameObject player;
    
	// Use this for initialization
	void Start () {
        levelinfo = transform.GetComponent<Scr_Level_Design>();
        player = GameObject.Find("Player");
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.Warp(this.transform.position);
        navAgent.speed = speed;
        navAgent.destination = player.transform.position;
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x))
            + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z))) <= attackRange)
        {
            if (navAgent.isStopped != true)
                navAgent.isStopped = true;
            if (anim.applyRootMotion != false)
                anim.applyRootMotion = false;
            if (Time.time - lastAttkTime >= 1/attackPerSecond)
            {
                anim.SetTrigger("attack");
                lastAttkTime = Time.time;
            }
            
        }
        else
        {
            navAgent.isStopped = false;
            anim.applyRootMotion = true;
            navAgent.destination = player.transform.position;
        }

        //For testing
        /*if(Input.GetKeyDown(KeyCode.D))
        {
            gameObject.SendMessage("Hit", 10);
        }*/
		
	}

    public void Hit(int damage)
    {
        //Deal damage and check for death
        health = health - damage;
        if(health <= 0)
        {
            
            this.Die();
        }
        //Possibly a hit animation?
    }

    public void Die()
    {
        //Put other stuff, like animations, in here
        levelinfo.numEnemyinWaves -= 1;
        levelinfo.updateWaveText();
        GameObject.Instantiate(deathAnim);
        deathAnim.transform.position = transform.position;
        GameObject.Destroy(this.gameObject);
    }
}
