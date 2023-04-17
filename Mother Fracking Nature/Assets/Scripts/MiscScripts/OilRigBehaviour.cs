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
    public float health;

    /// <summary>
    /// Sets the health for the oil rig
    /// </summary>
    private void Start()
    {
        health = 500;
    }


    /// <summary>
    /// Gives health back to the oil rig
    /// </summary>
    /// <param name="healthBack"></param>
    public void getHealth(float healthBack)
    {
        health = health + healthBack;
    }

    /// <summary>
    /// Takes health from the oil rig
    /// </summary>
    /// <param name="damageTaken"></param>
    public void oirlRigDamageTaken(float damageTaken)
    {
        health = health - damageTaken;
    }
}
