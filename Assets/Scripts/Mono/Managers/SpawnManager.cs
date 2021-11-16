using UnityEngine;
using VD.Datastructures;
using Random = UnityEngine.Random;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private GameObject _pickup;
    [SerializeField] private Player _player;

    private int _xRand, _zRand;
    private Vector3 _randomPos;

    #region Unity Event Functions
    void Start()
    {
        SpawnPickup();
    }
    
    #endregion
    
    public void SpawnPickup()
    {
        _xRand = Random.Range(0, GridManager.Instance.Grid.GetLength(0));
        _zRand = Random.Range(0, GridManager.Instance.Grid.GetLength(1));

        _randomPos = GridManager.Instance.Grid[_xRand, _zRand];

        Instantiate(_pickup, _randomPos, Quaternion.identity);
    }
}
