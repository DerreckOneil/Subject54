using UnityEngine;

public class StopTimeService : ScriptableObject, IStopTimeService
{
    [SerializeField] private GameRuntime gameRuntime;

    private TimeState timeState;

    public TimeState TimeState {
        get { return timeState; }
        set {
            timeState = value;
            gameRuntime.ServiceLocator.InvokeAllListeners<ITimeStateListener>(
                (ITimeStateListener listener) => listener.OnTimeStateChanged(this));
        }
    }
}
