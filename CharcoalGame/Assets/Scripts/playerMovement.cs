using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public float speed;
    public Transform cameraTransform;
	
	// Update is called once per frame
	void Update () {
        // get horizontal and vertical inputs for player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        movement = Vector2.ClampMagnitude(movement, 1);

        // use the cameras position for direction inputs instead of world position for direction inputs
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;
        
        transform.position += (forward * movement.y + right * movement.x) * Time.deltaTime * speed;
	}
}
