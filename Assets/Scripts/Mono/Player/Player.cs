using System.Collections;
using UnityEngine;
using VD.Datastructures;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPart;
    private LList<GameObject> _llPlayer;
    
    //Dependencies
    private PlayerInput _playerInput;

    #region Unity Event Functions

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
         _llPlayer = new LList<GameObject>();
         
         StartCoroutine(MovePlayer());
         
    }

    #endregion

    IEnumerator MovePlayer()
    {
        while (true)
        {
            Vector3 currentPos = default;
    
            yield return new WaitForSeconds(0.25f);
    
            if (_llPlayer.Count == 0)
            {
                transform.position += _playerInput.MoveDirection;
            }
            else
            {
                var nextNode = _llPlayer.Next;
                
                for (int i = 0; i < _llPlayer.Count; i++)
                {
                    if (i == 0)
                    {
                        var playerPos = transform.position;
                        
                        currentPos = playerPos;
                        playerPos += _playerInput.MoveDirection;
                        
                        transform.position = playerPos;
                    }
                    else
                    {
                        CheckForSelfCollision(nextNode);
                        
                        (currentPos, nextNode.Value.transform.position) = (nextNode.Value.transform.position, currentPos);
                        nextNode = nextNode.Next;
                    }
                }
    
            }
        }
    }

    public void AddBodyPart()
    {
        Debug.Log("Pickedup");
        _llPlayer.AddFirst(_bodyPart);
        Debug.Log(_llPlayer.Count);
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
