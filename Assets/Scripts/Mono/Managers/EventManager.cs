using System;
using VD.Datastructures;

public class EventManager : Singleton<EventManager>
{
    public event Action onPickup;

    public void PickUp()
    {
        onPickup?.Invoke();
    }
}
