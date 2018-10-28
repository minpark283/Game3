using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player : MonoBehaviour {

    public float player_speed;
    private Rigidbody player_body;
    private float moveX;
    private float moveY;

    // Use this for initialization
    void Start () {
        player_body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveX = Input.GetAxis("Horizontal");
        moveY  = Input.GetAxis("Vertical");

        player_body.velocity = new Vector3(moveX * player_speed, this.player_body.velocity.y, moveY * player_speed );

    }
}
