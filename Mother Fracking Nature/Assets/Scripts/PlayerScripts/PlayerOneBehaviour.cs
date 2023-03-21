using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneBehaviour : MonoBehaviour
{
    //Calling reference to the map lighting bolt thing
    PlayerOneControls controls;

    //Vector2 movement for the square
    Vector2 movement;

    Vector2 rotation;

    //Awake gets called a hair before start does
    private void Awake()
    {
        controls = new PlayerOneControls();

        //Read in the x,y of the stick and saves that in the movement varible movement
        //All this does is save that value
        controls.PlayerOneActions.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();

        //Canceled is for when you let go of the stick
        //So this sets it to zero so the square won't stop moving
        controls.PlayerOneActions.Move.canceled += ctx => movement = Vector2.zero;
    }

    //Use fixed update to listen for inputs
    private void FixedUpdate()
    {
        //Use delta time to have it move indepently
        //5f is the speed
        //Space.Self is telling it where to move
        Vector2 moveVelocity = new Vector2(movement.x, movement.y) * 10f * Time.deltaTime;
        transform.Translate(moveVelocity, Space.Self);
    }

    private void OnEnable()
    {
        //Get's called when you hit play
        //Turns on actions map and actions, etc
        controls.PlayerOneActions.Enable();
    }

    private void OnDisable()
    {
        //Making sure you have clean access to code
        //Closing everything out
        controls.PlayerOneActions.Disable();
    }
}
