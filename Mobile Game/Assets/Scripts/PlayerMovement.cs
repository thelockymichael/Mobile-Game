﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using InControl;


public class PlayerMovement : MonoBehaviour {

    // Reference the CharacterController script
    public CharacterController2D PlayerController;

    //Health 
    public int maximumHealth = 20;
    public int currentHealth;

    // Movement and crouching
    private float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    // Attack variables
    public int damage = 20;
    bool attack = false;
    private float attackTimer = 0;
    private float attackDelay = 0.2f;
    public float knockBack = 200f;
    public Transform attackMove;

    //Get these components
    private Rigidbody2D rb;
    private Animator anim;
    public Collider2D attackTrigger;

   // public GameObject FrogAI;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (attackTrigger == true && col.CompareTag("Enemy"))
        {
            Debug.Log("YOU'VE HIT AN ENEMY " + damage);
            col.SendMessage("Damage", damage);

            // Destroy(col.gameObject);
            // FrogAI.Damage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("PLAYER TOUCHES ENEMY");
            Vector3 moveDirection = rb.transform.position - collision.transform.position;
            rb.AddForce(moveDirection.normalized * knockBack * 10);
        }
    }

    private void Start()
    {
        currentHealth = maximumHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        //FrogAI = GetComponent<frogAI>();
        anim = GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    // FixedUpdate is called before update and works better with rigidbodies
    void FixedUpdate()
    {

        PlayerController.Move(horizontalMove * Time.deltaTime, crouch, jump);
        jump = false;


        var InputDevice = InputManager.ActiveDevice;
        // Action1
        // LeftStick
        // Input.GetAxisRaw()

        horizontalMove = InputDevice.LeftStickX * runSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (InputDevice.Action1)
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }

        if (InputDevice.Action2 && !attack)
        {
            attack = true;
            attackTimer = attackDelay;

            attackTrigger.enabled = true;
            // StartCoroutine("AttackDelay");
        }

        if (attack)
        {
            Vector3 moveDirection = rb.transform.position - attackMove.transform.position;
            rb.AddForce(moveDirection.normalized * -knockBack);

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attack = false;
                attackTrigger.enabled = false;
            }
        }
        anim.SetBool("IsAttacking", attack);

        if (InputDevice.LeftStickDown)
        {
            crouch = true;
        }

        else if (InputDevice.LeftStickUp || !InputDevice.LeftStick)
        {
            crouch = false;
        }
        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Damage (int damage)
    {
        currentHealth -= damage;
        StartCoroutine("getHurtDelay");
        Debug.Log("PLAYER HAS TAKEN DAMAGE");
    }
    IEnumerator getHurtDelay()
    {
        anim.SetBool("IsHurt", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("IsHurt", false);
    }

    /*
    IEnumerator AttackDelay()
    {

        anim.SetBool("IsAttacking", true);
        Debug.Log("Attacking");
        yield return new WaitForSeconds(attackDelay);
        anim.SetBool("IsAttacking", false);
        }
        */
    public void OnLanding()
    {
        anim.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool IsCrouching)
    {
        anim.SetBool("IsCrouching", IsCrouching);
    }
      public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
