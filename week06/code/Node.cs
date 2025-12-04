public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Problem 1: Insert a value into the BST
    public void Insert(int value)
    {
              // TODO Start Problem 1

        if (value < Data)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value> Data)
        {
            
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Problem 2: Search for a value
    public bool Contains(int value)
    {
                // TODO Start Problem 2

        if (value == Data)
            return true;

        if (value < Data)
            return Left != null && Left.Contains(value);

        return Right != null && Right.Contains(value);
    }

    // Problem 4: Get height of the tree
    public int GetHeight()
    {
                // TODO Start Problem 4

        int leftHeight = Left != null ? Left.GetHeight() : 0;
        int rightHeight = Right != null ? Right.GetHeight() : 0;

        return 1 + Math.Max(leftHeight, rightHeight); // Replace this line with the correct return statement(s)
        
    }
}
