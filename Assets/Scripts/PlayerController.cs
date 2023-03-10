using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f; //character speed
    public float gravity = -10;  
    Vector3 velocity; //calculated in each direction
    CharacterController characterController;

    public Transform groundCheck; //space for our object
    public LayerMask groundMask; //group of object which will be a ground layer
    bool isGrounded; //checking if we are on the ground
    
    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);

        RaycastHit hit; //reference to the object that was hit
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag; // checking the tag of hit object
            switch (terrainType)
            {
                default:    //default speed when we are on regular terrein
                    speed = 12;
                    break;
                case "Low": //slower terrain speed
                    speed = 3;
                    break;
                case "High": //faster terrain speed
                    speed = 20;
                    break;

            }
        }
        

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
