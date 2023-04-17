/*****************************************************************************
// File Name :         HealthBarBehaviour.cs
// Author :            Lorien Nergard
// Creation Date :     April 11th, 2023
//
// Brief Description : Inherits from PlayerBehaviour, Contains all the important information designated to the defender role,
enabled at the start of the game when the player collides with the appropriate box. 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    private int healthNumber;

    //Sets the health bar to full
    public void SetMaxHealth()
    {
        slider.maxValue = healthNumber;
        slider.value = healthNumber;
    }

    //Sets the health bar to the current players health
    public void SetHealth()
    {
        slider.value = healthNumber;
    }
}
