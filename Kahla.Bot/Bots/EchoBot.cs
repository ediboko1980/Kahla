﻿using Aiursoft.Pylon.Interfaces;
using Kahla.Bot.Abstract;
using Kahla.SDK.Events;
using Kahla.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Kahla.Bot.Bots
{
    public class EchoBot : BotBase, ISingletonDependency
    {
        private KahlaUser _botProfile;

        public override KahlaUser Profile
        {
            get => _botProfile;
            set
            {
                _botProfile = value;
                var profilestring = JsonConvert.SerializeObject(value, Formatting.Indented);
                Console.WriteLine(profilestring);
            }
        }

        public override async Task OnMessage(string inputMessage, NewMessageEvent eventContext)
        {
            await Task.Delay(0);
            if (eventContext.Muted)
            {
                return;
            }
            if (eventContext.Message.SenderId == Profile.Id)
            {
                return;
            }
            var replaced = inputMessage
                    .Replace("吗", "")
                    .Replace('？', '！')
                    .Replace('?', '!');
            if (eventContext.Mentioned)
            {
                replaced = replaced + $" @{eventContext.Message.Sender.NickName.Replace(" ", "")}";
            }
            replaced.Replace($"@{Profile.NickName.Replace(" ", "")}", "");
            await Task.Delay(700);
            await Send(replaced, eventContext.Message.ConversationId, eventContext.AESKey);
        }

        public override async Task<bool> OnFriendRequest(NewFriendRequestEvent arg)
        {
            await Task.Delay(0);
            return true;
        }
    }
}
