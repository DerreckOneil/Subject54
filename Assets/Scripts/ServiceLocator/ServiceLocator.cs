using System;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

[CreateAssetMenu(menuName = "Service Locator")]
public class ServiceLocator : ScriptableObject, IServiceLocator
{
    //Place the junk logic here.
    [SerializeField] private List<Object> services = new List<Object>();

    private IEnumerable<Object> GetValidServices()
    {
        foreach (Object service in services)
            if (service != null)
                yield return service;
    }

    public bool AddService<T>(T service) where T : class
    {
        if (!(service is Object unityService))
            throw new ArgumentException("Only " + typeof(Object).FullName + " services are supported currently!", nameof(service));

        foreach (Object other in GetValidServices())
            if (other == unityService)
                return false; //The service is already in the list -- return false and DON'T re-add a duplicate reference to it!

        services.Add(unityService);
        return true;
    }

    public bool RemoveService<T>(T service) where T : class
    {
        if (!(service is Object unityService))
            throw new ArgumentException("Only " + typeof(Object).FullName + " services are supported currently!", nameof(service));

        int index = services.IndexOf(unityService);
        if (index < 0)
            return false;
        services.RemoveAt(index);
        return true;
    }

    public T GetService<T>() where T : class
    {
        Object something = services.Find(x => x != null && x is T);
        return something as T;
    }

    public void InvokeAllListeners<L>(Action<L> doSomething) where L : class
    {
        foreach (Object service in GetValidServices())
            if (service is L listener)
                doSomething(listener);
 
    }
    public void DoSomething()
    {
        DoSomething2(() => Debug.Log("faaaak"));
        DoSomething2(DoSomething);
    }
    public void DoSomething2(Action callback)
    {
        callback();
    }
    
    
}
