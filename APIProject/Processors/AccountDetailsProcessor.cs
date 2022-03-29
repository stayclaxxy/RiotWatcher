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
    }
}
