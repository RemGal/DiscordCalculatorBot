using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DiscordCalculatorBot
{
    class Commands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Returns \"Pong!\"")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("calc")]
        [Description("Returns the result of given mathematical equation")]
        public async Task Calc(CommandContext ctx, [Description("mathematical equation")] params string[] args)
        {
            var input = string.Join("", args);
            string value = new DataTable().Compute(input, null).ToString();
            await ctx.Channel.SendMessageAsync("= " + value).ConfigureAwait(false);
        }

    }
}
