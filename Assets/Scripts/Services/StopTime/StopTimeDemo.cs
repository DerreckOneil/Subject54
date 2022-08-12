using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class StopTimeDemo : ScriptableObject, IStopTimeService
{

    /*
    [SerializeField]
    private GameRuntime gameRuntime;


    [SerializeField] private GameObject[] ps;
    [SerializeField] private GameObject image;

    [SerializeField] private Slider Meter;
    [SerializeField] private Text MeterText;

    float meterDecr = .1f;

    [SerializeField] private float Imgmin;
    [SerializeField] private float Imgmax;

    //private GameStates state;

    [SerializeField] AudioSource source;
    float sourceOrigPitch;

    //public Action<>
    */
    [SerializeField] private GameRuntime gameRuntime;


    private static VignetteTimeEffect effectRef;

   
    public void ChangeState (TimeState state)
    {
        switch (state)
        {
            case TimeState.TimeStopped:
                //stopTime();
                //decrMeter();
                //TriggerAnim();
                //effectRef.BeginSTAnim();
                gameRuntime.ServiceLocator.GetService<StopTimeService>().TimeState = TimeState.TimeStopped;
                break;
            case TimeState.Normal:
                //normalTime();
                gameRuntime.ServiceLocator.GetService<StopTimeService>().TimeState = TimeState.Normal;
                break;
            case TimeState.TimeSlowed:

                //slowTime();

                gameRuntime.ServiceLocator.GetService<StopTimeService>().TimeState = TimeState.Normal;

                break;
        }
    }

}

