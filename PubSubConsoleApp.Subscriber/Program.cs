// See https://aka.ms/new-console-template for more information


using IO.Ably;

namespace PubSubConsoleApp.subscriber
{
    public class Program
    {

        const string Apikey = "paKD3g.xqj7aw:BEQv3Lz0R4RRX665U3PJVJTNmX-uq9IaJ0PjqJWxfNs";
        public static async Task<int> Main(string[] args)
        {

            Console.WriteLine("Please enter your name");
            var Name = Console.ReadLine();

            Console.WriteLine("Please enter channel name");
            var Channel = Console.ReadLine();

            var ably = new AblyRealtime(new ClientOptions(Apikey) { ClientId = Name });
            var channel = ably.Channels.Get(Channel, new ChannelOptions
            { Params = new ChannelParams { { "rewind", "2m" } } });
            channel.Presence.Enter();

            var messageQeue=new Queue<string>();
            channel.Subscribe(message =>
            {
               //Console.WriteLine($" {message.Id} / {message.Name} :  {message.Data} ");
                messageQeue.Enqueue($" {message.ClientId} / {channel} :  {message.Data} ");
            });


            while (true)
                if (messageQeue.TryDequeue(out string? message))
                    Console.WriteLine(message);

            //while (true)
            //{
            //    Console.Write(Channel + " / " + Name + ": ");
            //    var text = Console.ReadLine();
            //    var result = await channel.PublishAsync("chat", text);
            //    if (result.IsFailure)
            //    {
            //        Console.WriteLine($"Error:  {result.Error.Message} ");
            //    }
            //}
            return 0;

        }

    }

}