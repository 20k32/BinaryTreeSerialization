using ConsoleApp1.BinaryTree;
using System.Text.Json;

namespace BinaryTreeSerialization
{
    internal class Program
    {
        private const string FILE_PATH = "BinaryTree.json";

        static void Main(string[] args)
        {
            var root = new BinaryTreeNode(8);

            root.Left = 3;
            root.Left.Left = 1;
            root.Left.Right = 6;
            root.Left.Right.Left = 4;
            root.Left.Right.Right = 7;

            root.Right = 10;
            root.Right.Right = 14;
            root.Right.Right.Left = 13;


            var serialized = root.Serialize();

            var treeStringIn = JsonSerializer.Serialize(serialized, options: new()
            {
                WriteIndented = true,
            });

            File.WriteAllText(FILE_PATH, treeStringIn);

            var treeStringOut = File.ReadAllText(FILE_PATH);

            var treeArray = JsonSerializer.Deserialize<IList<BinaryTreeSerializationDTO<int>>>(treeStringOut);

            var deserialized = treeArray!.Deserialize();

            Console.WriteLine("deserialized:");
            foreach (var item in deserialized.BreadFirstTraversalIterative())
            {
                Console.Write(item + " ");
            }
        }
    }
}