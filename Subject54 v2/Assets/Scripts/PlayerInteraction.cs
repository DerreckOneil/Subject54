using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private RaycastHit rayHit;
    public LayerMask layerMask;
    public float rayLength;
    Text hitText;
    public static int hits;

    // Start is called before the first frame update
    void Start()
    {
        hitText = Text.FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        hitText.text = "Hits: " + hits;
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, rayLength, layerMask))
        {
            if(rayHit.collider.gameObject.tag == "Knife")
            {
                print("I'm looking at my knife");
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    print("Knife Aquired");
                    PlayerInventory.Knife = true;
                }
            }
        }

        }
}
