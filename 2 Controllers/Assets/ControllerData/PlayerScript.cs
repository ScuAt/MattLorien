using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{

    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction move;

    Vector2 movement;

    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActionMap");
        move = inputMap.FindAction("Move");

        move.performed += contx => movement = contx.ReadValue<Vector2>();
        move.canceled += contx => movement = Vector2.zero; 
    }

    private void FixedUpdate()
    {
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 5f * Time.deltaTime;
        transform.Translate(movementVelocity, Space.Self);
    }

    private void OnEnable()
    {
        inputMap.Enable();

    }

    private void OnDisable()
    {
        inputMap.Disable();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
