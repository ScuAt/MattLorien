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

public class GameController : MonoBehaviour
{
    public int enemyCount = 0;
    public int enemyMax = 0;
    public GameObject basicEnemy;
    List<GameObject> enemyList = new List<GameObject>();
    private int time = 30;
    private Text timeText;
    private int rndNmbr = 0;
    private Text rndText;
    public bool roundsStarted = false;


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

        timeText = GameObject.Find("timeText").GetComponent<Text>();
        timeText.text = time.ToString();
        rndText = GameObject.Find("rndText").GetComponent<Text>();
        rndText.text = rndNmbr.ToString();
        // StartCoroutine(RoundControl());
        StartCoroutine(Timer());
        if(time <= 0)
        {
            StartCoroutine(RoundControl());
        }

    }

    /// <summary>
    /// checks if the first round should start and checks if the game needs to end
    /// </summary>
    void Update()
    {
        if (time <= 0 && roundsStarted == false)
        {
            StartCoroutine(RoundControl());
        }
        //debugging purposes
        /*  if (Input.GetKey(KeyCode.Escape))
          {
              Application.Quit();
          }
          else if (Input.GetKey(KeyCode.R))
          {

              UnityEngine.SceneManagement.SceneManager.LoadScene(1);
          }
        */

        if(attackerHealth <= 0 && defenderHealth <= 0)
        {
            Debug.Log("Game Over");
            endScreen.SetActive(true);
        }
        if (towerHealth <= 0)
        {
            Debug.Log("Game Over");
            endScreen.SetActive(true);
        }

    }

    /// <summary>
    /// Spawns 4 enemies in each direction
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemies()
    {

        for ( ;enemyMax > enemyCount ; enemyCount++ )
        {
            enemyList.Add(Instantiate(basicEnemy, new Vector3
                              (-26, Random.Range(-10, 10), 0), Quaternion.identity));
            enemyList.Add(Instantiate(basicEnemy, new Vector3
                              (26, Random.Range(-10, 10), 0), Quaternion.identity));
            enemyList.Add(Instantiate(basicEnemy, new Vector3
                              (Random.Range(-10, 10), 14, 0), Quaternion.identity));
            enemyList.Add(Instantiate(basicEnemy, new Vector3
                              (Random.Range(-10, 10), -18,  0), Quaternion.identity));
            yield return new WaitForSeconds(3f);
        }


        
        

    }
    /// <summary>
    /// adds to the round number every time the timer hits zero, increases the enemies that spawn each round
    /// displays current round number
    /// </summary>
    /// <returns></returns>
    IEnumerator RoundControl()
    {
        roundsStarted = true;
        
        for (; ; )
        {
            rndNmbr++;
            rndText.text = rndNmbr.ToString();
            if (enemyMax <= enemyCount)
            {
                enemyCount = 0;
                enemyMax++;
                // time = 30;
            }

            StartCoroutine(SpawnEnemies());
            

            yield return new WaitForSeconds(30f);

        }

    }

    /// <summary>
    /// counts from 30 to zero and resets
    /// regenerates health for the attacker and defender every second
    /// </summary>
    /// <returns></returns>
    public IEnumerator Timer()
    {
        //loop
        while (true)
        {
            if(time <= 0)
            {
                time = 30;
            }
            time--;
            //timeText = GameObject.Find("timeText").GetComponent<Text>();
            timeText.text = time.ToString();
            if(attackerHealth < 100 && attackerHealth > 0)
            {
                attackerHealth += 2;
            }
            if(defenderHealth < 250 && defenderHealth > 0)
            {
                defenderHealth += 4;
            }
            
            yield return new WaitForSecondsRealtime(1f);
        }

    }

}
