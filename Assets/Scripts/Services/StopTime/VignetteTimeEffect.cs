using UnityEngine; 
public class VignetteTimeEffect : MonoBehaviourService, ITimeStateListener
{
    [SerializeField] private GameRuntime gameRuntime;

    public void OnTimeStateChanged(IStopTimeService timeService)
    {
        Debug.Log(nameof(TimeState) + " changed to " + timeService.TimeState);
    }
    public void BeginSTAnim()
    {
        //Todo: Do this in the editor and use a listener
        //listener
        
    }
   
}