﻿using ECOM.API.Carrinho.Services;
using ECOM.Core.Utils;
using ECOM.MessageBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECOM.API.Carrinho.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<CarrinhoIntegrationHandler>();
        }
    }
}
