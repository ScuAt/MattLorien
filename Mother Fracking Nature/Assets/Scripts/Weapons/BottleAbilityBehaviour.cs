using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BottleAbilityBehaviour : MonoBehaviour
{

  

    public float projectileSpeed = 24;
    private Rigidbody2D rb2D;
    private Quaternion rotation;
    private PlayerBehaviour pB;

    


    // Start is called before the first frame update
    void Start()
    {
       

        pB = FindObjectOfType<PlayerBehaviour>();

        rb2D = GetComponent<Rigidbody2D>();
        // Debug.Log("Aim x = " + aim.x + "Aim y = " + aim.y);
        //rb2D.velocity = new Vector2(aim.x * projectileSpeed, aim.y * projectileSpeed); //* projectileSpeed; //* Time.deltaTime;

        //Vector2 projectileVelocity = new Vector2(pB.aim.x, pB.aim.y) * projectileSpeed * Time.deltaTime;
        //transform.Translate(projectileVelocity, Space.Self);
        rotation = pB.transform.rotation;
        rb2D.inertia = 4;
    }

    // Update is called once per frame
    void Update()
    {
        var adj = rotation.z;
        //PlayerBehaviour pB = FindObjectOfType<PlayerBehaviour>();
        //var rotation = pB.transform.rotation;
        if (rotation.z > 180)
        {
            adj = (adj - 180) * -1;
        }
        var x_part = Mathf.Cos(adj);
        var y_part = Mathf.Sin(adj);

        rb2D.velocity = new Vector2(x_part, y_part);

        Debug.Log("Aim x = " + x_part + "Aim y = " + y_part);
        
       
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
