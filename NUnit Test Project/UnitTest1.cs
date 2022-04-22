using APIProject.Controllers;
using APIProject.Processors;
using NUnit.Framework;
using System.Threading.Tasks;
using APIProject.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

namespace NUnit_Test_Project
{
    public class AccountDetailsControllerTest
    {
        [Test]
        public async Task Call_Endpoint_With_No_Parameter()
        {
            //ARRANGE
            var accessor = new RiotAccessor(new System.Net.Http.HttpClient());
            var processor = new AccountDetailsProcessor(accessor);
            var controller = new AccountDetailsController(processor);
            //ACT
            var actionResult = await controller.GetCombinedDetailsAsync(string.Empty);
            //ASSERT
            var result = actionResult as BadRequestObjectResult;

        }
    }
}