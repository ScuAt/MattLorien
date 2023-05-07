/*****************************************************************************
// File Name :         TutorialBehaviour.cs
// Author :            Lorien Nergard
// Creation Date :     April 25th, 2023
//
// Brief Description : Controls the tutorial text
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBehaviour : MonoBehaviour
{
    public Sprite[] spriteArray = new Sprite[8];

    public SpriteRenderer spriteRenderer;

    public float joinTextTimer = 5;
    public float joinTextCountdown;


    /// <summary>
    ///  Start is called before the first frame update
    /// </summary>
    void Start()
    {
        joinTextCountdown = joinTextTimer;
        spriteRenderer.sprite = spriteArray[0];

        //Hey! I'm testing to see if github works so I'm writing comments to make little changes
    }

    /// <summary>
    ///  Update is called once per frame
    /// </summary>
    void Update()
    {
        joinTextCountdown -= Time.deltaTime;
        if (joinTextCountdown <= 0 && joinTextCountdown >= -5)
        {
            spriteRenderer.sprite = spriteArray[1];
        }
        else if (joinTextCountdown <= -5 && joinTextCountdown >= -10)
        {
            spriteRenderer.sprite = spriteArray[2];
        }
        else if (joinTextCountdown <= -10 && joinTextCountdown >= -15)
        {
            spriteRenderer.sprite = spriteArray[3];
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

        else if (joinTextCountdown <= -15 && joinTextCountdown >= -20)
        {
            spriteRenderer.sprite = spriteArray[4];
        }
        else if (joinTextCountdown <= -20 && joinTextCountdown >= -25)
        {
            spriteRenderer.sprite = spriteArray[5];
        }
        else if (joinTextCountdown <= -25 && joinTextCountdown >= -30)
        {
            spriteRenderer.sprite = spriteArray[6];
        }
        else if (joinTextCountdown <= -30 && joinTextCountdown >= -35)
        {
            spriteRenderer.sprite = spriteArray[7];
        }
    }
}
