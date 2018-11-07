using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarrotBehavior : MonoBehaviour {
    Scr_Level_Design levelinfo;
    public float speed;
    public float attackRange;
    public float attackCooldown;
    public float attackDamage;
    public GameObject player;

    public GameObject hitBox;

    NavMeshAgent navAgent;
    Animator anim;

    public int health;

    public bool charging;
    Vector3 target;
    public float chargeStrength;
    public bool midCharge;

    public float standUpTime;

    float lastAttkTime;

    // Use this for initialization
    void Start () {
        levelinfo = transform.GetComponent<Scr_Level_Design>();
        player = GameObject.Find("Player");
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.Warp(this.transform.position);
        navAgent.speed = speed;
        navAgent.destination = player.transform.position;
        anim = GetComponent<Animator>();
        lastAttkTime = -attackCooldown;
    }
	
	// Update is called once per frame
	void Update () {
        //navAgent.destination = player.transform.position;
        //print(midCharge);
        print(target);
        if(!charging && Time.time - lastAttkTime < attackCooldown)
        {
            navAgent.isStopped = false;
            navAgent.destination = transform.position;
        }
        
        if (!charging && Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x))
            + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z))) <= attackRange
            && Time.time - lastAttkTime >= attackCooldown)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, player.transform.position.z - transform.position.z), out hit) && Time.time - lastAttkTime >= attackCooldown && !charging)
            {
                if (hit.transform.gameObject.tag.Equals("Player") && !charging)
                {
                    this.PrepareCharge();
                    //navAgent.isStopped = true;
                    //target = player.transform.position;
                    //Quaternion direction = Quaternion.LookRotation(target - transform.position);
                    //transform.rotation = direction;
                    //anim.SetTrigger("launch");
                }
            }
        }
        else if (!charging && Time.time - lastAttkTime >= attackCooldown)
        {
            navAgent.isStopped = false;
            navAgent.destination = player.transform.position;
            navAgent.updateRotation = true;
            //anim.ResetTrigger("StandUp");
            //anim.ResetTrigger("launch");
        }
        if(midCharge && Mathf.Abs(transform.position.x - target.x) <= 1 && Mathf.Abs(transform.position.z - target.z) <= 1)
        {
            print("got here");
            anim.ResetTrigger("launch");
            anim.SetTrigger("StandUp");
            lastAttkTime = Time.time;
            charging = false;
            midCharge = false;
            hitBox.SetActive(false);
            navAgent.isStopped = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            target = new Vector3(1000, 1000, 1000);
        }

        
        
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
        GameObject.Destroy(this);
    }


    void PrepareCharge()
    {
        print("prepare charge");
        lastAttkTime = Time.time;
        //charging = true;
        navAgent.isStopped = true;
        target = player.transform.position;
        Quaternion direction = Quaternion.LookRotation(target - transform.position);
        transform.rotation = direction;
        anim.ResetTrigger("StandUp");
        anim.SetTrigger("launch");
    }

    public void Launch()
    {
        print("launch");
        navAgent.updateRotation = false;
        hitBox.SetActive(true);
        midCharge = true;
        GetComponent<Rigidbody>().AddForce(transform.forward * chargeStrength, ForceMode.Impulse);
    }

}
