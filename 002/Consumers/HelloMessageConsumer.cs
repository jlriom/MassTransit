namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;
    using Microsoft.Extensions.Logging;

    public class HelloMessageConsumer :
        IConsumer<HelloMessage>
    {

        public readonly ILogger<HelloMessageConsumer> _logger;

        public HelloMessageConsumer(ILogger<HelloMessageConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<HelloMessage> context)
        {
            _logger.LogInformation("Message {Name}", context.Message.Name);

            return Task.CompletedTask;
        }
    }
}