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


    public int attackerHealth = 100;
    public int defenderHealth = 250;
    public int towerHealth = 500;


    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
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
    }

    /// <summary>
    /// Spawns enemies
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
            if(attackerHealth < 100)
            {
                attackerHealth ++;
            }
            if(defenderHealth < 250)
            {
                defenderHealth ++;
            }
            yield return new WaitForSecondsRealtime(1f);
        }

    }

}
