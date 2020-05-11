using Common.Messaging;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Messaging.Consumer;

namespace WebMvc.Extensions
{
    public static class CustomMassTransit
    {
        public static void AddCustomMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(options =>
            {
                options.AddConsumer<OrderCreatedEventConsumer>();

                options.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ExchangeType = ExchangeType.Fanout;

                    cfg.ReceiveEndpoint("order_created", ep =>
                    {
                        ep.Bind<OrderCreatedEvent>();
                        ep.ConfigureConsumer<OrderCreatedEventConsumer>(provider);
                    });
                }));
            });
            services.AddMassTransitHostedService();

        }
    }
}
