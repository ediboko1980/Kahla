﻿using Kahla.SDK.Abstract;
using System;
using System.Threading.Tasks;

namespace Kahla.SDK.CommandHandlers
{
    public class ClearCommandHandler : ICommandHandler
    {
        public  bool CanHandle(string command)
        {
            return command.StartsWith("clear");
        }

        public  Task Execute(string command)
        {
            Console.Clear();
            return Task.CompletedTask;
        }
    }
}
