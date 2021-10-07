﻿using bot_disord.Common;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot_disord.Modules
{
    public class General : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Alias("p")] //command ghi tắt
        [RequireUserPermission(GuildPermission.Administrator)] //chỉ admin mới gọi command này đc
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("Pong!");
            await Context.User.SendMessageAsync("Private Message!"); // gửi tin nhắn private cho user
        }

        [Command("info")]
        public async Task Info(SocketGuildUser socketGuidUser = null)
        {
            if (socketGuidUser == null)
            {
                socketGuidUser = Context.User as SocketGuildUser;
            }
            var embed = new MyBotEmbedBuilder()
                .WithTitle("Info của mày nè:")
                .AddField("Id nè", socketGuidUser.Id, true)
                .AddField("Tên nè",$"{socketGuidUser.Username}#{socketGuidUser.Discriminator}", true)
                .AddField("Ngày tạo", socketGuidUser.CreatedAt, true)
                .WithThumbnailUrl(socketGuidUser.GetAvatarUrl() ?? socketGuidUser.GetDefaultAvatarUrl())
                .WithCurrentTimestamp()
                .Build();

            await ReplyAsync(embed: embed);
        }
    }
}
