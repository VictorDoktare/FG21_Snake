using Unity.Mathematics;
using UnityEngine;
using VD.Datastructures;
using Random = UnityEngine.Random;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private GameObject _pickUp;
    [SerializeField] private Player _player;
    
    private Vector3 _randomPos;
    
    #region Unity Event Functions
    void Start()
    {
        EventManager.Instance.onPickup += SpawnPickup;
        
        SpawnPickup();
    }
    
    #endregion

    public void SpawnPickup()
    {
        var node = _player.LlPlayer.Head;

        _randomPos = RandomizePosition();

        //Checks if object is spawning on any of the snake parts
        if (node.Next != null)
        {
            for (int i = 0; i < _player.LlPlayer.Count; i++)
            {
                if (_randomPos != node.Value.transform.position)
                {
                    if (node == _player.LlPlayer.Tail)
                    {
                        Instantiate(_pickUp, _randomPos, quaternion.identity);
                    }
                    else
                    {
                        node = node.Next;
                    }
                }
                else
                {
                    SpawnPickup();
                }
            }
        }
        //Checks only for the head in case snake has no body parts
        else
        {
            if (_randomPos != node.Value.transform.position)
            {
                Instantiate(_pickUp, _randomPos, quaternion.identity);
            }
            else
            {
                SpawnPickup();
            }
        }
    }

    //Get a random Vector based on grid size
    private Vector3 RandomizePosition()
    {
        var xRand = Random.Range(0, GridManager.Instance.Grid.GetLength(0));
        var zRand = Random.Range(0, GridManager.Instance.Grid.GetLength(1));

        return GridManager.Instance.Grid[xRand, zRand];
    }
}
