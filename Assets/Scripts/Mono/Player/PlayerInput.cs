using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _moveDirection;
    public Vector3 MoveDirection => _moveDirection;

    #region Unity Event Functions

    private void Update()
    {
        InputDirection();
    }

    #endregion

    private void InputDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _moveDirection = new Vector3(0, 0, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _moveDirection = new Vector3(0, 0, -1);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _moveDirection = new Vector3(-1, 0, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _moveDirection = new Vector3(1, 0, 0);
        }
    }
}
