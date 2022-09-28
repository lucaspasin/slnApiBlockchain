namespace ApiBlockchain6.Entity
{
    public class Contract
    {
        public Contract() { }
        public Contract(string from, string to, int amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
        public string From { get; set; }
        public string To { get; set; }
        public int Amount { get; set; }
    }
}
