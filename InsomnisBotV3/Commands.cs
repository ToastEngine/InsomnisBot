using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus;

namespace InsomnisBotV3
{
    internal class Commands
    {
        [DSharpPlus.CommandsNext.Attributes.Command("hi")]
        public async Task UserId(CommandContext ctx)
        {
            await ctx.RespondAsync("User id: "+ctx.User.Id);
        }

        [DSharpPlus.CommandsNext.Attributes.Command("BuildDatabase")]
        public async Task UserId(CommandContext ctx)
        {
            await ctx.RespondAsync("Building database...");
            await ctx.RespondAsync("Guild Id: "+ctx.Guild.Id);
            foreach (DiscordUser user in ctx.Guild.GetAllMembersAsync()){
                Util.Logger.Log(0, "User: "+user.Id+", "+user.Username);
            }
        }

    }
}