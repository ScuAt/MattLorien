using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleAbilityBehaviour : MonoBehaviour
{

   
    

    public float projectileSpeed = 4;
    private Rigidbody2D rb2D;


    // Start is called before the first frame update
    void Start()
    {
        PlayerBehaviour pB = FindObjectOfType<PlayerBehaviour>();

        rb2D = GetComponent<Rigidbody2D>();
       // rb2D.velocity = pB.old_rotation * projectileSpeed * Time.deltaTime;

        Vector2 projectileVelocity = new Vector2(pB.aim.x, pB.aim.y) * projectileSpeed * Time.deltaTime;
        transform.Translate(projectileVelocity, Space.Self); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
