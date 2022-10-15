using System.Collections;
using UnityEngine;

public interface IWeaponStats
{
    public GameObject Weapon { get; }
    public string WeaponName { get; }
    public int WeaponDmg { get; }

}
