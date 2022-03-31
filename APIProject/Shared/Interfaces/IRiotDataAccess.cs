using APIProject.Shared.Communication;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Shared.Interfaces
{
    public interface IRiotDataAccess
    {
        public Task<SummonerResponse> GetSummonerInfoAsync(string summonerName);
        public Task<List<AccountDetailResponse>> GetAccountDetailResponseAsync(string encryptedId);
    }
}
