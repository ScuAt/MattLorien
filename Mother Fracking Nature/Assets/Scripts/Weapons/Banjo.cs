using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banjo : Weapon
{
    public Banjo()
    {
        AttackSpeed = .4f;
        Damage = 4;
        CoolDown = 12;
        DamageType = "Bludgeoning";
        SpecialAbility = "Stun";
        WeaponName = "Banjo";

    }
}
