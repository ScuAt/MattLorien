/*****************************************************************************
// File Name :         Banjo.cs
// Author :            Matthew McCoy
// Creation Date :     Apirl 18th, 2023
//
// Brief Description : Stores data for the banjo weapon. Inherits from Weapon.cs
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banjo : Weapon
{
    //constructor for banjo stores the attack and ability data
    public Banjo()
    {
        AttackSpeed = .4f;
        Damage = 3;
        AbilityDamage = 0;
        CoolDown = 4;
        DamageType = "Bludgeoning";
        SpecialAbility = "Stun";
        WeaponName = "Banjo";

    }
}
