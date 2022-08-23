using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class StopTimeDemo : ScriptableObject, IStopTimeService
{

    [SerializeField] private GameRuntime gameRuntime;

    private static VignetteTimeEffect effectRef;

    public TimeState TimeState => TimeState;

    public void ChangeState(TimeState state)
    {
        StopTimeService stopTimeService = gameRuntime.ServiceLocator.GetService<StopTimeService>();
        switch (state)
        {
            case TimeState.TimeStopped:
                //effectRef.BeginSTAnim();
                gameRuntime.ServiceLocator.GetService<StopTimeService>().TimeState = TimeState.TimeStopped;
                Debug.Log("State change to TimeStopped");
                break;
            case TimeState.Normal:
                gameRuntime.ServiceLocator.GetService<StopTimeService>().TimeState = TimeState.Normal;
                Debug.Log("State change to TimeNormal");
                break;
            case TimeState.TimeSlowed:
                gameRuntime.ServiceLocator.GetService<StopTimeService>().TimeState = TimeState.TimeSlowed;
                Debug.Log("State change to TimeSlowed");
                break;
        }
    }

}

