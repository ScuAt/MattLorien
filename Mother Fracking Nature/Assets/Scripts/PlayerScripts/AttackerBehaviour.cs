/*****************************************************************************
// File Name :         AttackerBehaviour.cs
// Author :            Matthew McCoy
// Creation Date :     March 28th, 2023
//
// Brief Description : Inherits from PlayerBehaviour, Contains all the important information designated to the attacker role, 
enabled at the start of the game when the player collides with the appropriate box. 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerBehaviour : PlayerBehaviour
{
    public Sprite Guy;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Guy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
