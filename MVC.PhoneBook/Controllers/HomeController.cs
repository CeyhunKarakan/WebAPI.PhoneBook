using Microsoft.AspNetCore.Mvc;
using MVC.PhoneBook.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVC.PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
           _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5000/api/users");
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<UserResponseModel>>(jsonData);
                ViewBag.responseMessage = "Success";
                return View(result);
            }
            else 
            {
                return View(null);
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserResponseModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5000/api/users",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = $"There is an error. Error code: {(int)responseMessage.StatusCode}";
                return View(model);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5000/api/users/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UserResponseModel>(jsonData);
                return View(data);
            }
            else
            {
                return View(null);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserResponseModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"http://localhost:5000/api/users", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"http://localhost:5000/api/users/{id}");
            return RedirectToAction("Index");
        }
    }
}
