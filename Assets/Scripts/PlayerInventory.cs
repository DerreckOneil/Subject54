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
        else
        {
            print("Pistol is false, I should'nt have a gun");
            pistol.SetActive(false);
        }
        if (PlayerShoot.empty && Pistol)
        {
            pistol.SetActive(false);
            Pistol = false;
            NoGunHands.SetActive(true);
        }
        /* Why is this in here? What is it's purpose?
        if(!PlayerShoot.empty && !Pistol && EnemySpawner.wave != 1)
        {
            
            print("I set the gun to true");
            Pistol = true;
            pistol.SetActive(true);
            NoGunHands.SetActive(false);
        }
        */
    }
    
}
