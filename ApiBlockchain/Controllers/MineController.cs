using ApiBlockchain6.Miner;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiBlockchain6.Controllers
{
    public class MineController : ControllerBase
    {
        private readonly ILogger<MineController> _logger;
        private readonly BlockMiner _blockMiner;

        public MineController(ILogger<MineController> logger, BlockMiner blockMiner)
        {
            _logger = logger;
            _blockMiner = blockMiner;
        }

        [HttpGet]
        [Route("/generate")]
        public ObjectResult Generate()
        {
            _blockMiner.Generate();
            return new OkObjectResult(JsonSerializer.Serialize(_blockMiner.Blockchain));
        }
    }
}
