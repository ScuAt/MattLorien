/*****************************************************************************
// File Name :         AttackerBehaviour.cs
// Author :            Matthew McCoy
// Creation Date :     March 28th, 2023
//
// Brief Description : Inherits from PlayerBehaviour, Contains all the important information designated to the attacker role, 
enabled at the start of the game when the player collides with the appropriate box. 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackerBehaviour : PlayerBehaviour
{
    public Sprite Guy;

    InputActionAsset inputAsset;
    InputActionMap attackerActions;
    InputAction attack;

    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        attackerActions = inputAsset.FindActionMap("AttackerActions");
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
        inputAsset = this.GetComponent<PlayerInput>().actions;

        attack = attackerActions.FindAction("Attack");
        
        attack.performed += ctx => Attack();
       

        this.gameObject.GetComponent<SpriteRenderer>().sprite = Guy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// enables the input map
    /// </summary>
    private void OnEnable()
    {
        attackerActions.Enable();
    }
    /// <summary>
    /// Disables the input map
    /// </summary>
    private void OnDisable()
    {
        attackerActions.Disable();
    }

    private void Attack()
    {
        Debug.Log("Attacking");
    }
}
