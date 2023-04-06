using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//generates our file for weapon data to be used in unity
[CreateAssetMenu(fileName = "TrapData", menuName = "Trap Data")]

public class TrapData : ScriptableObject
{
    
    [SerializeField] private string trapName;
    [SerializeField] private string damageType;
    [SerializeField] private int damage;
    [SerializeField] private int coolDown;
    [SerializeField] private int trapHealth;
    //etc. 


    public void PlaceTrap()
    {
        Debug.Log(trapName + " deals " + damage + " " + damageType + " with "
                                         + trapHealth + " health remaining");

        Debug.Log(trapName + " ready in " + coolDown + " seconds");
    }
}
