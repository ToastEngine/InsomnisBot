using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace InsomnisBotV3
{
    class Program
    {
        private static DiscordClient discord;
        static CommandsNextModule commands;
        private static string token;

        static void Main(string[] args)
        {
            token = System.IO.File.ReadAllText("C:\\Users\\Xeon\\source\\repos\\InsomnisBotV3\\InsomnisBotV3\\Token.txt");
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {

            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!"
            });
                
            commands.RegisterCommands<Commands>();
            Console.WriteLine("Connecting...");
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
