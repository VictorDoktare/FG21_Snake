using System.Collections.Generic;
using Mono.LinkedList;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private LList<int> _llBody;

    private void Start()
    {
        LinkListDebugging();
    }
    
    private void LinkListDebugging()
    {
        _llBody = new LList<int>();

        var one = 1;
        var two = 2;
        var three = 3;
        var four = 4;

        _llBody.AddFirst(one);
        _llBody.AddLast(two);
        _llBody.AddLast(three);
        
        Debug.Log(_llBody.Count);
        Debug.Log($"Node at index 0 value: {_llBody.GetIndex(0).Data}");
        Debug.Log($"Node at index 1 value: {_llBody.GetIndex(1).Data}");
        Debug.Log($"Node at index 2 value: {_llBody.GetIndex(2).Data}");
        Debug.Log($"Node at index 2 value: {_llBody.GetIndex(3).Data}");
        
    }
}
