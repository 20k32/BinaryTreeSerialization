namespace ConsoleApp1.BinaryTree
{
    internal class BinaryTreeNode
    {
        public int Data;
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;

        public BinaryTreeNode(int data, BinaryTreeNode left = null!, BinaryTreeNode right = null!) =>
            (Left, Right, Data) = (left, right, data);

        public static implicit operator BinaryTreeNode(int data) =>
            new BinaryTreeNode(data);

        public override string ToString() =>
            Data.ToString();
    }
}
