using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BottleAbilityBehaviour : MonoBehaviour
{

    public GameObject target;

    public float projectileSpeed;
    
    private Quaternion rotation;
    

    


    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.Find("BottleTarget");
        



    }

    // Update is called once per frame
    void Update()
    {


        // rb2D.velocity = new Vector2(aB.velocityX, aB.velocityY);
        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, projectileSpeed * Time.deltaTime);
        //  Debug.Log("Aim x = " + aB.velocityX + "Aim y = " + aB.velocityY);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Enemy" || collision.tag == "Barrier")
            {
            //destroys the object you are colliding with for this instance the assigning circle
            Destroy(this.gameObject);
            }
    }



}
