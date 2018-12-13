using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus;

namespace InsomnisBotV3
{
    internal class Commands
    {   
        private Task<DiscordMessage> CreateMessage(CommandContext ctx, string str, string type)
        {
            if (type == "Notice")
            {
                DiscordEmbed embed = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Cyan,
                    Title = "Notice",
                    Description = str
                };
                return ctx.RespondAsync("", false, embed);
            }
            if (type == "Error")
            {
                DiscordEmbed embed = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Red,
                    Title = "Error",
                    Description = str
                };
                return ctx.RespondAsync("", false, embed);
            }
            return null;
        }

        [DSharpPlus.CommandsNext.Attributes.Command("hi")]
        public async Task UserId(CommandContext ctx)
        {
            await ctx.RespondAsync("User id: "+ctx.User.Id);
        }

        /*
        [DSharpPlus.CommandsNext.Attributes.Command("build")]
        public async Task BuildDatabase(CommandContext ctx)
        {
            if (ctx.Member.IsOwner) { 
                var watch = System.Diagnostics.Stopwatch.StartNew();
                DiscordMessage start = await CreateMessage(ctx, "Building database...", "Notice");
                foreach (DiscordUser user in await ctx.Guild.GetAllMembersAsync())
                {
                    Util.Logger.Log(0, "User: " + user.Id + ", " + user.Username);
                    Database.addUser(user.Id, 1, ctx.Guild.Id);
                }
                watch.Stop();
                await start.DeleteAsync();
                await CreateMessage(ctx, "Built database in " + watch.ElapsedMilliseconds + "ms", "Notice");
            }
            else
            {
                await CreateMessage(ctx, "You do not have the required permissions", "Error");
            }
        }
        */

    }
}