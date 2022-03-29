namespace APIProject.Shared.Communication
{
    public class CombinedDetailResponse : BaseResponse
    {
        public SummonerResponse Summoner { get; set; }
        public AccountDetailResponse AccountDetail { get; set; }
    }
}
