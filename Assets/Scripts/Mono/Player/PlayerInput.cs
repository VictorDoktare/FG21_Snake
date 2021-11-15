using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _moveDirection;
    public Vector3 MoveDirection => _moveDirection;

    #region Unity Event Functions

    private void Start()
    {
        _moveDirection = _moveDirection = new Vector3(0, 0, 1);
    }

    private void Update()
    {
        InputDirection();
    }

    #endregion

    private void InputDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _moveDirection != Vector3.back)
        {
            _moveDirection = Vector3.forward;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && _moveDirection != Vector3.forward)
        {
            _moveDirection = Vector3.back;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && _moveDirection != Vector3.right)
        {
            _moveDirection = Vector3.left;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow) && _moveDirection != Vector3.left)
        {
            _moveDirection = Vector3.right;
        }
    }
}
