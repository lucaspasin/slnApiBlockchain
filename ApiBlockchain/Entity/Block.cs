namespace ApiBlockchain6.Entity
{
    public class Block
    {
        public long Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Hash { get; set; }
        public string PrevHash { get; set; }
        public long Nounce { get; set; }
        public List<Contract> ContractList { get; set; }
    }
}
