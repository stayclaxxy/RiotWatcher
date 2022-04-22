using APIProject.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountDetailsController : ControllerBase, IAccountDetailsController
    {
        //private readonly ILogger<AccountDetailsController> _logger;
        private readonly IAccountDetailsProcessor _accountProcessor;

        public AccountDetailsController(IAccountDetailsProcessor accountDetailsProcessor)
        {
            _accountProcessor = accountDetailsProcessor;
        }

        //[HttpGet("GetSummonerDetails")]
        //public async Task<IActionResult> GetSummonerDetailsAsync([FromQuery] string summonerName)
        //{
        //    if(string.IsNullOrWhiteSpace(summonerName))
        //    {
        //        return BadRequest("No summmoner name provided.");
        //    }
        //    try
        //    {
        //        var result = await _accountProcessor.GetSummonerDetailsAsync(summonerName);
        //        if(result.Summoner != null && result.Summoner.Name != null)
        //        {
        //            return Ok(result);
        //        }
        //    }catch(Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //    return BadRequest("No summoner info was found with the given summoner name.");
        //}
        //[HttpGet("GetAccountDetails")]
        //public async Task<IActionResult> GetAccountDetailsAsync([FromQuery] string encryptedId)
        //{
        //    if (string.IsNullOrWhiteSpace(encryptedId))
        //    {
        //        return BadRequest("No encrypted Id provided.");
        //    }
        //    try
        //    {
        //        var result = await _accountProcessor.GetAccountDetailAsync(encryptedId);
        //        if (result.AccountDetails != null)
        //        {
        //            return Ok(result);
        //        }
        //    }catch(Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //    return BadRequest("No league info was found with the given encrypted Id.");
        //}
        [HttpGet("GetCombinedDetails")]
        public async Task<IActionResult> GetCombinedDetailsAsync([FromQuery] string summonerName)
        {
            if (string.IsNullOrWhiteSpace(summonerName))
            {
                return BadRequest("No summoner Id provided.");
            }
            try
            {
                var result = await _accountProcessor.GetCombinedDetailAsync(summonerName);
                if (result.Summoner != null && result.AccountDetail != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return BadRequest("No league info was found with the given summoner Id.");
        }
    }
}
