using System;
using VD.Datastructures;

public class EventManager : Singleton<EventManager>
{
    public event Action ONPickup;
    public void PickUp()
    {
        ONPickup?.Invoke();
    }
    
    public Action ONStartGame;
    public void StartGame()
    {
        ONStartGame?.Invoke();
    }

    public Action ONEndGame;
    public void EndGame()
    {
        ONEndGame?.Invoke();
    }
}
