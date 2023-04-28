/*****************************************************************************
// File Name :         Weapon.cs
// Author :            Matthew McCoy
// Creation Date :     Apirl 18th, 2023
//
// Brief Description : stores data for all child weapon classes 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon 
{
    [SerializeField] private string weaponName;
    [SerializeField] private string damageType;
    [SerializeField] private string specialAbility;
    [SerializeField] private int damage;
    [SerializeField] private int abilityDamage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackReady;
    [SerializeField] private float coolDown;
    [SerializeField] private float abilityReady;


    public string WeaponName { get => weaponName; set => weaponName = value; }
    public string DamageType { get => damageType; set => damageType = value; }
    public string SpecialAbility { get => specialAbility; set => specialAbility = value; }
    public int Damage { get => damage; set => damage = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float CoolDown { get => coolDown; set => coolDown = value; }
    public float AttackReady { get => attackReady; set => attackReady = value; }
    public float AbilityReady { get => abilityReady; set => abilityReady = value; }
    public int AbilityDamage { get => abilityDamage; set => abilityDamage = value; }

    /// <summary>
    /// constructor for weapon
    /// </summary>
    public Weapon()
    {

    }


   

}
