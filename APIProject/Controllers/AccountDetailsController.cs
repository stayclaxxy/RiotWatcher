using APIProject.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountDetailsController : ControllerBase
    {
        [HttpGet("GetCombinedDetails")]
        public async Task<IActionResult> GetCombinedDetailsAsync([FromServices] IAccountDetailsProcessor accountProcessor, [FromQuery] string summonerName)
        {
            if (string.IsNullOrWhiteSpace(summonerName))
            {
                return BadRequest("No summoner Id provided.");
            }
            try
            {
                var result = await accountProcessor.GetCombinedDetailAsync(summonerName);
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
