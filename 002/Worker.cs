using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace GettingStartedRabbitMQ
{
    public class Worker: BackgroundService
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
                await _bus.Publish(new HelloMessage
                {
                    Name = "World"
                }, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }

        }
    }
}
