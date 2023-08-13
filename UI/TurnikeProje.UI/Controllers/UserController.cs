using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TurnikeProje.BussinesLayer.Abstract;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            string url = "https://localhost:7122/api/User";
            var jsondata = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(jsondata,System.Text.Encoding.UTF8,"application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("CreateUser");
            }
        }
    }
}
