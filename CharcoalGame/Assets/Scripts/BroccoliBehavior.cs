using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BroccoliBehavior : MonoBehaviour {

    public float speed;
    public float attackRange;
    public float attackPerSecond;
    public float attackDamage;
    public GameObject player;

    public GameObject hitBox;

    NavMeshAgent navAgent;
    Animator anim;

    public int health;

    public float[,] grid;

    //bool doStuff = false;
    float lastAttkTime = 0;

    //public GameObject player;
    
	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.Warp(this.transform.position);
        navAgent.speed = speed;
        navAgent.destination = player.transform.position;
        anim = GetComponent<Animator>();
        hitBox.GetComponent<BroccoliHitScript>().damage = attackDamage;
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
		
	}

    void Hit(int damage)
    {
        //Deal damage and check for death
        health = health - damage;
        if(health <= 0)
        {
            //play a death animation maybe?
            this.Die();
        }
        //Possibly a hit animation?
    }

    void Die()
    {
        //Put other stuff, like animations, in here
        GameObject.Destroy(this);
    }
}
