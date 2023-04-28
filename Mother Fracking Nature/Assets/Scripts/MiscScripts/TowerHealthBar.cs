/*****************************************************************************
// File Name :         TowerHealthBar.cs
// Author :            Matthew McCoy
// Creation Date :     Apirl 26th, 2023
//
// Brief Description : adjusts tower health bar based on the current health
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthBar : MonoBehaviour
{

    public float healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// changes tower health bar everytime the tower health is changed
    /// </summary>
    void Update()
    {
        GameController gc = FindObjectOfType<GameController>();

        healthBar = gc.towerHealth/5;

        RectTransform rt = gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(healthBar, 100);
    }
}
