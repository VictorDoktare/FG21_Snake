using UnityEngine;
using VD.Datastructures;

public class PlayerBody : MonoBehaviour
{
    [SerializeField] private GameObject _testObj;
    private LList<GameObject> _listBody;
    private Tile _tile;

    private void Start()
    {
        _listBody = new LList<GameObject>();

    }
}
