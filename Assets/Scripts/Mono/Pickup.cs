using System;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPickup;

    private void Start()
    {
        _onPickup.AddListener(GameManager.Player.AddBodyPart);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_onPickup == null)
            {
                _onPickup = new UnityEvent();
            }

            _onPickup.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        _onPickup.RemoveListener(GameManager.Player.AddBodyPart);
    }
}
