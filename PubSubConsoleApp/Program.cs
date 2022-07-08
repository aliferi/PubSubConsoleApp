// See https://aka.ms/new-console-template for more information
using Spectre.Console.Cli;

public class Program
{
    const string Apikey = "paKD3g.xqj7aw:BEQv3Lz0R4RRX665U3PJVJTNmX-uq9IaJ0PjqJWxfNs";

    public static async Task<int> Main(string[] args)
    {
        var app = new CommandApp();

        app.Configure(config =>
        {
            
        });

        return await app.RunAsync(args);
    }

}

   