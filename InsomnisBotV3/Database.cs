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

        public static bool userExists(ulong userid, ulong guildid)
        {
            var col = database.GetCollection<User>("Users");
            col.Insert(new User(69, 1, 69));
            //Util.Logger.Log(1, "COUNT DATA SIZE : " + col.Count());
            return true;
        }
        /*
        public static User userexists(ulong id, ulong guildid)
        {
            var col = database.GetCollection<User>("Users");
            IEnumerable<User> Results = col.Find(Query.EQ("DiscordId", id));
            Util.Logger.Log(Results.GetEnumerator().Current.ToString());

            foreach (var user in Results)
            {
                Util.Logger.Log("searching @" + user.Id);
                if (user.DiscordId == id && user.DiscordServerId == guildid)
                {
                    return user;
                }
            }
            return null;
        }

        public static void addUser(ulong id, int permission, ulong guildid)
        {
            if (UserExists(id, guildid))
            {
                Util.Logger.Log("User Exists");
            }
            else
            {
                Util.Logger.Log("User doesnt exist");
            }
            //var col = database.GetCollection<User>("Users");
            //col.Insert(new User(id, permission, guildid));
            
        }
        public static void setUser(User user)
        {
            var col = database.GetCollection<User>("Users");
            col.Update(user);
            if (col.Update(user))
            {
                Util.Logger.Log(0, "Updated @"+user.DiscordId+", successfully");
            }
            else
            {
                Util.Logger.Log(3, "Failed to update @" + user.DiscordId + "");
                col.Insert(user);
                Util.Logger.Log(0, "Added new user to database @" + user.DiscordId + "");
            }
        }
        */
    }
}
