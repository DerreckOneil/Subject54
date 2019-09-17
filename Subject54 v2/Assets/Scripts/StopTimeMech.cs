using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopTimeMech : MonoBehaviour
{
    GameObject[] ps;
    GameObject image;
   
    public static GameStates state;

    void Awake()
    {
        image = GameObject.FindWithTag("img");
        image.gameObject.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {

        state = GameStates.Normal;
    }
    

    // Update is called once per frame
    void Update()
    {

        switch(state)
        {
            case GameStates.TimeStop:
                stopTime();
                break;
            case GameStates.Normal:
                normalTime();
                break;
            case GameStates.TimeSlowed:
                slowTime();
                break;

        }
       if(Input.GetKeyDown(KeyCode.Mouse1))
       {
            if (state == GameStates.TimeStop)
            {

                state = GameStates.Normal;
                image.SetActive(false);
            }
            else
            {

                Debug.Log("Stop Time");
                state = GameStates.TimeStop;
                image.SetActive(true);
            }
            

             

        }
        
    }

    void stopTime()
    {
        Movement.timeFrame = 0; //Stops everything I assign movement (script) to within Unity by deception
        ps = GameObject.FindGameObjectsWithTag("ps");
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].GetComponent<ParticleSystem>().Pause(true);
        }
        if(PlayerStats.energy <=0)
        {
            print("change to normal time!");
            state = GameStates.Normal;
            image.SetActive(false);
            normalTime();
        }
    }
    void normalTime()
    {
        Movement.timeFrame = 1;

        if (ps != null)
        {
            for (int i = 0; i < ps.Length; i++)
            {
                ps[i].GetComponent<ParticleSystem>().Play(true);
            }
        }
    }
    void slowTime()
    {

    }
}
