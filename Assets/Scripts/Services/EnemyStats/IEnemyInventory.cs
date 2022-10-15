using System.Collections;
using UnityEngine;

public interface IEnemyInventory
{

    public GameObject AmmoPickup { get; }
    
    public GameObject Weapon { get; }

    public string WeaponName { get; }

}
