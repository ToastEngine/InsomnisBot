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

                Console.WriteLine("Bot security token: ");
                string torken = Console.ReadLine();
                Console.WriteLine("Security token: "+torken);
                File.WriteAllText(filePath+"\\token.txt", token);

                token = torken;
            }
            else
            {
                Console.WriteLine("Already Installed");
                if (!File.Exists(filePath + "\\token.txt"))
                {
                    Console.WriteLine("No token found!");
                    Console.WriteLine("Bot security token: ");
                    string token = Console.ReadLine();
                    Console.WriteLine("Security token: " + token);
                    File.WriteAllText(filePath + "\\token.txt", token);
                }
                else
                {
                    token = File.ReadAllText(filePath + "\\token.txt");
                }
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
