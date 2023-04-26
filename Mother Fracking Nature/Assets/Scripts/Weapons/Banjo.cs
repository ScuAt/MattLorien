using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banjo : Weapon
{
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
