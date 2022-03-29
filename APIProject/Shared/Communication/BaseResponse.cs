using Microsoft.AspNetCore.Mvc;

namespace APIProject.Shared.Communication
{
    public class BaseResponse
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
