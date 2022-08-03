using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStopTimeService
{
    //public void ServiceInit(); Not a good idea I believe...need to use monobehav functions to initialize anything...next!

    public GameStates GetCurrentState();

    public void BeginStopTimeAnim();

    public void EndStopTimeAnim();

    public void OnStateChangeListener();

    
}
