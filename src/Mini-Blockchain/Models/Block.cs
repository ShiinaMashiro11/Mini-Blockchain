namespace Mini_Blockchain.Models
{
    public class Block
    {
        public int Id { get; set; }
        public string DataHash { get; set; }
        public string PreviousHash { get; set; }
        public DateTime Timestamp { get; set; }
    }
}