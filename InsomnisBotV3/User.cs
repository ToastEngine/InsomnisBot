using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsomnisBotV3
{
    class User
    {
        public ulong DiscordId { get; set; }
        public ulong GuildId { get; set; }
        public bool ChatMute { get; set; }
        public bool VoiceMute { get; set; }
        public DateTime ChatMuteExpire { get; set; }
        public DateTime VoiceMuteExpire { get; set; }
        public int PermissionLvl { get; set; }
        public Guid id { get; set; }

        public User(ulong DiscordId, ulong GuildId)
        {
            this.DiscordId = DiscordId;
            this.GuildId = GuildId;
            ChatMute = false;
            VoiceMute = false;
            ChatMuteExpire = DateTime.MinValue;
            VoiceMuteExpire = DateTime.MaxValue;
            PermissionLvl = 1;
        }
        public User()
        {

        }
    }
}
