using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatabaseBusinessLogic.Models;
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
            if (!IsDamageValid(indexFormViewModel.Damage))
                return View("Main",
                    new IndexViewModel
                    {
                        IndexResultViewModel = new IndexResultViewModel
                            {Result = "Урон не валиден. Пример валидного: 1k10"}
                    });
            var monster = await GetMonster();
            var battleLogs = await GetBattleLogs(indexFormViewModel, monster);
            var minAcToAlwaysHit = indexFormViewModel.AttackModifier + 1;
            var damagePerRound = (indexFormViewModel.AttackModifier + indexFormViewModel.DamageModifier) *
                                 indexFormViewModel.NumberAttacksPerRound;
            indexFormViewModel.HitPoints = battleLogs.PlayerHitPoints;
            var model = new IndexViewModel
            {
                IndexFormViewModel = indexFormViewModel,
                IndexResultViewModel = new IndexResultViewModel {Result = battleLogs.Logs}
            };
            return View("Main", model);
        }

        public async Task<MonsterModel> GetMonster()
        {
            var response = await _client.GetAsync("https://localhost:5002/Monster/GetRandomMonster");
            var result = await response.Content.ReadFromJsonAsync<MonsterModel>();
            return result;
        }

        public async Task<BattleLogModel> GetBattleLogs(IndexFormViewModel playerModel, MonsterModel monsterModel)
        {
            var jsonModel = new JsonModel(playerModel, monsterModel);
            var json = JsonSerializer.Serialize(jsonModel);
            var response = await _client.PostAsJsonAsync("https://localhost:5001/Battle/GetResult", json);
            var result = await response.Content.ReadFromJsonAsync<BattleLogModel>();
            return result;
        }

        private bool IsDamageValid(string damage)
        {
            if (String.IsNullOrEmpty(damage) || !damage.Contains("k"))
                return false;
            var parts = damage.Split('k');
            return parts.Length == 2;
        }
    }
}