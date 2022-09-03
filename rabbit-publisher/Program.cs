using EasyNetQ;
using rabbit_core;

//using (var bus = RabbitHutch.CreateBus("host=172.17.0.4"))
using (var bus = RabbitHutch.CreateBus("host=localhost:5672"))
{
    var input = String.Empty;
    Console.WriteLine("Enter a message. 'Quit' to quit.");
    while ((input = Console.ReadLine()) != "Quit")
    {
        if (input.Contains("user"))
        {
            bus.PubSub.Publish(new UserMessage { Name = input });
        }
        else
        {
            bus.PubSub.Publish(new TextMessage { Text = input });
        }

        Console.WriteLine("Message published!");
    }
}