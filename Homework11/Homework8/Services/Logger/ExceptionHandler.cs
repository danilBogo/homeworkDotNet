using System;
using System.Data;
using Homework8.Controllers;
using Microsoft.Extensions.Logging;

namespace Homework8.Services.Logger
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<CalculatorController> logger;
        private LogLevel logLevel { get; set; }
        
        public ExceptionHandler(ILogger<CalculatorController> logger) => this.logger = logger;

        public void Handle(Exception e)
        {
            logLevel = LogLevel.Information;
            Handle((dynamic) e);
        }
        
        private void Handle(ArgumentNullException e) 
            => logger.Log(logLevel, e.Message);

        private void Handle(ArgumentException e) 
            => logger.Log(logLevel, e.Message);

        private void Handle(InvalidExpressionException e) 
            => logger.Log(logLevel, e.Message);
    }
}