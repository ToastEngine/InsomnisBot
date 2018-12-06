using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace InsomnisBotV3
{
    class Database
    {
        private static LiteDatabase database;
        private static bool Ready;
        public static bool isReady { get { return Ready; } }
        public static void init(LiteDatabase db)
        {
            Util.Logger.Log(0, "Initializing Database");
            database = db;
            Ready = true;
        }

        public static User getUser(string id)
        {
            var col = database.GetCollection<User>("Users");
            var Results = col.Find(Query.EQ("DiscordId", id));

            foreach (var user in Results)
            {
                if (user.DiscordId == id)
                {
                    return user;
                }
            }
            return null;
        }

        public static void setUser(User user)
        {
            var col = database.GetCollection<User>("Users");
            if (col.Update(user))
            {
                Util.Logger.Log(0, "Updated @"+user.DiscordId+", successfully");
            }
            else
            {
                Util.Logger.Log(3, "Failed to update @" + user.DiscordId + "");
            }
        }
    }
}
