using UnityEngine;

public interface IStopTimeService
{
    TimeState TimeState { get; }

    //TODO: This is for a "View" system
    //For example, a VignetteTimeEffect
    //void BeginStopTimeAnim();
    //void EndStopTimeAnim();
}

public interface ITimeStateListener {
    void OnTimeStateChanged(IStopTimeService timeService);
}

public class MonoBehaviourService : MonoBehaviour {
    [SerializeField] private GameRuntime gameRuntime;

    protected virtual void OnEnable() {
        gameRuntime.ServiceLocator.AddService(this);
    }

    protected virtual void OnDisable() {
        gameRuntime.ServiceLocator.RemoveService(this);
    }
}

public class VignetteTimeEffect : MonoBehaviourService, ITimeStateListener {
    [SerializeField] private GameRuntime gameRuntime;

    public void OnTimeStateChanged(IStopTimeService timeService) {
        Debug.Log(nameof(TimeState) + " changed to " + timeService.TimeState);
    }
}
