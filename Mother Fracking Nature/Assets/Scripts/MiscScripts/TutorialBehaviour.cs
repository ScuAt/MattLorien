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
    public Sprite[] spriteArray = new Sprite[11];

    public SpriteRenderer spriteRenderer;

    public GameObject playerPrefab;

    public GameObject towerHealthBar;
    public GameObject towerBarBackground;

    public GameObject attackerCircle;
    public GameObject defednerCircle;

    public GameObject attackerText;
    public GameObject defenderText;

    InputActionAsset inputAsset4;
    InputActionMap playerActions;
    InputAction joinButton;
    InputAction startGame;

    private float joinTimer = 5;
    public float joinCountdown;

    private float attackerTimer = 5;
    public float attackerCountdown;

    private bool startEnemies;

    private bool startTutorial;

    public int attackerNum;


    private void Awake()
    {
        inputAsset4 = playerPrefab.GetComponent<PlayerInput>().actions;
        playerActions = inputAsset4.FindActionMap("PlayerActions");

        joinButton = playerActions.FindAction("Join");
        joinButton.performed += ctx => OnJoin();

        startGame = playerActions.FindAction("SkipTutorial");
        startGame.performed += ctx => Skip();

    }

    public void Skip()
    {
        SceneManager.LoadScene("SceneOne");
    }


    /// <summary>
    ///  Start is called before the first frame update
    /// </summary>
    void Start()
    {
        spriteRenderer.sprite = spriteArray[0];

        joinCountdown = joinTimer;
        attackerCountdown = attackerTimer;

        startTutorial = false;

        attackerCircle.SetActive(false);
        defednerCircle.SetActive(false);

        attackerText.SetActive(false);
        defenderText.SetActive(false);

        towerHealthBar.SetActive(false);
        towerBarBackground.SetActive(false);

        startEnemies = false;
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

            else if (joinCountdown <= 0)
            {
                spriteRenderer.sprite = spriteArray[2];
                

                //To stop the script from searching for the circles incase a 
                //player selects a role
                if (attackerCircle == null || defednerCircle == null)
                {
                    attackerCountdown -= Time.deltaTime;
                    if (attackerCountdown <= 0)
                    {
                        attackerText.SetActive(true);
                        spriteRenderer.sprite = spriteArray[3];

                        if (attackerCountdown <= -5 && attackerCountdown >= -10)
                        {
                            spriteRenderer.sprite = spriteArray[4];
                        }

                        if (attackerCountdown <= -10 && attackerCountdown >= -15)
                        {
                            spriteRenderer.sprite = spriteArray[5];
                        }

                        if (attackerCountdown <= -20 && attackerCountdown >= -25)
                        {
                            attackerText.SetActive(false);
                            defenderText.SetActive(true);
                            spriteRenderer.sprite = spriteArray[6];
                        }

                        if (attackerCountdown <= -25 && attackerCountdown >= -30)
                        {
                            attackerText.SetActive(false);
                            defenderText.SetActive(true);
                            spriteRenderer.sprite = spriteArray[7];
                        }

                        if (attackerCountdown <= -30 && attackerCountdown >= -35)
                        {
                            attackerText.SetActive(false);
                            defenderText.SetActive(true);
                            spriteRenderer.sprite = spriteArray[8];
                        }

                        if (attackerCountdown <= -35 && attackerCountdown >= -40)
                        {
                            attackerText.SetActive(false);
                            defenderText.SetActive(false);
                            spriteRenderer.sprite = spriteArray[9];
                        }

                        if (attackerCountdown <= -40 && attackerCountdown >= -45)
                        {
                            attackerText.SetActive(false);
                            defenderText.SetActive(false);
                            spriteRenderer.sprite = spriteArray[10];
                            towerBarBackground.SetActive(true);
                            towerHealthBar.SetActive(true);
                            startEnemies = true;
                        }

                        if (startEnemies == true)
                        {
                            SceneManager.LoadScene("SceneOne");
                        }

                    }

                }        
                
                else
                {
                    attackerCircle.SetActive(true);
                    defednerCircle.SetActive(true);
                    return;
                }
            }
        }
    }

    /// <summary>
    /// Is triggered when players join
    /// </summary>
    private void OnJoin()
    {
        startTutorial = true;
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
