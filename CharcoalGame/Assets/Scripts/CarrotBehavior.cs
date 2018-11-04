using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarrotBehavior : MonoBehaviour {

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

    float lastAttkTime = 0;

    // Use this for initialization
    void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.Warp(this.transform.position);
        navAgent.speed = speed;
        navAgent.destination = player.transform.position;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        navAgent.destination = player.transform.position;
        //print(midCharge);
        
        if (!charging && Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x))
            + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z))) <= attackRange
            && Time.time - lastAttkTime >= attackCooldown)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, player.transform.position.z - transform.position.z), out hit))
            {
                if (hit.transform.gameObject.tag.Equals("Player"))
                {

                    navAgent.isStopped = true;
                    target = player.transform.position;
                    Quaternion direction = Quaternion.LookRotation(target - transform.position);
                    transform.rotation = direction;
                    anim.SetTrigger("launch");
                }
            }
        }
        else if (!charging && Time.time - lastAttkTime >= attackCooldown)
        {
            navAgent.isStopped = false;
        }
        if(Mathf.Abs(transform.position.x - target.x) <= 1 && Mathf.Abs(transform.position.z - target.z) <= 1)
        {
            print("got here");

            anim.SetTrigger("StandUp");
            lastAttkTime = Time.time;
            charging = false;
            midCharge = false;
            hitBox.SetActive(false);
            // navAgent.isStopped = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    public void Launch()
    {
        hitBox.SetActive(true);
        GetComponent<Rigidbody>().AddForce(transform.forward * chargeStrength, ForceMode.Impulse);
    }

}
