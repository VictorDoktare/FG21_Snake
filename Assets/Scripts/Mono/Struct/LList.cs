public class LList <T>
{
    private Node _head;
    private int _count;

    public Node First => _head;
    public Node Last { get { Node node = GetLastNode(); return node; } }
    public Node Next => _head.Next;

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
        private set
        {
            _count = value;
        }
    }

    public void AddLast(T t)
    {
        Node newNode = new Node(t);
        Count++;
        if (_head == null)
        {
            _head = newNode;
            return;
        }

        Node lastNode = GetLastNode();
        lastNode.Next = newNode;
    }
    private Node GetLastNode()
    {
        Node node = _head;
        while (node.Next != null)
        {
            node = node.Next;
        }
        
        return node;
    }

    public class Node
    {
        public T ObjData { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            ObjData = data;
            Next = null;
        }
        
    }
}
