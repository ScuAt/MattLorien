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
                              (Random.Range(-5, 5), 0, 0), Quaternion.identity));
            yield return new WaitForSeconds(3f);
        }


        
        

    }

    IEnumerator RoundControl()
    {

        if (enemyMax <= enemyCount)
        {
            enemyCount = 0;
            enemyMax++;
            time = 120;
        }

        StartCoroutine(SpawnEnemies());
        StartCoroutine(Timer());

        yield return new WaitForSeconds(120f);

    }


    public IEnumerator Timer()
    {
        //loop
        while (true)
        {
            
            time--;
            timeText.text = time.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }
    }

}
