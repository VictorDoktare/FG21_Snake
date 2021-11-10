using System;
using UnityEngine;

namespace VD.Datastructures
{
    public class LList <T>
    {

        private Node _head;

        //Access
        public Node Next => _head.Next;
        public Node Head => _head;
        public Node Tail => GetLast();
        public int Count => GetCount();


        //Add Nodes
        public void AddFirst(T type)
        {
            var newNode = new Node(type);
            //Count++;

            if (_head != null)
            {
                newNode.Next = _head;
            }
            
            _head = newNode;
        }
        public void AddLast(T type)
        {
            var newNode = new Node(type);
            //Count++;
            
            if (_head == null)
            {
                newNode.Next = _head;
            }

            var lastNode = GetLast();
            lastNode.Next = newNode;
        }
        public void AddAfter(Node prevNode, T type)
        {
            var node = new Node(type);
            node.Next = prevNode.Next;
            prevNode.Next = node;
        }
        
        //Remove Nodes
        public void RemoveFirst()
        {
            var node = _head;
            //Count--;
            
            if (node == null)
            {
                throw new NullReferenceException("LList is empty");
            }

            _head = _head.Next;
        }
        public void RemoveLast()
        {
            var node = _head;
            //Count--;

            if (node == null)
            {
                throw new NullReferenceException("LList is empty");
            }

            while (node.Next.Next != null)
            {
                node = node.Next;
            }

            node.Next = null;

        }
        public void RemoveAt(int index)
        {
            var node = _head;
            //Count--;

            if (node == null)
            {
                throw new NullReferenceException("LList is empty");
            }

            if (index == 0)
            {
                _head = node.Next;
                return;
            }

            for (int i = 0; node != null && i < index - 1; i++)
            {
                node = node.Next;
            }

            if (node == null || node.Next == null)
            {
                return;
            }

            var next = node.Next.Next;
            node.Next = next;
        }

        //Useful Functions
        public Node GetIndex(int index)
        {
            var node = _head;
            
            if (node == null)
            {
                throw new NullReferenceException("LList is empty");
            }

            for (int i = 0; node != null && i < index; i++)
            {
                node = node.Next;
            }

            if (node == null)
            {
                throw new NullReferenceException("LList index out of range");
            }
            
            return node;
        }
        private int GetCount()
        {
            var node = _head;
            int count = 0;

            while (node != null)
            {
                count++;
                node = node.Next;
            }

            return count;
        }
        public void PrintList()
        {
            var node = _head;

            if (node == null)
            {
                throw new NullReferenceException("LList is empty");
            }
            
            while (node != null)
            {
                Debug.Log(node.Value);
                node = node.Next;
            }
        }

        //Node
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
        private Node GetLast()
        {
            var node = _head;
            
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node;
        }
    }
}
