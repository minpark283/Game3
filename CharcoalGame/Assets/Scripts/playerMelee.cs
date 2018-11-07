using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMelee : MonoBehaviour {
    public float meleeLength;
    public float meleeDamage;
    public float meleeCooldown;
    public Animator playerAnimator;
    private float cooldown;
    private playerGlobals globals;

    // Use this for initialization
    void Start() {
        globals = GetComponent<playerGlobals>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(1) && (Time.time > cooldown)) {
            RaycastHit hit;
            int layerMaskTerrain = 1 << 10;
            int layerMaskEnemies = 1 << 15;
            int layerMaskEnemies2 = 1 << 16;

            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, meleeLength, layerMaskTerrain)) {
                Debug.Log("Hit Terrain");
            } else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, meleeLength, layerMaskEnemies)) {
                Debug.Log("Hit Enemy");
            } else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, meleeLength, layerMaskEnemies2)) {
                hit.collider.gameObject.SendMessage("Hit", meleeDamage);
                Debug.Log("Hit Enemy");
            } else {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * meleeLength, Color.green, 100f, true);
                Debug.Log("Did not Hit");
            }

            playerAnimator.SetBool("isAttacking", true);
            playerAnimator.SetBool("isIdle", false);
            Debug.Log("Here");
            cooldown = Time.time + meleeCooldown;
        } else { playerAnimator.SetBool("isIdle", true); playerAnimator.SetBool("isAttacking", false); }
       
    }
}