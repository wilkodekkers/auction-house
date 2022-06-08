/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump")) {
            rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);

        }

        if (Input.GetKey("up")) {
            rb.velocity = new Vector3(0, 0, 5);
            
        }
        if (Input.GetKey("a")) {
            rb.velocity = new Vector3(5f, 0, 0);
            
        }
        if (Input.GetKey("d")) {
           rb.velocity = new Vector3(-5f, 0, 0);
            
        }
          if (Input.GetKey("down")) {
            rb.velocity = new Vector3(0, 0, -5);
            
        }
    }
}
*/