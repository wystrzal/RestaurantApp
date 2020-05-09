using Kitchen.Messaging;
using Kitchen.Messaging.Consumer;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Extensions
{
    public static class CustomMassTransit
    {
        public static void AddCustomMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(options =>
            {
                options.AddConsumer<OrderReadyEventConsumer>();

                options.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("order_ready_kitchen", ep =>
                    {
                        ep.Bind<OrderReadyEvent>();
                        ep.ConfigureConsumer<OrderReadyEventConsumer>(provider);
                    });
                }));
            });
            services.AddMassTransitHostedService();

        }
    }
}
