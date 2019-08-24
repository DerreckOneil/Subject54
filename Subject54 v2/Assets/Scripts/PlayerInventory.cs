using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

   public static bool Knife;
    static bool Pistol;
    static bool AR;

    public GameObject knife;
    GameObject pistol;
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
    }
    
}
