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
    public Sprite[] spriteArray = new Sprite[4];

    public SpriteRenderer spriteRenderer;

    private float joinTextTimer = 5;
    private float joinTextCountdown;

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
        if (joinTextCountdown <= 0)
        {
            //
        }
    }
}
