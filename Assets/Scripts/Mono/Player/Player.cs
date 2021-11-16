using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using VD.Datastructures;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPart;
    private LList<GameObject> _llPlayer;
    private Vector3 _currentPos;
    // private Vector3 _playerPos;
    
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
            //Vector3 _currentPos = default;
    
            yield return new WaitForSeconds(0.25f);

            if (_llPlayer.Count == 0)
            {
                // transform.position += _playerInput.MoveDirection;
            }
            else
            {
                var nextNode = _llPlayer.Next;
                
                // transform.position += _playerInput.MoveDirection;

                for (int i = 0; i < _llPlayer.Count; i++)
                {
                    if (i == 0)
                    {
                        var headPos = _llPlayer.Head.Value.transform.position;
  
                        _currentPos = headPos;
                        headPos += _playerInput.MoveDirection;
                        
                        _llPlayer.Head.Value.transform.position = headPos;
                    }
                    else
                    {
                        CheckForSelfCollision(nextNode);
                        
                        (_currentPos, nextNode.Value.transform.position) = (nextNode.Value.transform.position, _currentPos);
                        nextNode = nextNode.Next;
                    }
                }
    
            }
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private void AddBodyPart()
    {
        Debug.Log("PickedUp");
        
        var bodyPart = Instantiate(_bodyPart, _llPlayer.Tail.Value.transform.position, quaternion.identity);
        _llPlayer.AddAfter(_llPlayer.Head, bodyPart);
    }

    private void CheckForSelfCollision(LList<GameObject>.Node nextNode)
    {
        var playerPos = transform.position;

        if (playerPos == nextNode.Value.transform.position)
        {
            StopAllCoroutines();
            Debug.Log("Dead");
        }
    }
}
