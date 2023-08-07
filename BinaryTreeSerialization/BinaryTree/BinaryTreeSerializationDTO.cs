namespace ConsoleApp1.BinaryTree
{
    [Serializable]
    public class BinaryTreeSerializationDTO<T>
    {
        public T Data { get; init; } = default!;
        public List<int> Childrens { get; init; } = null!;

        public BinaryTreeSerializationDTO(T data)
        {
            Data = data;
            Childrens = new();
        }

        public override string ToString() => 
            $"{Data}";
    }
}
