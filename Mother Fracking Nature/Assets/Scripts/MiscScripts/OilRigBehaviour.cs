/*****************************************************************************
// File Name :         OilRigBehaviour.cs
// Author :            Lorien Nergard
// Creation Date :     April 11th, 2023
//
// Brief Description : Controls the health of the oil rig
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilRigBehaviour : MonoBehaviour
{
    public int health = 500;

    /// <summary>
    /// Sets the health for the oil rig
    /// </summary>
    public void Start()
    {
        //health = 500;
    }


    /// <summary>
    /// Gives health back to the oil rig
    /// </summary>
    /// <param name="healthBack"></param>
    public void getHealth(int healthBack)
    {
        health = health + healthBack;
    }

    /// <summary>
    /// Takes health from the oil rig
    /// </summary>
    /// <param name="damageTaken"></param>
    public void oirlRigDamageTaken(int damageTaken)
    {
        health = health - damageTaken;
        Debug.Log(health);
    }
}
