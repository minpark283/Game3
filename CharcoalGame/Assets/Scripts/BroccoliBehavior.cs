using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroccoliBehavior : MonoBehaviour {

    public float speed;
    public GameObject player;

    public int health;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
