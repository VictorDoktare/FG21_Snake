using System.Collections;
using UnityEngine;
using VD.Datastructures;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerBody;
    
    private LList<GameObject> _llPlayer;
    private LList<GameObject>.Node _playerNode;
    
    //Dependencies
    private PlayerInput _playerInput;

    public LList<GameObject>.Node PlayerNode => _playerNode;

    #region Unity Event Functions

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _llPlayer = new LList<GameObject>();
        _llPlayer.AddFirst(gameObject);

        for (int i = 0; i < _playerBody.Length; i++)
        {
            _llPlayer.AddLast(_playerBody[i]);
        }
        
        StartCoroutine(MovePlayer());
        
    }

    #endregion

    IEnumerator MovePlayer()
    {
        while (true)
        {
            Vector3 currentPos = default;
            _playerNode = _llPlayer.Next;
            
            yield return new WaitForSeconds(0.5f);

            if (_llPlayer.Head.Next == null)
            {
                _llPlayer.Head.Value.transform.position += _playerInput.MoveDirection;
            }
            else
            {
                for (int i = 0; i < _llPlayer.Count; i++)
                {
                    if (i == 0)
                    {
                        var headPos = _llPlayer.Head.Value.transform.position;
                        
                        currentPos = headPos;
                        headPos += _playerInput.MoveDirection;
                        
                        _llPlayer.Head.Value.transform.position = headPos;
                    }
                    else if (_playerNode != null)
                    {
                        CheckForSelfCollision(_playerNode);
                        
                        (currentPos, _playerNode.Value.transform.position) = (_playerNode.Value.transform.position, currentPos);
                        _playerNode = _playerNode.Next;
                    }
                }

            }
        }
    }

    private void AddBodyPart()
    {
        //todo add body part when pickup
    }

    private void CheckForSelfCollision(LList<GameObject>.Node body)
    {
        var head = _llPlayer.Head;

        if (head.Value.transform.position == body.Value.transform.position)
        {
            Debug.Log("Dead");
        }
    }
}
