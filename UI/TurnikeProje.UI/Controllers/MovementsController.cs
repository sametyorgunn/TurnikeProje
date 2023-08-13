using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using TurnikeProje.EntityLayer.Dtos;
using TurnikeProje.EntityLayer.Entities;

namespace TurnikeProje.UI.Controllers
{
    public class MovementsController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public MovementsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            if(HttpContext.Session.GetInt32("userid")!=null)
            {
                int? userid = HttpContext.Session.GetInt32("userid");
                var client = _httpClientFactory.CreateClient();
                string url = $"https://localhost:7122/api/Movements/{1}";
                HttpResponseMessage response = await client.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    var jsondata = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<UserInfoDto>(jsondata);
                    return View(data);
                }

            }
            else
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Index(CreateMovementsDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            string url = "https://localhost:7122/api/Movements";
            var jsondata = JsonConvert.SerializeObject(dto);
            HttpContent content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public async Task<IActionResult> Exit(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            string url = $"https://localhost:7122/api/Movements/Exitadd/{1}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}
