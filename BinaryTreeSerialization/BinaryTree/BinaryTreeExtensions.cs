namespace ConsoleApp1.BinaryTree
{
    internal static class BinaryTreeExtensions
    {
        public static IEnumerable<BinaryTreeNode> BreadFirstTraversalIterative(this BinaryTreeNode root)
        {
            var nodeQueue = new Queue<BinaryTreeNode>();
            BinaryTreeNode currPtr = null!;

            nodeQueue.Enqueue(root);

            while (nodeQueue.Count != 0)
            {
                currPtr = nodeQueue.Dequeue();

                yield return currPtr;

                if (currPtr.Left is not null)
                {
                    nodeQueue.Enqueue(currPtr.Left);
                }
                if (currPtr.Right is not null)
                {
                    nodeQueue.Enqueue(currPtr.Right);
                }
            }
        }
    }
}
