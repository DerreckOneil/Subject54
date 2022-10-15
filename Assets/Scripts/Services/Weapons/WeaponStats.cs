using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponStats : ScriptableObject, IWeaponStats
{
    [SerializeField] GameObject weapon;
    [SerializeField] string weaponName; //To ensure the name is set by myself. 
    [SerializeField] int weaponDmg;

    public GameObject Weapon => weapon;

    public string WeaponName => weaponName;

    public int WeaponDmg => weaponDmg;


    
}
