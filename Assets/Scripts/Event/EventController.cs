

using System;

public class EventController 
{
    public Action baseEvent;

    public void InvokeEvent() => baseEvent?.Invoke();
    public void Subscribe(Action action) => baseEvent += action;
    public void Unsubscribe(Action action) => baseEvent -= action;
}
