using APIProject.Shared.Communication;
using APIProject.Shared.Interfaces;
using APIProject.Shared.Models;
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
            var response = new SummonerResponse();

            if(result != null && result.IsSuccessStatusCode)
            {
                var summDetails = await result.Content.ReadFromJsonAsync<SummonerDto>();
                if (summDetails != null)
                {
                    response = new SummonerResponse
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
                    return response;
                }
            } else
            {
                return response;
            }
            return response;
        }

        public async Task<List<AccountDetailResponse>> GetAccountDetailResponseAsync(string encryptedId)
        {
            var encodedString = HttpUtility.UrlEncode(encryptedId, System.Text.Encoding.UTF8);
            var request = new HttpRequestMessage(HttpMethod.Get, $"league/v4/entries/by-summoner/{encodedString}");
            var result = await _httpClient.SendAsync(request);
            List<AccountDetailResponse> response = new List<AccountDetailResponse>();

            if (result != null && result.IsSuccessStatusCode)
            {
                var summDetails = await result.Content.ReadFromJsonAsync<List<AccountDetailDto>>();
                if (summDetails != null)
                {
                    foreach (var detail in summDetails)
                    {
                        response.Add( new AccountDetailResponse
                        {
                            LeagueId = detail.LeagueId,
                            SummonerId = detail.SummonerId,
                            SummonerName = detail.SummonerName,
                            QueueType = detail.QueueType,
                            Tier = detail.Tier,
                            Rank = detail.Rank,
                            LeaguePoints = detail.LeaguePoints,
                            Wins = detail.Wins,
                            Losses = detail.Losses,
                            HotStreak = detail.HotStreak,
                            Veteran = detail.Veteran,
                            Inactive = detail.Inactive,
                            MiniSeries = detail.MiniSeries
                        });
                    }
                }
                else
                {
                    return response;
                }
            }
            else
            {
                return response;
            }
            return response;
        }
    }
}
