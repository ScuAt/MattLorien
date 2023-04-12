using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Weapon
{
    public Saw()
    {
        AttackSpeed = 1;
        Damage = 14;
        AbilityDamage = 9;
        CoolDown = 2;
        DamageType = "Slashing";
        SpecialAbility = "Dash";
        WeaponName = "Hand Saw";

    }
}
