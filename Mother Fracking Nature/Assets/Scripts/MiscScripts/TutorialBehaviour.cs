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
    public Sprite[] spriteArray = new Sprite[6];

    public SpriteRenderer spriteRenderer;

    public GameObject playerPrefab;

    public GameObject attackerCircle;
    public GameObject defednerCircle;

    public GameObject attackerText;

    InputActionAsset inputAsset4;
    InputActionAsset inputAsset5;
    InputActionMap playerActions;
    InputActionMap attackerActions;
    InputAction joinButton;
    InputAction startGame;
    InputAction basicAttack;
    InputAction ability;

    private float joinTimer = 5;
    public float joinCountdown;

    private float attackerTimer = 5;
    public float attackerCountdown;

    private bool startTutorial;

    public bool attackerTutorial;

    public int attackerNum;


    private void Awake()
    {
        inputAsset4 = playerPrefab.GetComponent<PlayerInput>().actions;
        playerActions = inputAsset4.FindActionMap("PlayerActions");

        inputAsset5 = playerPrefab.GetComponent<PlayerInput>().actions;
        attackerActions = inputAsset5.FindActionMap("AttackerActions");

        basicAttack = attackerActions.FindAction("Attack");

        ability = attackerActions.FindAction("Ability");

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
        attackerTutorial = false;
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
                if (attackerCircle == null)
                {
                    attackerCountdown -= Time.deltaTime;
                    if (attackerCountdown <= 0)
                    {
                        attackerText.SetActive(true);
                        spriteRenderer.sprite = spriteArray[3];

                        if (basicAttack.triggered)
                        {
                            spriteRenderer.sprite = spriteArray[4];
                        }

                        if (ability.triggered)
                        {
                            spriteRenderer.sprite = spriteArray[5];
                        }

                    }

                    
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
