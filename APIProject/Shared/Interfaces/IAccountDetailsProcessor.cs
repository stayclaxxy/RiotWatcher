using APIProject.Shared.Communication;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Shared.Interfaces
{
    public interface IAccountDetailsProcessor
    {
        public Task<SummonerResponse> GetSummonerDetailsAsync(string summonerName);
    }
}
