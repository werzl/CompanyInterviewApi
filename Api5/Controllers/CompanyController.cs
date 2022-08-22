using System.ComponentModel.DataAnnotations;
using Core;
using Core.Commands;
using Core.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly IStore _dataStore;
        private readonly ICommand<BuyoutRequest> _buyoutCommand;

        public CompanyController(
            ILogger<CompanyController> logger,
            IStore dataStore,
            ICommand<BuyoutRequest> buyoutCommand)
        {
            _logger = logger;
            _dataStore = dataStore;
            _buyoutCommand = buyoutCommand;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataStore.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([Required] string id)
        {
            var company = _dataStore.Get(id);
            _logger.LogInformation("Retrieved Company {id}", id);
            return Ok(company);
        }

        [HttpPost]
        [Route("/actions/buyout")]
        public IActionResult BuyoutCompany([FromBody] BuyoutRequest buyoutRequest)
        {
            var result = _buyoutCommand.Execute(buyoutRequest);

            return result.IsSuccessful ? Ok() : BadRequest(result.Errors);
        }
    }
}