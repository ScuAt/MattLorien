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

    private void Start()
    {
        health = 500;
    }

    public void getHealth(float healthBack)
    {
        health = health * healthBack;
    }

    public void oirlRigDamageTaken(float damageTaken)
    {
        health = -damageTaken;
    }
}
