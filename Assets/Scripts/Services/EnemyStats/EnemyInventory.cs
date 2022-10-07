using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyInventory : ScriptableObject
{
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private GameObject ammoMag;

    public GameObject Gun => gun;
    public GameObject AmmoMag => ammoMag;

}
