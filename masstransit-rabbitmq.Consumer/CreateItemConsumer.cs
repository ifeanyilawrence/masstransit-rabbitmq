using System.Threading.Tasks;
using MassTransit;
using masstransit_rabbitmq.Shared;
using Microsoft.Extensions.Logging;

namespace masstransit_rabbitmq.Consumer
{
    public class CreateItemConsumer : IConsumer<ICreateItem>
    {
        readonly ILogger<CreateItemConsumer> _logger;

        public CreateItemConsumer(ILogger<CreateItemConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ICreateItem> context)
        {
            _logger.LogInformation($"Item Submitted: id: {context.Message.Id} - name: {context.Message.Name}");
        }
    }
}