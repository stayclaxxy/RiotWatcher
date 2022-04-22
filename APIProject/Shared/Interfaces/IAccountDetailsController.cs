using Microsoft.AspNetCore.Mvc;

namespace APIProject.Shared.Interfaces
{
    public interface IAccountDetailsController
    {
        public Task<IActionResult> GetCombinedDetailsAsync([FromQuery] string summonerName);
    }
}
