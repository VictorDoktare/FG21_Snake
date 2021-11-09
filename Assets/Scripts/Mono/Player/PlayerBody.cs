using System;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public LList<GameObject>.Node _testObj;

    private void Start()
    {
        _testObj = new LList<GameObject>();
        var obj = new GameObject();
       _testObj.AddLast(obj);
       LList<GameObject>.Node;
    }
}
