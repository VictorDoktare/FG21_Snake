using System;

namespace Mono.LinkedList
{
    public class LList <T>
    {

        private Node _head;
        private int _count;

        public Node Next => _head.Next;
        public Node GetHead => _head;
        public Node GetTail => GetLast();
        public int Count
        {
            get
            {
                if (_count < 0)
                {
                    _count = 0;
                }
                
                return _count;
            }
            private set => _count = value;
        }

        //Add Nodes
        public void AddFirst(T type)
        {
            var newNode = new Node(type);
            Count++;

            if (_head != null)
            {
                newNode.Next = _head;
            }
            
            _head = newNode;
        }
        public void AddLast(T type)
        {
            var newNode = new Node(type);
            Count++;
            
            if (_head == null)
            {
                newNode.Next = _head;
            }

            var lastNode = GetLast();
            lastNode.Next = newNode;
        }
        
        //Remove Nodes
        public void RemoveFirst()
        {
            var node = _head;
            Count--;
            
            if (node == null)
            {
                throw new NullReferenceException("LList has no head");
            }

            _head = _head.Next;
        }

        //Todo Remove Last
        public void RemoveLast()
        {
            var node = _head;
            Count--;

            if (node != null)
            {
                while (node.Next.Next != null)
                {
                    node = node.Next;
                }
            }
        }

        private Node GetLast()
        {
            var node = _head;
            
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node;
        }
        
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
        
            public Node(T type)
            {
                Value = type;
                Next = null;
            }
        }
    
    
    }
}
