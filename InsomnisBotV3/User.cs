using System;
using System.Collections.Generic;
using System.Text;

namespace InsomnisBotV3
{
    class User
    {
        public string DiscordId { get; set; }
        public int PermissionLevel { get; set; }
        public bool chatMute { get; set; }
        public DateTime muteExpire { get; set; }
        public int WarningCount { get; set; }
        public Guid Id { get; set; }

        public User(string id, int permission)
        {
            DiscordId = id;
            PermissionLevel = permission;
            Console.WriteLine("Created user @"+id);
        }        
        public void setPermissionlvl(int lvl)
        {
            PermissionLevel = lvl;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Permission level channged @"+DiscordId);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
