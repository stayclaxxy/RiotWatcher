using APIProject.Shared.Models;

namespace APIProject.Shared.Communication
{
    public class SummonerResponse : BaseResponse
    {
        public SummonerDto Summoner { get; set; }
    }
}
