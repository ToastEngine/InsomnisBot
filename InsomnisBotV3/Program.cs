using DSharpPlus;
using DSharpPlus.CommandsNext;
using System;
using System.Threading.Tasks;
using LiteDB;
using System.IO;

namespace InsomnisBotV3
{
    class Program
    {
        private static DiscordClient discord;
        static CommandsNextModule commands;
        private static string token;
        private static string DirectoryPath;

        static void Setup()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath += "\\Insomnis Bot";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
                Util.Logger.Log(0, "Created directory @" + filePath);
                Util.Logger.Log(0, "Init Database");
                using (var db = new LiteDatabase(filePath +"\\Database.db"))
                {
                    var col = db.GetCollection<User>("Users");
                    Util.Logger.Log(0, "Database size :: " + col.Count());
                }
                DirectoryPath = filePath;
            }
            else
            {
                Util.Logger.Log(0, "Directory exists @" + filePath);
                using (var db = new LiteDatabase(filePath + "\\Database.db"))
                {
                    var col = db.GetCollection<User>("Users");
                    Util.Logger.Log(0, "Database size :: " + col.Count());
                }
                DirectoryPath = filePath;
            }
            if (File.Exists(filePath += "\\Token.txt"))
            {
                Util.Logger.Log(0, "Found auth token!");
                token = File.ReadAllText(filePath + "\\Token.txt");
            }
            else
            {
                Util.Logger.Log(3, filePath);
                Util.Logger.Log(3, "Failed to find auth token!, press any key to close!");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        static void Main(string[] args)
        {
            Setup();

            token = System.IO.File.ReadAllText("C:\\Users\\Xeon\\Desktop\\Token.txt");
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
