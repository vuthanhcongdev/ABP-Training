using System.Threading.Tasks;
using myProject.Models.TokenAuth;
using myProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace myProject.Web.Tests.Controllers
{
    public class HomeController_Tests: myProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}