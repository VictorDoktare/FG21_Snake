using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0.1f, 1f)][SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isMoving;
    private void Start()
    {
        StartCoroutine(MovePlayer());
    }

    IEnumerator MovePlayer()
    {
        float moveUp = 0;
        
        while (_isMoving)
        {
            yield return new WaitForSeconds(_moveSpeed);
            transform.position += new Vector3(1, 0, 0);
        }
    }
}
