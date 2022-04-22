using APIProject.Controllers;
using APIProject.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NUniteTestProject
{
    public class Tests
    {
        [Test]
        public async Task Account_Details_Returns_BadRequest_Blank_Parameter()
        {
            //ARRANGE
            string parm = string.Empty;
            Mock<IAccountDetailsProcessor> mockProcessor = new Mock<IAccountDetailsProcessor>();
            mockProcessor.Setup(p => p.GetSummonerDetailsAsync(parm));
            var sut = new AccountDetailsController(mockProcessor.Object);
            //ACT
            var response = await sut.GetCombinedDetailsAsync(parm);
            ObjectResult result = response as ObjectResult;
            //ASSERT
            Assert.True(result is BadRequestObjectResult);
            Assert.AreEqual("No summoner Id provided.", result.Value);
        }
    }
}