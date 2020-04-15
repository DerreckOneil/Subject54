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

    [SerializeField]
    private Text hitText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text VendingText;

    [SerializeField]
    private CameraShake cameraShakeScript;

    [SerializeField] private AudioSource soundPlayer;
    [SerializeField] private AudioClip damageSound;
    

    [Range(0.0f, 1.0f)]
    public float SetVolume;


    public static int hits;
    public static bool playerHit;
    int healthPrice = 1000;

    public Animator backToIdle;
    public Animator GunPickUp;

    
    // Start is called before the first frame update
    void Start()
    {
        //hitText = Text.FindObjectOfType<Text>();
        cameraShakeScript.GetComponent<CameraShake>().enabled = false;
        VendingText.text = "";
        print("just started");
        ResetAllStatics();
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
            if (rayHit.collider.gameObject.tag == "Door")
            {
                print("I'm looking at the door");
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    rayHit.collider.gameObject.transform.parent.gameObject.transform.Rotate(0, -270.0f, 0);
                    SceneManager.LoadScene("GameLore");
                }

            }
            if (rayHit.collider.gameObject.tag == "Exit")
            {
                SceneManager.LoadScene("StartGame");
                return;
            }
            if (rayHit.collider.gameObject.tag == "Pistol")
            {
                print("I'm looking at my Pistol");
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    print("Pistol Aquired");
                    
                    GunPickUp.SetTrigger("GunPickUp");
                    StartCoroutine(gunPickUp());

                }
            }
            if(rayHit.collider.gameObject.tag == "HealthMachine")
            {
                VendingText.text = "Left Click To Buy 10 Health For: " + healthPrice + " Score.";
                if(Input.GetKeyDown(KeyCode.Mouse0) && (PlayerStats.score >= healthPrice))
                {
                    PlayerStats.health += 10;
                    PlayerStats.score -= healthPrice;
                    healthPrice += 1000;
                }
                
            }
            


            }
        else
        {
            VendingText.text = "";
        }

        if(playerHit)
        {
            StartCoroutine(PlayerHitWait());
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

    

    IEnumerator gunPickUp()
    {
        //yield return new WaitForSeconds(.1f);
        
        print("Picked Up Pistol");
        PlayerInventory.Pistol = true;
        yield return new WaitForSeconds(2);
        print("Go Back to Idle");
        yield return new WaitForSeconds(1);
        backToIdle.SetTrigger("BackToIdle");
        

    }
    IEnumerator PlayerHitWait()
    {
        print("Turning the script on.");
        cameraShakeScript.enabled = true;
        soundPlayer.PlayOneShot(damageSound, SetVolume);
        yield return new WaitForSeconds(.5f);
        print("Turning the script off.");
        cameraShakeScript.enabled = false;


        playerHit = false;
    }
    void ResetAllStatics()
    {
        PlayerInventory.Pistol = false;
        EnemySpawner.wave = 0;
       
    }
}
