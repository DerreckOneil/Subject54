using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    private RaycastHit rayHit;
    public LayerMask layerMask;
    public float rayLength;

    
    public Text hitText;
    public Text scoreText;
    public Text healthText;
    public static int hits;

    // Start is called before the first frame update
    void Start()
    {
        //hitText = Text.FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if (hitText != null)
            hitText.text = "Hits: " + hits;
        if (scoreText != null)
            scoreText.text = "Score: " + PlayerStats.score;
        if (healthText != null)
            healthText.text = "Health: " + PlayerStats.health;


        if (Physics.Raycast(transform.position, transform.forward, out rayHit, rayLength, layerMask))
        {
            if (rayHit.collider.gameObject.tag == "Knife")
            {
                print("I'm looking at my knife");
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    print("Knife Aquired");
                    PlayerInventory.Knife = true;
                    
                }
            }
            if(rayHit.collider.gameObject.tag == "Pistol")
            {
                print("I'm looking at my Pistol");
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    print("Pistol Aquired");
                    PlayerInventory.Pistol = true;

                }
            }
        }

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print("Player hit!" + hit.gameObject.name);

        if(hit.gameObject.tag == "Goal")
        {
            print("Reached Goal!!!");
            SceneManager.LoadScene("ShootingRange");
        }
        if(hit.gameObject.tag == "Enemy")
        {
            print("I got hit by an enemy!");
        }
    }
}
