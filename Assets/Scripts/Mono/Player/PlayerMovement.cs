using System.Collections;
using UnityEngine;
using VD.Datastructures;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _playerEgg;
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
        _llPlayer.AddFirst(gameObject);
        _llPlayer.AddLast(_playerEgg[0]);
        _llPlayer.AddLast(_playerEgg[1]);
        
        StartCoroutine(MovePlayer());
        

        Debug.Log(_llPlayer.Count);
    }

    #endregion

    IEnumerator MovePlayer()
    {
        while (true)
        {
            var playerPos = _llPlayer.Head.Value.transform.position;
            var currentPos;
            
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
                        _llPlayer.Head.Value.transform.position += _playerInput.MoveDirection;
                    }
                    else
                    {
                        _llPlayer.Next.Value.transform.position = playerPos;
                        currentPos = _llPlayer.Next;
                    }
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    
}
