using UnityEngine;

public class MonoBehaviourService : MonoBehaviour
{
    [SerializeField] private GameRuntime gameRuntime;

    protected virtual void OnEnable()
    {
        gameRuntime.ServiceLocator.AddService(this);
    }

    protected virtual void OnDisable()
    {
        gameRuntime.ServiceLocator.RemoveService(this);
    }
}