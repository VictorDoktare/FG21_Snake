using System.Collections.Generic;
using Mono.LinkedList;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private LList<int> _llBody;
    private List<int> _test;

    private void Start()
    {
        _llBody = new LList<int>();

        var one = 1;
        var two = 2;
        var three = 3;


        _llBody.AddFirst(one);
         _llBody.AddLast(two);
         _llBody.AddLast(three);

        Debug.Log(_llBody.Count);
        Debug.Log($"Head.Next: {_llBody.Next.Value}");
        Debug.Log($"Head: {_llBody.GetHead.Value}  Tail: {_llBody.GetTail.Value}");
        
        _llBody.RemoveFirst();
        
        Debug.Log(_llBody.Count);
        Debug.Log($"Head.Next: {_llBody.Next.Value}");
        Debug.Log($"Head: {_llBody.GetHead.Value}  Tail: {_llBody.GetTail.Value}");

    }
}
