using System;
using Homework8.Controllers.Calculator;
using Homework8.Models;
using Homework8.Services.Logger;
using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IExceptionHandler exceptionHandler;

        public CalculatorController(IExceptionHandler exceptionHandler) => 
            this.exceptionHandler = exceptionHandler;

        [HttpGet]
        public IActionResult Calculate() => View();

        [HttpPost]
        public IActionResult Calculate([FromServices] ICalculator calculator,
            string str)
        {
            try
            {
                var expression = calculator.ParseStringToExpression(str);
                var result = calculator.GetExpressionResult(expression);
                return View(new CalculatorModel(result));
            }
            catch (Exception exception)
            {
                exceptionHandler.Handle(exception);
                return View(new CalculatorModel("something went wrong"));
            }
        }
    }
}