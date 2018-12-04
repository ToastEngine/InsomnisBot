using DSharpPlus.CommandsNext;
using System.Threading.Tasks;

namespace InsomnisBotV3
{
    internal class Commands
    {
        [DSharpPlus.CommandsNext.Attributes.Command("hi")]
        public async Task UserId(CommandContext ctx)
        {
            await ctx.RespondAsync("User id: "+ctx.User.Id);
        }
    }
}