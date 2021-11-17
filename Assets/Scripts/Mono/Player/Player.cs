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
    private bool _isMoving = false;

    //Dependencies
    private PlayerInput _playerInput;

    #region Unity Event Functions

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        EventManager.Instance.onPickup += AddBodyPart;
        
        _llPlayer = new LList<GameObject>();
        _llPlayer.AddFirst(gameObject);
        StartCoroutine(MovePlayer());
    }

    #endregion

    IEnumerator MovePlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
            var nextNode = _llPlayer.Next;
            _headPos = _llPlayer.Head.Value.transform.position;

            _currentPos = _headPos;
            _headPos += _playerInput.MoveDirection;

            _llPlayer.Head.Value.transform.position = _headPos;

            if (_bodyObj != null)
            {
                //No body movement during pickup, only collision check
                if (_currentPos == _bodyObj.transform.position)
                {
                    if (nextNode != null)
                    {
                        for (int i = 0; i < _llPlayer.Count - 1; i++)
                        {
                            if (nextNode != null)
                            {
                                CheckForSelfCollision(nextNode);
                                nextNode = nextNode.Next;
                            }
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
                            CheckForSelfCollision(nextNode);

                            (_currentPos, nextNode.Value.transform.position) = (nextNode.Value.transform.position, _currentPos);
                            nextNode = nextNode.Next;
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

    private void CheckForSelfCollision(LList<GameObject>.Node nextNode)
    {
        var playerPos = transform.position;

        if (playerPos == nextNode.Value.transform.position)
        {
            StopAllCoroutines();
        }
    }
}
