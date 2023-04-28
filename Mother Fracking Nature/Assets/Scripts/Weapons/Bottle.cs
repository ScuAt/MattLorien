/*****************************************************************************
// File Name :         Bottle.cs
// Author :            Matthew McCoy
// Creation Date :     Apirl 18th, 2023
//
// Brief Description : inherits from weapon and stores all attributes for the bottle weapon
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : Weapon
{


    public Bottle()
    {
        AttackSpeed = .09f;
        Damage = 4;
        AbilityDamage = 15;
        CoolDown = 2f;
        DamageType = "Piercing";
        SpecialAbility = "Throw";
        WeaponName = "Broken Bottle";

    }

   

}
