/*****************************************************************************
// File Name :         TutorialBehaviour.cs
// Author :            Lorien Nergard
// Creation Date :     April 25th, 2023
//
// Brief Description : Controls the tutorial text
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TutorialBehaviour : MonoBehaviour
{
    public Sprite[] spriteArray = new Sprite[4];

    public SpriteRenderer spriteRenderer;

    public GameObject playerPrefab;

    public GameObject attackerCircle;
    public GameObject defednerCircle;

    public GameObject attackerText;

    InputActionAsset inputAsset4;
    InputActionMap playerActions;
    InputAction joinButton;
    InputAction startGame;

    public float joinTimer = 5;
    public float joinCountdown;

    private bool startTutorial;

    private bool attackerTutorial = false;


    private void Awake()
    {
        inputAsset4 = playerPrefab.GetComponent<PlayerInput>().actions;
        playerActions = inputAsset4.FindActionMap("PlayerActions");

        joinButton = playerActions.FindAction("Join");
        joinButton.performed += ctx => OnJoin();

        startGame = playerActions.FindAction("StartGame");
        startGame.performed += ctx => playGame();

    }

    private void playGame()
    {
        //SceneManager.LoadScene("SceneOne");
    }


    /// <summary>
    ///  Start is called before the first frame update
    /// </summary>
    void Start()
    {
        spriteRenderer.sprite = spriteArray[0];

        joinCountdown = joinTimer;

        startTutorial = false;

        attackerCircle.SetActive(false);
        defednerCircle.SetActive(false);

        attackerText.SetActive(false);
    }

    /// <summary>
    ///  Update is called once per frame
    /// </summary>
    void Update()
    {
        if (startTutorial == true)
        {
            joinCountdown -= Time.deltaTime;


            //This is for picking roles and movement
            if (joinCountdown <= 0 && joinCountdown >= -5)
            {
                spriteRenderer.sprite = spriteArray[1];
            }

            else if (joinCountdown <= -5 && joinCountdown <= 0)
            {
                spriteRenderer.sprite = spriteArray[2];

                //To stop the script from searching for the circles incase a 
                //player selects a role
                if (attackerCircle == null)
                {
                    attackerTutorial = true;
                    return;
                }

                else if (defednerCircle == null)
                {
                    return;
                }
                else
                {
                    attackerCircle.SetActive(true);
                    defednerCircle.SetActive(true);
                }
            }

            //Attacker tutorial
            else if (attackerTutorial == true && joinCountdown <= 0)
            {
                Debug.Log("Goober");
                joinCountdown = joinTimer;

                attackerText.SetActive(true);

                spriteRenderer.sprite = spriteArray[3];

            }
        }

        

        //Spawn static enemy
        //When attacker destroys enemy move onto next instructions
        //Give attacker instructions first

        //Down the attackeer and give defender time to defeat an enemy
        //Spawn enemy close to oil rig so it will damage the rig 
        //Give Defender instructions

        //Include skip(Side of right D - Pad)

        //New scene with a fade-in/out for tutorial

        //Change repair rig to B

        //X to revive 

    }

    /// <summary>
    /// Is triggered when players join
    /// </summary>
    private void OnJoin()
    {
        startTutorial = true;
    }
}
