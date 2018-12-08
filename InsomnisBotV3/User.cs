using System;
using System.Collections.Generic;
using System.Text;

namespace InsomnisBotV3
{
    class User
    {
        public ulong DiscordId { get; set; }
        public int PermissionLevel { get; set; }
        public bool chatMute { get; set; }
        public DateTime muteExpire { get; set; }
        public int WarningCount { get; set; }
        public ulong GuildId{get; set;}
        public Guid Id { get; set; }

        public User(ulong id, int permission, ulong discordServerId)
        {
            DiscordId = id;
            PermissionLevel = permission;
            GuildId = discordServerId;
            Util.Logger.Log(0, "Created user @" + id);
        }        
        public void setPermissionlvl(int permissionlvl)
        {
            PermissionLevel = permissionlvl;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Permission level channged @"+DiscordId);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
