using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class TimeStateService : ScriptableObject, IStopTimeService
{
    [SerializeField] private GameRuntime gameRuntime;

    private TimeState timeState;

    public TimeState TimeState
    {
        get { return timeState; }
        set
        {
            Debug.Log("Changing the state!");
            TimeState previous = timeState;
            timeState = value;
            gameRuntime.ServiceLocator.InvokeAllListeners<ITimeStateListener>
                ((ITimeStateListener listener) => listener.OnTimeStateChanged(previous, timeState)); //Stick a pen in this...This notifies all the listeners.
                                                                                                     //So this gets called iff there's a scriptable object that implements ITimeStateListener

        }
    }

    
}

