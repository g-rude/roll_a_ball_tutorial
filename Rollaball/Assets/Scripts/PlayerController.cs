using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;

    private Rigidbody rb;
    

    private float movementX;
    private float movementY;


    // Start is called before the first frame update
    void Start()
    {
       // this is not strictly enforced
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();


        // this is a no no
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //this is messy
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

}
