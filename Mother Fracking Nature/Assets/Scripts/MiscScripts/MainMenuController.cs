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

    private void Awake()
    {
        /*
        inputAsset = this.GetComponent<PlayerInput>().actions;
        playerControls = inputAsset.FindActionMap("PlayerActions");
        */

        startGame = playerControls.FindAction("StartGame");
        startGame.performed += ctx => playGame();
        
    }


    public void playGame()
    {
        SceneManager.LoadScene("SceneOne");
    }
}
