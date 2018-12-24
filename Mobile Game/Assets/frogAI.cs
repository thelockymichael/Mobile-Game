using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class frogAI : MonoBehaviour
{
    public GameObject Player;
  
    public float moveSpeed = 3f;
    public float jumpHeight = 5f;

    public float populationRate = 3f;
    public float hurtDelay = 0.2f;

    public float frogIdle = 2f;

    private Rigidbody2D rb;
    private Animator anim;
  //  public Vector3 moveDirection;

    private bool isGrounded = false;
    private bool attacked = false;

    public bool knockedBack;

    //public PlayerMovement playerController;

    public int healthFrog;
    public int startingHealthFrog = 200;
    bool isDead;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;
    public UnityEvent OnLandEvent;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;

    // Start is called before the first frame update
    void Awake()
    {

        // StartCoroutine("frogJump");
        // StartCoroutine("frogJump");
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }
    private void Start()
    {
        healthFrog = startingHealthFrog;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnLanding()

    {
        anim.SetBool("IsJumping", false);
    }
    /*
    IEnumerator attackDelay()
    {
        anim.SetBool("IsAttacked", true);
        yield return new WaitForSeconds(hurtDelay);
        anim.SetBool("IsAttacked", false);

        // yield return null;

    }*/

    private void Update()
    {
        if (healthFrog <= 0)
        {  //tot
            StartCoroutine("Death");
            Debug.Log("Frog died");

        }
        Debug.Log(healthFrog);
    }
    void Death()
    {

        // The enemy is dead.
        isDead = true;
        Destroy(this.gameObject);
        Debug.Log("dead?");
        return;
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
           
            Debug.Log("Frog collides with ground");
            //anim.SetBool("IsJumping", true);
            StartCoroutine("frogJump");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
           if (collision.gameObject.CompareTag("attackTrigger"))
        {
           Vector3 moveDirection = rb.transform.position - collision.transform.position ;
            rb.AddForce(moveDirection.normalized * 500f);
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

    IEnumerator Damage(int damage)
    {
        healthFrog -= damage;
       
        Debug.Log("FROG HAS TAKEN DAMAGE");
     
            anim.SetBool("IsAttacked", true);
        // this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
       // moveDirection = rb.transform.position - Player.transform.position;

        knockedBack = true;

        yield return new WaitForSeconds(hurtDelay);

        anim.SetBool("IsAttacked", false);

       // rb.AddForce(moveDirection.normalized * -500f);
        // this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        knockedBack = false;
/*
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
        knockedBack = true;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        knockedBack = false;
        */
        yield return null;
        }

    
    IEnumerator frogJump()
    { 
            yield return new WaitForSeconds(populationRate);
            anim.SetBool("IsJumping", true);
            rb.AddForce(Vector2.up * jumpHeight);
            rb.AddForce(Vector2.right * -moveSpeed);
            Debug.Log("Jumping");
            yield return new WaitForSeconds(frogIdle);
            //anim.SetBool("IsJumping", false);
            yield return null;
            //   }
        }

    }
