using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerHealthBar : MonoBehaviour
{

    public float healthBar;
    

    /// <summary>
    /// find the attackerHealth from the game controller script and applies size based on the current health
    /// </summary>
    void Update()
    {
        GameController gc = FindObjectOfType<GameController>();

        healthBar = gc.attackerHealth;

        RectTransform rt = gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(healthBar, 100);
    }
}
