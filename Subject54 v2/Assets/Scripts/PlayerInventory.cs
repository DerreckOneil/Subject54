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
    GameObject ar;

    void Start()
    {
        

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
        }

    }
    
}
