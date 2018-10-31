using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitFollowCamera : MonoBehaviour {
    public Transform playerTransform;
    private Vector3 cameraOffset;
    public float orbitSpeed;
    [Range(0.01f, 1.00f)]
    public float smoothness;


	// Use this for initialization
	void Start () {
        cameraOffset = transform.position - playerTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // follow player by camera offset
        Vector3 positionUpdate = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, positionUpdate, smoothness);

        // allow camera to orbit horizontally
        float scrollMovement = Input.GetAxis("Mouse X") * Time.deltaTime * orbitSpeed;
        Quaternion turnCameraAngle = Quaternion.AngleAxis(scrollMovement, Vector3.up);
        cameraOffset = turnCameraAngle * cameraOffset;

        // set player's Y rotation to the camera's Y rotation
        float cameraRotationY = transform.eulerAngles.y;
        playerTransform.eulerAngles = new Vector3(0f, cameraRotationY, 0f);
        transform.LookAt(playerTransform);
	}
}
