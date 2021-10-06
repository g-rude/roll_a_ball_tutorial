using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;

    private int count;

    private float movementX;
    private float movementY;


    // Start is called before the first frame update
    void Start()
    {
       // this is not strictly enforced
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }

    

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();


        // this is a no no
        movementX = movementVector.x;
        movementY = movementVector.y;

        // invert controls at point level
        if (count >= 5)
        {
            movementX *= -1;
            movementY *= -1;
        }

        // player boost
        

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 13)
        {
            winTextObject.SetActive(true);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //this is messy
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
       
    }



}
