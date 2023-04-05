/*****************************************************************************
// File Name :         DefenderBehaviour.cs
// Author :            Matthew McCoy
// Creation Date :     March 28th, 2023
//
// Brief Description : Inherits from PlayerBehaviour, Contains all the important information designated to the defender role,
enabled at the start of the game when the player collides with the appropriate box. 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBehaviour : PlayerBehaviour
{
    public Sprite Lady;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Lady;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
