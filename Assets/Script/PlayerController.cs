                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 7f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Animator playerAnim;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void  OnMovement() {
    

        if (movementDirection.x != 0 || movementDirection.y != 0) {
        
        playerAnim.SetFloat("X,", movementDirection .x);
        playerAnim.SetFloat("Y", movementDirection.y);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
          if (collision.gameObject.CompareTag("Ground"))
        {

        }else if(collision.gameObject.CompareTag("FantasyArcher_01"))
        {
             playerAnim.SetBool("Run", true);
        }
   }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }


    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), 0);

        
    }


    void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
        }
    }

    
}