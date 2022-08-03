using System;

public interface IServiceLocator
{
    bool AddService<T>(T service) where T : class;
    bool RemoveService<T>(T service) where T : class; 
    T GetService<T>() where T : class;
    void InvokeAllListeners<L>(Action<L> callback) where L : class;
}