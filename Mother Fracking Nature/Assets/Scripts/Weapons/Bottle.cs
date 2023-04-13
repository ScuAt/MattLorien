using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : Weapon
{


    public Bottle()
    {
        AttackSpeed = .09f;
        Damage = 6;
        AbilityDamage = 15;
        CoolDown = 2f;
        DamageType = "Piercing";
        SpecialAbility = "Throw";
        WeaponName = "Broken Bottle";

    }

   

}
