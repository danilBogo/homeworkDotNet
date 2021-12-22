using System;
using Homework8.Controllers.Calculator;
using Homework8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers
{
    public class CalculatorController : Controller
    {
        // [HttpGet]
        // public IActionResult Calculate() => View();
        //
        // // [HttpPost]
        public IActionResult Calculate([FromServices] ICalculator calculator, string str)
        {
            var expression = calculator.ParseStringToExpression(str);
            var result = calculator.GetExpressionResult(expression);
            return View(new CalculatorModel(result));
        }
    }
}