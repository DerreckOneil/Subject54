using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class StopTimeMechanic : MonoBehaviour, ITimeStateListener
{
    //TODO: Make the enemies set their ps to the UIGameData list.


    [SerializeField] private GameRuntime gameRuntime;

    [SerializeField] private UIGameData gameDataRef;

    [SerializeField] private VignetteTimeEffect effectRef;

    private Text MeterText;

    private GameObject[] ps;

    private GameObject image;

    private void Awake()
    {
        ps = GameObject.FindGameObjectsWithTag("ps");
        
    }

    public void OnTimeStateChanged(TimeState previous, TimeState current)
    {
        switch (current)
        {
            case TimeState.Normal:
                NormalTime();
                break;
            case TimeState.TimeStopped:
                StopTime();
                break;
            default:
                Debug.LogError("Unexpected state " + current);
                break;
        }

    }

    private void Update()
    {
        //What do I wanna check every frame


        if (effectRef.Meter.value == effectRef.Meter.maxValue)
        {
            //Meter.colors.normalColor = Color.red;
            MeterText.text = "Max! (Right click to Stop Time!)";
        }
        else
        {
            MeterText.text = "";
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && effectRef.Meter.value == effectRef.Meter.maxValue)
        {

            Debug.Log("Stop Time");
            effectRef.BeginSTAnim();
            //StartCoroutine(stopTimeTransition());


        }

    }
    void NormalTime()
    {
        Movement.timeFrame = 1;
        //Meter.value = PlayerStats.EnemyKillPoints;
        if (ps != null)
        {
            for (int i = 0; i < ps.Length; i++)
            {
                ps[i].GetComponent<ParticleSystem>().Play(true);
            }
        }
    }

    void StopTime()
    {
        IStopTimeService timeSystem = gameRuntime.ServiceLocator.GetService<IStopTimeService>();

        Movement.timeFrame = 0; //Stops everything I assign movement (script) to within Unity by deception

        //This HAS to be added via Enemies...please FFS.
        ps = GameObject.FindGameObjectsWithTag("ps");
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].GetComponent<ParticleSystem>().Pause(true);
        }
        /*Please revisit...
        if (PlayerStats.energy <= 0)
        {
            Debug.Log("change to normal time!");
            OnTimeStateChanged(TimeState.TimeStopped, TimeState.Normal);
            image.SetActive(false);
            NormalTime();
        }
        */
    }

}

