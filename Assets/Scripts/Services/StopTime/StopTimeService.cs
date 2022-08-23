using UnityEngine;
using UnityEngine.UI;

public class StopTimeService : ScriptableObject, IStopTimeService
{
    [SerializeField] private GameRuntime gameRuntime;

    [SerializeField] private GameObject image;

    [SerializeField] private GameObject[] ps;

    [SerializeField] private Slider meter;


    private TimeState timeState;

    public TimeState TimeState
    {
        get { return timeState; }
        set
        {
            timeState = value;
            gameRuntime.ServiceLocator.InvokeAllListeners<ITimeStateListener>(
                (ITimeStateListener listener) => listener.OnTimeStateChanged(TimeState.Normal, value));
        }
    }
}
