using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Service Locator")]
public class ServiceLocator : ScriptableObject, IServiceLocator
{

    //Place the junk logic here.
    [SerializeField] private List<Object> services = new List<Object>();

    public T GetService<T>() where T : class
    {
        Object something =  services.Find(x => x != null && x is T);
        return something as T;
    }
}
