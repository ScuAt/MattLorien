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
    public Sprite[] spriteArray = new Sprite[5];

    public SpriteRenderer spriteRenderer;

    public float joinTextTimer = 5;
    public float joinTextCountdown;



    // Start is called before the first frame update
    void Start()
    {
        joinTextCountdown = joinTextTimer;
        spriteRenderer.sprite = spriteArray[0];
    }

    // Update is called once per frame
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
        else if (joinTextCountdown <= -15 && joinTextCountdown >= -20)
        {
            spriteRenderer.sprite = spriteArray[4];
        }
    }
}
