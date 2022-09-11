using UnityEngine;

public interface IStopTimeService
{
    TimeState TimeState { get; set; }

    //TODO: This is for a "View" system
    //For example, a VignetteTimeEffect
    //void BeginStopTimeAnim();
    //void EndStopTimeAnim();
}



