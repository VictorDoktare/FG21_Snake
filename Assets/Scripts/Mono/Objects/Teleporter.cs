using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject _teleportPoint;

    IEnumerator TeleportCooldown()
    {
        yield return new WaitForSeconds(2);
        
        gameObject.GetComponent<BoxCollider>().enabled = true;
        _teleportPoint.GetComponent<BoxCollider>().enabled = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            _teleportPoint.GetComponent<BoxCollider>().enabled = false;
            
            other.transform.position = _teleportPoint.transform.position;
            StartCoroutine(TeleportCooldown());
        }
    }
}
