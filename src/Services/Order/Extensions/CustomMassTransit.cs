using Common.Messaging;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Order.Messaging.Consumers;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Extensions
{
    public static class CustomMassTransit
    {
        public static void AddCustomMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(options =>
            {
                options.AddConsumer<OrderReadyEventConsumer>();
                options.AddConsumer<OrderDeliveredEventConsumer>();

                options.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ExchangeType = ExchangeType.Fanout;

                    cfg.ReceiveEndpoint("order_ready", ep =>
                    {
                        ep.Bind<OrderReadyEvent>();
                        ep.ConfigureConsumer<OrderReadyEventConsumer>(provider);
                    });

                    cfg.ReceiveEndpoint("order_delivered", ep =>
                    {
                        ep.Bind<OrderDeliveredEvent>();
                        ep.ConfigureConsumer<OrderDeliveredEventConsumer>(provider);
                    });
                }));
            });
            services.AddMassTransitHostedService();

        }
    }
}
