using APIProject.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountDetailsController : ControllerBase
    {
        //private readonly ILogger<AccountDetailsController> _logger;
        private readonly IAccountDetailsProcessor _accountProcessor;

        public AccountDetailsController(IAccountDetailsProcessor accountDetailsProcessor)
        {
            _accountProcessor = accountDetailsProcessor;
        }

        [HttpGet("GetAccountDetails")]
        public async Task<IActionResult> GetAccountDetailsAsync([FromQuery] string summonerName)
        {
            if(summonerName == null || summonerName.Length == 0)
            {
                return BadRequest("No summmoner name provided.");
            }
            try
            {
                var result = await _accountProcessor.GetSummonerDetailsAsync(summonerName);
                if(result.Summoner != null && result.Summoner.Name != null)
                {
                    return Ok(result);
                }
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return BadRequest("No summoner info was found with the given summoner name");
        }
    }
}
