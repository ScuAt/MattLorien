using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//generates our file for weapon data to be used in unity
[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon Data")]

public class WeaponData : ScriptableObject
{

    [SerializeField] private string weaponName;
    [SerializeField] private string damageType;
    [SerializeField] private string specialAbility;
    [SerializeField] private int damage;
    [SerializeField] private int attackSpeed;
    [SerializeField] private int coolDown;


    public string WeaponName { get => weaponName; set => weaponName = value; }
    public string DamageType { get => damageType; set => damageType = value; }
    public string SpecialAbility { get => specialAbility; set => specialAbility = value; }
    public int Damage { get => damage; set => damage = value; }
    public int AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public int CoolDown { get => coolDown; set => coolDown = value; }

    public void Attack()
    {
        Debug.Log(WeaponName + " deals " + Damage + " " + DamageType + " damage!");
    }

    public void Ability()
    {
        Debug.Log(SpecialAbility + " activated!");
    }


}
