/*****************************************************************************
// File Name :         DefenderBehaviour.cs
// Author :            Matthew McCoy
// Creation Date :     March 28th, 2023
//
// Brief Description : Inherits from PlayerBehaviour, Contains all the important information designated to the defender role,
enabled at the start of the game when the player collides with the appropriate box. 
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DefenderBehaviour : PlayerBehaviour
{
    //initializes trapdata scriptable object into our defender
    [SerializeField] private TrapData trapData;

    public Sprite Lady;

    InputActionAsset inputAsset3;
    InputActionMap defenderActions;
    InputAction block;
    InputAction place;

    private void Awake()
    {
        inputAsset3 = this.GetComponent<PlayerInput>().actions;
        defenderActions = inputAsset3.FindActionMap("DefenderActions");
    }

  

    // Start is called before the first frame update
    void Start()
    {
        inputAsset3 = this.GetComponent<PlayerInput>().actions;

        block = defenderActions.FindAction("Block");
        block.performed += ctx => Block();

        place = defenderActions.FindAction("Trap");
        place.performed += ctx => trapData.PlaceTrap(); //pulling function from trapData scriptable object

        this.gameObject.GetComponent<SpriteRenderer>().sprite = Lady;
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
        defenderActions.Enable();
    }
    /// <summary>
    /// Disables the input map
    /// </summary>
    private void OnDisable()
    {
        defenderActions.Disable();
    }


    private void Block()
    {
        Debug.Log("Blocking");
    }
}
