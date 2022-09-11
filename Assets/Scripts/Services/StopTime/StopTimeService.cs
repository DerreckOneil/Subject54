using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class StopTimeService : ScriptableObject, IStopTimeService
{
    [SerializeField] private GameRuntime gameRuntime;

    private TimeState timeState;

    public TimeState TimeState
    {
        get { return timeState; }
        set
        {
            TimeState previous = timeState;
            timeState = value;
            gameRuntime.ServiceLocator.InvokeAllListeners<ITimeStateListener>
                ((ITimeStateListener listener) => listener.OnTimeStateChanged(previous, timeState));

        }
    }

    
}

