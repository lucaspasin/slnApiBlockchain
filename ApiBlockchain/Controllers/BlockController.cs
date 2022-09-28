using ApiBlockchain6.Entity;
using ApiBlockchain6.Miner;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiBlockchain6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockController : ControllerBase
    {
        private readonly ILogger<BlockController> _logger;
        private readonly BlockMiner _blockMiner;
        private readonly ContractPool _contractPool;

        public BlockController(ILogger<BlockController> logger, BlockMiner blockMiner, ContractPool contractPool)
        {
            _logger = logger;
            _blockMiner = blockMiner;
            _contractPool = contractPool;
        }

        [HttpGet]
        [Route("/blocks")]
        public string Blocks() => JsonSerializer.Serialize(_blockMiner.Blockchain);

        [HttpGet]
        [Route("/blocks/{index}")]
        public string GetBlocksByIndex(int index)
        {
            Block block = null;
            if (index < _blockMiner.Blockchain.Count)
                block = _blockMiner.Blockchain[index];
            return JsonSerializer.Serialize(block);
        }

        [HttpGet]
        [Route("/latest")]
        public string GetLatestBlocks()
        {
            var block = _blockMiner.Blockchain.LastOrDefault();
            return JsonSerializer.Serialize(block);
        }

        [HttpPost]
        [Route("/add")]
        public void AddTransaction([FromBody] Contract contract)
        {
            _contractPool.Add(contract);
        }
    }
}
