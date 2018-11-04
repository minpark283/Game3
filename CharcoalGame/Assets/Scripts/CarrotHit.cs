using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotHit : MonoBehaviour {

    public float damage;
    public bool alreadyHit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("Player") && !alreadyHit)
        {
            print("hit");
            alreadyHit = true;
            //uncomment this when there's a hit script on the player
            other.SendMessage("Hit", damage);
        }
    }
}
