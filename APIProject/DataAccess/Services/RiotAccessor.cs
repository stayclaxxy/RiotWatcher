using APIProject.Shared.Communication;
using APIProject.Shared.Interfaces;
using APIProject.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace APIProject.DataAccess.Services
{
    public class RiotAccessor : IRiotDataAccess
    {
        private readonly HttpClient _httpClient;

        public RiotAccessor(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SummonerResponse> GetSummonerInfoAsync(string summonerName)
        {
            var encodedString = HttpUtility.UrlEncode(summonerName, System.Text.Encoding.UTF8);
            var request = new HttpRequestMessage(HttpMethod.Get, $"summoner/v4/summoners/by-name/{encodedString}");
            var result = await _httpClient.SendAsync(request);
            SummonerResponse response = new SummonerResponse();

            if(result != null && result.IsSuccessStatusCode)
            {
                var summDetails = await result.Content.ReadFromJsonAsync<SummonerDto>();
                if (summDetails != null)
                {
                    response.Summoner = new SummonerDto
                    {
                        AccountId = summDetails.AccountId,
                        ProfileIconId = summDetails.ProfileIconId,
                        RevisionDate = summDetails.RevisionDate,
                        Name = summDetails.Name,
                        Id = summDetails.Id,
                        Puuid = summDetails.Puuid,
                        SummonerLevel = summDetails.SummonerLevel
                    };
                }
                else
                {
                    response.Message = "Failed to get Summoner data from Riot API.";
                    return response;
                }
            } else
            {
                response.Message = "The result from Riot API was null or failed.";
                return response;
            }


            response.Success = true;
            return response;
        }

        //public async Task<AccountDetailResponse> GetAccountDetailResponseAsync(string puuId)
        //{

        //}
    }
}
