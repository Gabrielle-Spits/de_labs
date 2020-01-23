using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float zBound = 6 ;
    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        constrainPlayerPosition();
    }
    
    // moves te player based one arrow key input
    void MovePlayer()
    {
        float Horizontalinput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        Debug.Log(VerticalInput);
        transform.Translate(speed * Horizontalinput * Time.deltaTime,0,speed * VerticalInput * Time.deltaTime);
        
    }
    
    // prevent the player from  leaving the top of bottom of the screen 
    void constrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y, zBound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("player has collided with enemy");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
