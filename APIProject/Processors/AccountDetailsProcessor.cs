using APIProject.Shared.Communication;
using APIProject.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Processors
{
    public class AccountDetailsProcessor : IAccountDetailsProcessor
    {
        private readonly IRiotDataAccess _accountDao;

        public AccountDetailsProcessor(IRiotDataAccess accountDataAccess)
        {
            _accountDao = accountDataAccess;
        }

        public async Task<SummonerResponse> GetSummonerDetailsAsync(string summonerName)
        {
            return await _accountDao.GetSummonerInfoAsync(summonerName);
        }
        public async Task<AccountDetailResponse> GetAccountDetailAsync(string encryptedId)
        {
            return await _accountDao.GetAccountDetailResponseAsync(encryptedId);
        }
        public async Task<CombinedDetailResponse> GetCombinedDetailAsync(string summonerId)
        {
            var resp = new CombinedDetailResponse();
            resp.Summoner = await GetSummonerDetailsAsync(summonerId);
            resp.AccountDetail = await GetAccountDetailAsync(resp.Summoner.Summoner.Id);
            resp.Success = true;
            return resp;
        }
    }
}
