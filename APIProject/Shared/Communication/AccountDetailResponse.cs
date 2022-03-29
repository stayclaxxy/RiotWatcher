using APIProject.Shared.Models;

namespace APIProject.Shared.Communication
{
    public class AccountDetailResponse : BaseResponse
    {
        public AccountDetailDto AccountDetails { get; set; }
    }
}
