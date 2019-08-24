using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopTimeMech : MonoBehaviour
{
    GameObject[] ps;
   
    public static GameStates state;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
       if(Input.GetKey(KeyCode.Mouse1))
       {
              Debug.Log("Stop Time");
            state = GameStates.TimeStop;

             

             

        }
        else
        {
            state = GameStates.Normal;
            
            
            
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
