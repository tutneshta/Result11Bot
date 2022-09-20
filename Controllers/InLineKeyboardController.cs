using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Result11Bot.Controllers
{
    public class InlineKeyboardController
    {
        private readonly ITelegramBotClient _telegramClient;

        public InlineKeyboardController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }

        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
            {
                return;
            }

            if (callbackQuery.Data == "len")
            {
                Button.Text = callbackQuery.Data;

                await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                    $"{Environment.NewLine}Введите слово или фразу", cancellationToken: ct,
                    parseMode: ParseMode.Html);
            }
            else
            {
                Button.Text = callbackQuery.Data;

                await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                    $"{Environment.NewLine}Введите числа через пробел", cancellationToken: ct,
                    parseMode: ParseMode.Html);
            }
        }
    }
}