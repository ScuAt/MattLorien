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
using System;

public class MainMenuController : MonoBehaviour
{
    
    /// <summary>
    /// Quits the game
    /// </summary>
    public void exitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Goes to the tutorial
    /// </summary>
    public void playGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
