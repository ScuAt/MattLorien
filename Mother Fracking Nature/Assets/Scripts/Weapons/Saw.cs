/*****************************************************************************
// File Name :         Saw.cs
// Author :            Matthew McCoy
// Creation Date :     Apirl 18th, 2023
//
// Brief Description : Inherits from weapon and stores all the associated data for the saw weapon and abilities
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Weapon
{
    public Saw()
    {
        AttackSpeed = 1;
        Damage = 15;
        AbilityDamage = 12;
        CoolDown = 2;
        DamageType = "Slashing";
        SpecialAbility = "Dash";
        WeaponName = "Hand Saw";

    }
}
