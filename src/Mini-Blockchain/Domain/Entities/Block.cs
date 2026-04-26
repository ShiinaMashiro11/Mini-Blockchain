namespace Mini_Blockchain.Domain.Entities
{
    public class Block
    {
        public int Id { get; set; }
        public string DocumentHash { get; set; } = string.Empty;
        public string PreviousBlockHash { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}