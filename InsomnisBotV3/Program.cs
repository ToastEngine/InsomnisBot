using DSharpPlus;
using DSharpPlus.CommandsNext;
using System;
using System.Threading.Tasks;
using LiteDB;

namespace InsomnisBotV3
{
    class Program
    {
        private static DiscordClient discord;
        static CommandsNextModule commands;
        private static string token;

        static void initDatabase()
        {
            Util.Logger.Log(0, "Init Database");
            using (var db = new LiteDatabase("C:\\Users\\Xeon\\Desktop\\Database.db"))
            {
                var col = db.GetCollection<User>("Users");
                //  var testuser = new User("TestDiscordId", 0);
                //  col.Insert(testuser);
                Util.Logger.Log(0, "Database size :: "+col.Count());
            }
            
        }
        static void Main(string[] args)
        {
            initDatabase();
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
