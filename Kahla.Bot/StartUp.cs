﻿using Aiursoft.XelNaga.Interfaces;
using Aiursoft.XelNaga.Tools;
using Kahla.SDK.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Kahla.Bot
{
    public class StartUp : IScopedDependency
    {
        public BotBase Bot { get; set; }

        public static IServiceScope ConfigureServices()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            return new ServiceCollection()
                .AddAccessiableDependencies()
                .AddBots()
                .BuildServiceProvider()
                .GetService<IServiceScopeFactory>()
                .CreateScope();
        }

        public StartUp(BotFactory botFactory)
        {
            Bot = botFactory.SelectBot();
        }
    }
}
