using System;

namespace Homework8.Services.Logger
{
    public interface IExceptionHandler
    {
        void Handle(Exception e);
    }
}