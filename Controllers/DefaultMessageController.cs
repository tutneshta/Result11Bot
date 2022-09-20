using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Result11Bot
{
    internal class DefaultMessageController
    {
        private readonly ITelegramBotClient _telegramClient;

        public DefaultMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            await _telegramClient.SendTextMessageAsync(message.Chat.Id,
                $"Получено сообщение не поддерживаемого формата", cancellationToken: ct);
        }
    }
}