using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeaPodBehavior : MonoBehaviour {

    public float speed;
    public float attackRange;
    public float attackPerSecond;
    public float attackDamage;
    public GameObject player;

    //public GameObject hitBox;

    NavMeshAgent navAgent;
    Animator anim;

    public int health;

    float lastAttkTime = 0;

    // Use this for initialization
    void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.Warp(this.transform.position);
        navAgent.speed = speed;
        navAgent.destination = player.transform.position;
        anim = GetComponent<Animator>();
        //hitBox.GetComponent<BroccoliHitScript>().damage = attackDamage;
    }
	
	// Update is called once per frame
	void Update () {
        navAgent.destination = player.transform.position;
        if(Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x))
            + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z))) <= attackRange)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, player.transform.position.z - transform.position.z), out hit))
            {
                if(hit.transform.gameObject.tag.Equals("Player"))
                {
                    //Start attacking here;
                    navAgent.isStopped = true;
                }
            }
        }
        else
        {
            navAgent.isStopped = false;
        }
    }
}
