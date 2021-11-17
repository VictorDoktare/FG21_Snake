using System;
using VD.Datastructures;

public class EventManager : Singleton<EventManager>
{
    public event Action onPickup;
    public void PickUp()
    {
        onPickup?.Invoke();
    }
    
    public Action onStartGame;
    public void StartGame()
    {
        onStartGame?.Invoke();
    }

    public Action onEndGame;
    public void EndGame()
    {
        onEndGame?.Invoke();
    }
}
