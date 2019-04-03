using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth.Website3.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var disco = await DiscoveryClient.GetAsync("https://localhost:44371");
            var tokenClient = new TokenClient(disco.TokenEndpoint, "Website3", "MySecret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("Website3DemoApi");

            object model;
            if (tokenResponse.IsError)
            {
                model = "Error...could not get access token for API";
            }
            else
            {
                var clientLocal = new HttpClient();
                clientLocal.SetBearerToken(tokenResponse.AccessToken);
                var response = await clientLocal.GetAsync("https://localhost:5004/api/text/welcome");
                if (response.IsSuccessStatusCode)
                {
                    model = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    model = "Error...could not retrieve text";
                }
            }

            return View(model);
        }

        [Route("spa")]
        public IActionResult Spa()
        {
            return View();
        }
    }
}
