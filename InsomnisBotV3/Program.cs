using DSharpPlus;
using DSharpPlus.CommandsNext;
using System;
using System.Threading.Tasks;
using LiteDB;
using System.IO;
using DSharpPlus.Entities;

namespace InsomnisBotV3
{
    class Program
    {
        private static DiscordClient discord;
        static CommandsNextModule commands;
        private static string token;
        private static string DirectoryPath;

        static void Install()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath += "\\Insomnis Bot";
            if (!Directory.Exists(filePath))
            {
                Console.WriteLine("Installing...");
                Console.WriteLine("Installing Database");
                Directory.CreateDirectory(filePath);

                Database.initDatabase(filePath);

            }
            else
            {
                Console.WriteLine("Already Installed");
            }
        }

        static void Main(string[] args)
        {
            Install();
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
