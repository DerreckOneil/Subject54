using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static int health;
    public static int score;
    public static int energy;
    public static float KIAs;
    GameObject Player;
    CharacterController CPlayer;

    Text healthText;
    public Text EnergyText;

    bool changedVal;
    bool changedVal2;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        CPlayer = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        //print(CPlayer);
        if(SceneManager.GetActiveScene().name == "StartGame")
        {
            health = 15;
        }
        else
            health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //CPlayer.Move(Vector3.forward*Time.deltaTime * 10);
        EnergyText.text = "Energy: " + energy;
        if(health <= 0)
        {
            print("I'm dead");
            if (SceneManager.GetActiveScene().name == "StartGame")
            {

                endgame();
                SceneManager.LoadScene("LoseScreen");
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(GameEnvironment.currentTime % 3 == 0 && Time.fixedTime != 0 && PlayerStats.energy <= 4 && StopTimeMech.state == GameStates.Normal)
        {
            
            if (changedVal == false)
            {
                print("Increase player energy!");
                PlayerStats.energy++;
                changedVal = true;
            }
            
        }
        else
        {
            changedVal = false;
        }

        if (GameEnvironment.currentTime % 3 == 0 && PlayerStats.energy >= 1 && StopTimeMech.state == GameStates.TimeStop)
        {
            print("Decrease player energy!");
            //PlayerStats.energy--;
        }

    }

    void endgame()
    {
        PlayerInventory.Pistol = false;
        EnemySpawner.wave = 0;
        score = 0;
        energy = 0;
        SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
