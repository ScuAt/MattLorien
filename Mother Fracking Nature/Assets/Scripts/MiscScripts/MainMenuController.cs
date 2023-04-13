/*****************************************************************************
// File Name :         AttackerBehaviour.cs
// Author :            Lorien Nergard
// Creation Date :     April 11th, 2023
//
// Brief Description : Controls the main menu and switching of scenes 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenuController : MonoBehaviour
{
    InputActionAsset inputAsset;
    InputActionMap playerControls;
    InputAction startGame;

    /// <summary>
    /// Has the code for pressing the button
    /// </summary>
    private void Awake()
    {
        /*
        inputAsset = this.GetComponent<PlayerInput>().actions;
        playerControls = inputAsset.FindActionMap("PlayerActions");
        */

        startGame = playerControls.FindAction("StartGame");
        startGame.performed += ctx => playGame();
        
    }

    /// <summary>
    /// Switches the scene to the next one
    /// </summary>
    public void playGame()
    {
        SceneManager.LoadScene("SceneOne");
    }
}
