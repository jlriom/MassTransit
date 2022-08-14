using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GettingStarted
{
    public class Worker : BackgroundService
    {

        private readonly IBus _bus;


        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                try
                {

                    await _bus.Publish(new HelloMessage
                    {
                        Name = "World"
                    }, stoppingToken);
                }
                catch (Exception ex)
                {

                }

                await Task.Delay(1000);
            }
        }
    }
}
