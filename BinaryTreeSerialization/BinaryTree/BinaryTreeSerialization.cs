using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1.BinaryTree
{
    internal static class BinaryTreeSerialization
    {
        public static IList<BinaryTreeSerializationDTO<int>> Serialize(this BinaryTreeNode root)
        {
            var result = new List<BinaryTreeSerializationDTO<int>>();
            var nodeQueue = new Queue<BinaryTreeNode>();
            BinaryTreeNode currPtr = null!;
            nodeQueue.Enqueue(root);

            while (nodeQueue.Count != 0)
            {
                currPtr = nodeQueue.Dequeue();

                var dto = new BinaryTreeSerializationDTO<int>(currPtr.Data);

                if (currPtr.Left is not null)
                {
                    nodeQueue.Enqueue(currPtr.Left);
                    dto.Childrens.Add(1);
                }
                if (currPtr.Right is not null)
                {
                    nodeQueue.Enqueue(currPtr.Right);
                    dto.Childrens.Add(2);
                }

                result.Add(dto);
            }

            return result;
        }

        public static bool GetNthChild(int i,
            int childNumber,
            IList<BinaryTreeSerializationDTO<int>> nodeList,
            int sumOfTheElementsThathNotExists,
            BinaryTreeSerializationDTO<int> currDTO,
            out BinaryTreeNode result)
        {
            result = null!;

            if(currDTO is not null 
               && currDTO.Childrens is not null
                   && (currDTO.Childrens.Count > 0
                   && currDTO.Childrens[0] is 2 
                        && childNumber is 1)
               || currDTO!.Childrens!.Count == 0)
            {
                return false;
            }

            int index = ((2 * i) + childNumber) - sumOfTheElementsThathNotExists;
             
            if(index >= nodeList.Count)
            {
                return false;
            }

            result = new BinaryTreeNode(nodeList[index].Data);

            return true;
        }

        public static BinaryTreeNode Deserialize(this IList<BinaryTreeSerializationDTO<int>> nodeList)
        {
            BinaryTreeNode result = new(nodeList[0].Data);
            BinaryTreeNode currPtr = null!;
            BinaryTreeSerializationDTO<int> currDto = null;
            Queue<BinaryTreeNode> nodeQueue = new();
            int nodeListIndex = default,
                sum = default;

            nodeQueue.Enqueue(result);

            while(nodeQueue.Count is not 0)
            {
                currPtr = nodeQueue.Dequeue();
                currDto = nodeList[nodeListIndex];

                if (GetNthChild(nodeListIndex, 1, nodeList, sum, currDto, out var leftNode))
                {
                    currPtr.Left = leftNode;
                    nodeQueue.Enqueue(leftNode);
                }
                else
                {
                    sum++;
                }

                if (GetNthChild(nodeListIndex, 2, nodeList, sum, currDto, out var rightNode))
                {
                    currPtr.Right = rightNode;
                    nodeQueue.Enqueue(rightNode);
                }
                else
                {
                    sum++;
                }

                nodeListIndex++;
            }


            return result;
        }
    }
}
