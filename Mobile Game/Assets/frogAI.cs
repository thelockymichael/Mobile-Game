using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogAI : MonoBehaviour
{

    public CharacterController2D PlayerController;

    public float moveSpeed = 3f;
    public float jumpHeight = 5f;

    public float populationRate = 3f;
    public float frogIdle = 2f;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isGrounded = false;

    // Start is called before the first frame update
    void Awake()
    {
        
       // StartCoroutine("frogJump");
       // StartCoroutine("frogJump");
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    /* IEnumerator frogjump()
     {

         yield return new WaitForSeconds(1);
         rb.AddForce(Vector2.up * jumpHeight);
     }
     */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Frog collides with ground");
            //anim.SetBool("IsJumping", true);
            StartCoroutine("frogJump");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = true;
           // anim.SetBool("IsJumping", false);
            Debug.Log("Frog leaves ground");
             //anim.SetBool("IsJumping", false);

            // StartCoroutine("frogJump");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            Debug.Log("Frog leaves ground");
            

            //  anim.SetBool("IsJumping", true);

            // StartCoroutine("frogJump");
        }
    }


    /*
    IEnumerator frogIdle()
    {
        //while (true)
        // 
        if (isGrounded)
        {


            yield return new WaitForSeconds(populationRate);
            anim.SetBool("IsJumping", false);
            //rb.AddForce(Vector2.up * jumpHeight);
           // rb.AddForce(Vector2.right * moveSpeed);
            Debug.Log("Jumping");
            //   }
        }

    }*/

        IEnumerator frogJump()
    {
        //while (true)
       // 
       if(isGrounded)
        {


            yield return new WaitForSeconds(populationRate);
            anim.SetBool("IsJumping", true);
            rb.AddForce(Vector2.up * jumpHeight);
            rb.AddForce(Vector2.right * -moveSpeed);
            Debug.Log("Jumping");
            yield return new WaitForSeconds(frogIdle);
            anim.SetBool("IsJumping", false);

            //   }
        }

    }
}