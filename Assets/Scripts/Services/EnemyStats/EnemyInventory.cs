using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyInventory : ScriptableObject, IEnemyInventory
{
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private GameObject ammoMag;

    public GameObject AmmoPickup => ammoMag;

    public GameObject Weapon => gun;

    public string WeaponName { get => gun.name; }
}
