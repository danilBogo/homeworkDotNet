using System;
using System.Text.Json;
using DatabaseBusinessLogic.Models;
using DatabaseBusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseBusinessLogic.Controllers
{
    [ApiController]
    [Route("Battle")]
    public class ConverterController : ControllerBase
    {
        [HttpPost]
        [Route("GetResult")]
        public JsonResult GetResult(JsonElement  json)
        {
            var value = json.GetString();
            if (value is null)
                throw new Exception("value is null");
            var deserialize = JsonSerializer.Deserialize<JsonRequestModel>(value);
            if (deserialize is null)
                throw new Exception("json deserialized value is null");
            var battleService = new BattleService();
            var logs = battleService.GetBattleLogs(deserialize.PlayerModel, deserialize.MonsterModel);
            return new JsonResult(logs);
        }
    }
}