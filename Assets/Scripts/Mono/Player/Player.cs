using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using VD.Datastructures;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bodyPart;

    private LList<GameObject> _llPlayer;
    private Vector3 _currentPos;
    private Vector3 _headPos;
    private GameObject _bodyObj;
    
    private PlayerInput _playerInput;

    public LList<GameObject> LlPlayer => _llPlayer;

    #region Unity Event Functions

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        
        //Need to be set in awake to avoid null when SpawnManager access it
        _llPlayer = new LList<GameObject>();
        _llPlayer.AddFirst(gameObject);
    }

    private void Start()
    {
        //Events to listen for
        EventManager.Instance.onPickup += AddBodyPart;
        EventManager.Instance.onStartGame += StartMoving;
    }

    #endregion

    private void StartMoving()
    {
        StartCoroutine(MovePlayer());
    }
    IEnumerator MovePlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            var nextNode = _llPlayer.Next;
            _headPos = _llPlayer.Head.Value.transform.position;

            _currentPos = _headPos;
            _headPos += _playerInput.MoveDirection;

            //Checking boundary collision before moving player because i dont want to move the object outside the ground
            if (CheckBoundaryCollision(_headPos))
            {
                GameOver();
            }
            else
            {
                _llPlayer.Head.Value.transform.position = _headPos;

                if (_bodyObj != null)
                {
                    //No body movement during pickup, only collision check
                    if (_currentPos == _bodyObj.transform.position)
                    {
                        for (int i = 0; i < _llPlayer.Count - 1; i++)
                        {
                            if (nextNode != null)
                            {
                                CheckSelfCollision(nextNode);
                                nextNode = nextNode.Next;
                            }
                        }
                    }
                    //Body movement
                    else
                    {
                        for (int i = 0; i < _llPlayer.Count - 1; i++)
                        {
                            if (nextNode != null)
                            {
                                CheckSelfCollision(nextNode);

                                (_currentPos, nextNode.Value.transform.position) = (nextNode.Value.transform.position, _currentPos);
                                nextNode = nextNode.Next;
                            }
                        }
                    }
                }
            }
            
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private void AddBodyPart()
    {
        var parent = GameObject.Find("====== CLONES ======");

        _bodyObj = Instantiate(bodyPart, transform.position, quaternion.identity);
        _llPlayer.AddAfter(_llPlayer.Head, _bodyObj);
        
        //Organizing the objects in scene to track them easier
        _bodyObj.transform.parent = parent.transform;
        _bodyObj.name = $"BodyPart({_llPlayer.Count})";
    }

    
    private void CheckSelfCollision(LList<GameObject>.Node nextNode)
    {
        var playerPos = transform.position;

        if (playerPos == nextNode.Value.transform.position)
        {
            GameOver();
        }
    }
    
    private bool CheckBoundaryCollision(Vector3 playerPos)
    {
        //Could do it modular and based on grid but saving some time and hard set it just for this assignment
        if (playerPos.x == 11 ||
            playerPos.x == -11 ||
            playerPos.z == 11 ||
            playerPos.z == -11)
        {
            return true;
        }

        return false;
    }

    private void GameOver()
    {
        StopAllCoroutines();
        EventManager.Instance.EndGame();
    }

    private void OnDestroy()
    {
        EventManager.Instance.onPickup -= AddBodyPart;
        EventManager.Instance.onStartGame -= StartMoving;
    }
}
