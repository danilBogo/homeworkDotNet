using System.Text.Json;
using DatabaseBusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseBusinessLogic.Controllers
{
    [ApiController]
    [Route("Battle")]
    public class ConverterController : ControllerBase
    {
        [HttpPost]
        [Route("GetResult")]
        public JsonResult GetResult(JsonElement json)
        {
            var value = json.GetString();
            var result = JsonSerializer.Deserialize<JsonModel>(value);
            return null;
        }
    }
}