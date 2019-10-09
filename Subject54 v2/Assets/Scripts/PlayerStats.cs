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

    Text healthText;
    public Text EnergyText;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");

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
        EnergyText.text = "Energy: " + energy;
        if(health <= 0)
        {
            print("I'm dead");
            if (SceneManager.GetActiveScene().name == "StartGame")
            {
                SceneManager.LoadScene("LoseScreen");
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(Time.fixedTime % 1 == 0 && Time.fixedTime != 0 && PlayerStats.energy <= 4 && StopTimeMech.state == GameStates.Normal)
        {
            print("Increase player energy!");
            PlayerStats.energy++;
        }
        if (Time.fixedTime % 1 ==0 && PlayerStats.energy >= 1 && StopTimeMech.state == GameStates.TimeStop)
        {
            print("Decrease player energy!");
            //PlayerStats.energy--;
        }

        }
}
