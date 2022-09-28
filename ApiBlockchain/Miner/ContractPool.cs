using ApiBlockchain6.Entity;

namespace ApiBlockchain6.Miner
{
    public class ContractPool
    {
        private List<Contract> ContractList;

        public ContractPool()
        {
            ContractList = new List<Contract>();
        }

        public void Add(Contract contract)
        {
            ContractList.Add(contract);
        }

        public List<Contract> TakeAll()
        {
            var all = ContractList.ToList();
            ContractList.Clear();
            return all;
        }
    }
}
