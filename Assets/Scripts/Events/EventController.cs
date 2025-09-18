

using System;

public class EventController 
{
    public Action baseEvent;

    public void InvokeEvent() => baseEvent?.Invoke();
    public void Subscribe(Action action) => baseEvent += action;
    public void Unsubscribe(Action action) => baseEvent -= action;
}


public class EventController<T>
{
    public Action<T> baseEvent;

    public void InvokeEvent(T param) => baseEvent?.Invoke(param);
    public void Subscribe(Action<T> action) => baseEvent += action;
    public void Unsubscribe(Action<T> action) => baseEvent -= action;
}
