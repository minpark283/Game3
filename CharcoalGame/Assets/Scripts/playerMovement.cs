using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public float speed;
    public Transform cameraTransform;
    public Rigidbody rb;
    public Collider groundCollider;
    public float jumpPower;
    float distToGround;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        groundCollider = GetComponent<Collider>();
        distToGround = groundCollider.bounds.extents.y;
    }

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

        // player jump
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded())) {
            rb.AddForce(0, jumpPower, 0, ForceMode.Impulse); // impulse 
        }
    }

    // raycast vector below player to check for ground
    bool isGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
    }
}
