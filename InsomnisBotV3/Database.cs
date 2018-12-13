using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace InsomnisBotV3
{
    class Database
    {
        private static string DatabasePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\WorkingWithDbDemo";
        public static void initDatabase(string filePath)
        {
            using (var db = new LiteDatabase(filePath + "\\Databse.db"))
            {
                var col = db.GetCollection<User>("Users");
                Console.WriteLine("Database size :: " + col.Count());

                User newUser = new User(69, 69);
                col.Insert(newUser);
            }
        }

        public static void addUser(User user)
        {
            Console.WriteLine("addUser()");
            using (var db = new LiteDatabase(DatabasePath + "\\Databse.db"))
            {
                var col = db.GetCollection<User>("Users");
                col.Insert(user);
            }
        }

        public static int getSize()
        {
            Console.WriteLine("getSize()");
            using (var db = new LiteDatabase(DatabasePath + "\\Databse.db"))
            {
                var col = db.GetCollection<User>("Users");
                return col.Count();
            }
        }
        public static void delUser()
        {

        }

        public static void updUser()
        {

        }

        public static User getUser(ulong search_DiscordId, ulong search_GuildId)
        {
            Console.WriteLine("getUser()");
            using (var db = new LiteDatabase(DatabasePath + "\\Databse.db"))
            {
                var col = db.GetCollection<User>("Users");
                IEnumerable<User> results = col.Find(Query.EQ("DiscordId", search_DiscordId));

                foreach (var user in results)
                {
                    if (user.GuildId == search_GuildId)
                    {
                        return user;
                    }
                }

                return null;
            }
        }
    }
}
