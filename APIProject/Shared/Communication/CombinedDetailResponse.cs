namespace APIProject.Shared.Communication
{
    public class CombinedDetailResponse : BaseResponse
    {
        public SummonerResponse Summoner { get; set; }
        public List<AccountDetailResponse> AccountDetail { get; set; }
    }
}
