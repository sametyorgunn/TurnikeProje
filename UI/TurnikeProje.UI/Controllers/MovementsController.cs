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

        public IActionResult Index()
        {
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
    }
}
