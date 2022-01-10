using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserInterface.Models;
using UserInterface.Models.Index;
using UserInterface.Models.Json;

namespace UserInterface.Controllers
{
    public class ApplicationController : Controller
    {
        private HttpClient _client;

        public ApplicationController()
        {
            _client = new HttpClient();
        }

        public IActionResult Main()
        {
            var model = new IndexViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Form(IndexFormViewModel indexFormViewModel)
        {
            var monster = await GetMonster();
            var battleLogs = GetBattleLogs(indexFormViewModel, monster);
            var model = new IndexViewModel
            {
                IndexResultViewModel = new IndexResultViewModel {Result = monster.Name}
            };
            return View("Main", model);
        }

        public async Task<MonsterModel> GetMonster()
        {
            var response = await _client.GetAsync("https://localhost:5002/Monster/GetRandomMonster");
            var result = await response.Content.ReadFromJsonAsync<MonsterModel>();
            return result;
        }

        public async Task<MonsterModel> GetBattleLogs(IndexFormViewModel playerModel, MonsterModel monsterModel)
        {
            var jsonModel = new JsonModel(playerModel, monsterModel);
            var json = JsonSerializer.Serialize(jsonModel);
            // var response = await _client.PostAsJsonAsync("https://localhost:5001/Battle/GetResult",
            //     new StringContent(json, Encoding.UTF8, "application/json"));
            var response = await _client.PostAsJsonAsync("https://localhost:5001/Battle/GetResult", json);
            return null;
        }
    }
}