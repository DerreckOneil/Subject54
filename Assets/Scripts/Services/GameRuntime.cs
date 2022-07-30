using UnityEngine;

[CreateAssetMenu]
public class GameRuntime : ScriptableObject
{
    [SerializeField] private ServiceLocator serviceLocator;

    public IServiceLocator ServiceLocator => serviceLocator; //If anything changes, we're only using the interface
}