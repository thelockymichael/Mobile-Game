using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;


public class PlayerMovement : MonoBehaviour {


    public CharacterController2D PlayerController;

    private float horizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;

    bool crouch = false;

    private Animator anim;

    private void Update()
    {

        anim = GetComponent<Animator>();

        var InputDevice = InputManager.ActiveDevice;

        horizontalMove = InputDevice.LeftStickX * runSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (InputDevice.Action1.WasPressed)
        {
            jump = true;
        }

       if (InputDevice.LeftStickDown)
        {
            crouch = true;
        } 
       else if (InputDevice.LeftStickUp)
        {
            crouch = false;
        }
    }

    // FixedUpdate is called before update and works better with rigidbodies
    void FixedUpdate () {

        PlayerController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        var InputDevice = InputManager.ActiveDevice;
        // Action1
        // LeftStick
        // Input.GetAxisRaw()

        if (InputDevice.LeftStickLeft)
        {

        }

        if (InputDevice.LeftStickRight)
        {

        }

        if (InputDevice.LeftStickX)
        {

        }

        if (InputDevice.Action1.WasPressed) // A
        {

        }

        if (InputDevice.Action2.WasPressed) // B
        {

        }
    }
}
