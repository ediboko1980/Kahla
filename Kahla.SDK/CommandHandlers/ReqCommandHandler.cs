﻿using Kahla.SDK.Abstract;
using Kahla.SDK.Data;
using Kahla.SDK.Services;
using System.Threading.Tasks;

namespace Kahla.SDK.CommandHandlers
{
    public class ReqCommandHandler: ICommandHandler
    {
        private readonly BotLogger _botLogger;
        private readonly EventSyncer _eventSyncer;

        public ReqCommandHandler(
            BotLogger botLogger,
            EventSyncer eventSyncer)
        {
            _botLogger = botLogger;
            _eventSyncer = eventSyncer;
        }

        public  bool CanHandle(string command)
        {
            return command.StartsWith("req");
        }

        public async  Task Execute(string command)
        {
            await Task.Delay(0);
            foreach (var request in _eventSyncer.Requests)
            {
                _botLogger.LogInfo($"Name:\t{request.Creator.NickName}");
                _botLogger.LogInfo($"Time:\t{request.CreateTime}");
                if (request.Completed)
                {
                    _botLogger.LogSuccess($"\tCompleted.");
                }
                else
                {
                    _botLogger.LogWarning($"\tPending.");
                }

                _botLogger.LogInfo($"\n");
            }
        }
    }
}
