using System;
using Unity.Mathematics;
using UnityEngine;
using VD.Datastructures;

//Class used to make sure objects are instantiated in the correct order
public class GameManager : Singleton<GameManager>
{
    [Header("Object Instantiation order")]
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _gridManager;
    [SerializeField] private GameObject _spawnManager;
    
    public static Player Player { get; private set; }

    private void Start()
    {
        Player = Instantiate(_player, Vector3.zero, quaternion.identity);
        InstantiateObject(_gridManager);
        InstantiateObject(_spawnManager);
    }

    private void InstantiateObject(GameObject obj)
    {
        Instantiate(obj, Vector3.zero, quaternion.identity);
    }
}
