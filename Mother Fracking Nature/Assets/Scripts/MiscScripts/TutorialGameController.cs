/*****************************************************************************
// File Name :         GameController.cs
// Author :            Matthew McCoy
// Creation Date :     Apirl 20th, 2023
//
// Brief Description : controls all timer and spawning coroutines as well as stores health values
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGameController : MonoBehaviour
{
    public AudioClip attackerTakeDamage;
    public AudioClip defenderTakeDamage;
    public AudioClip towerTakeDamage;

    //public AudioClip gameMusic;
    //public AudioClip loseMusic;



    public float attackerHealth = 100;
    public float defenderHealth = 250;
    public float towerHealth = 500;

    public GameObject endScreen;

    /// <summary>
    /// starts the timer and round control coroutines and displays the time left in the wave
    /// as well as the wave number
    /// </summary>
    void Start()
    {
        endScreen.SetActive(false);
        //GameObject.Find("GameMusic").GetComponent<ParticleSystem>().Play();
        GameObject.Find("LoseMusic").GetComponent<AudioSource>().Stop();

       

    }

    /// <summary>
    /// checks if the first round should start and checks if the game needs to end
    /// </summary>
    void Update()
    {
       

        if (attackerHealth <= 0 && defenderHealth <= 0)
        {
            Debug.Log("Game Over");
            endScreen.SetActive(true);
            GameObject.Find("GameMusic").GetComponent<AudioSource>().Stop();
            GameObject.Find("LoseMusic").GetComponent<AudioSource>().Play();
        }
        if (towerHealth <= 0)
        {
            Debug.Log("Game Over");
            endScreen.SetActive(true);
            GameObject.Find("GameMusic").GetComponent<AudioSource>().Stop();
            GameObject.Find("LoseMusic").GetComponent<AudioSource>().Play();
        }

    }

}
