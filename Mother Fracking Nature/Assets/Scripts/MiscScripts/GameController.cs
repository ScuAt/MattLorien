using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int enemyCount = 0;
    public int enemyMax = 1;
    public GameObject basicEnemy;
    List<GameObject> enemyList = new List<GameObject>();
    public int time = 120;
    private Text timeText;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(RoundControl());
        StartCoroutine(Timer());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Spawns enemies
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemies()
    {

        for ( ;enemyMax >= enemyCount ; enemyCount++ )
        {
            enemyList.Add(Instantiate(basicEnemy, new Vector3
                              (-26, Random.Range(-10, 10), 0), Quaternion.identity));
            enemyList.Add(Instantiate(basicEnemy, new Vector3
                              (26, Random.Range(-10, 10), 0), Quaternion.identity));
            yield return new WaitForSeconds(3f);
        }


        
        

    }

    IEnumerator RoundControl()
    {
        for (; ; )
        {

            if (enemyMax <= enemyCount)
            {
                enemyCount = 0;
                enemyMax++;
                // time = 120;
            }

            StartCoroutine(SpawnEnemies());
            

            yield return new WaitForSeconds(120f);

        }

    }


    public IEnumerator Timer()
    {
        //loop
        while (true)
        {
            if(time <= 0)
            {
                time = 120;
            }
            time--;
           // timeText.text = time.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

    }

}
