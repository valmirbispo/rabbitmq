using EasyNetQ;
using rabbit_core;

namespace rabbit_api
{
    public class MensageriaService : BackgroundService
    {
        private IBus? _bus;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("host=localhost");

            _bus.PubSub.SubscribeAsync<TextMessage>("test", x => Task.Factory.StartNew(() => {

                var aqui = x.Text;

                var mais = aqui;
            }));

            _bus.PubSub.SubscribeAsync<UserMessage>("test2", x => Task.Factory.StartNew(() => {

                var aqui = x.Name;

                var mais = aqui;
            }));

            return Task.CompletedTask;
        }
    }
}
