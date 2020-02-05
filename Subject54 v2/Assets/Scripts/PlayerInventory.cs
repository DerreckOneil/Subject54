using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

   public static bool Knife;
    public static bool Pistol;
    static bool AR;

    public GameObject knife;
    public GameObject pistol;
    public GameObject NoGunHands;
    GameObject ar;

    void Start()
    {
        NoGunHands = GameObject.FindWithTag("hands");

    }

    void Update()
    {
        if(Knife)
        {
            knife.SetActive(true);
        }

        if (Pistol)
        {
            pistol.SetActive(true);
            NoGunHands.SetActive(false);
        }
        if (PlayerShoot.empty && Pistol)
        {
            pistol.SetActive(false);
            Pistol = false;
            NoGunHands.SetActive(true);
        }
        if(!PlayerShoot.empty && !Pistol && EnemySpawner.wave != 1)
        {
            Pistol = true;
            pistol.SetActive(true);
            NoGunHands.SetActive(false);
        }

    }
    
}
