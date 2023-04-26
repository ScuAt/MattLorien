using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderHealthBar : MonoBehaviour
{
    public float healthBar;


    /// <summary>
    /// find the defenderHealth from the game controller script and applies size based on the current health
    /// </summary>
    void Update()
    {
        GameController gc = FindObjectOfType<GameController>();

        healthBar = gc.defenderHealth/2.5f;

        RectTransform rt = gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(healthBar, 100);
    }
}
