using System;
using System.Linq;
using System.Text.Json;
using Exam.Database;
using Exam.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonsterController : ControllerBase
    {
        private ApplicationDbContext _dbContext;
        private Random _random;
        
        public MonsterController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _random = new Random();
        }
        
        [HttpGet]
        [Route("GetRandomMonster")]
        public JsonResult GetRandomMonster()
        {
            var totalCount = _dbContext.Monsters.Count();
            var countToSkip = _random.Next(totalCount);
            var monster = _dbContext.Monsters.Skip(countToSkip).First();
            return new JsonResult(monster);
        }
    }
}