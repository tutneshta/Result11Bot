using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Result11Bot.Controllers
{
    internal class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;

        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            var buttons = new List<InlineKeyboardButton[]>();
            if (message.Text != "/start" && Button.Text != "sum" && Button.Text != "len")
            {
                await _telegramClient.SendTextMessageAsync(message.Chat.Id,
                    $"Нажмите на одну из кнопок", cancellationToken: ct);
            }

            if (message.Text == "/start")
            {
                buttons.Add(new[]
                {
                    InlineKeyboardButton.WithCallbackData(" Посчитать символы", "len"),
                    InlineKeyboardButton.WithCallbackData(" Посчитать сумму", "sum")
                });
                await _telegramClient.SendTextMessageAsync(message.Chat.Id,
                    $"<b>   Бот имеет две функции: подсчёт количества символов в тексте и вычисление " +
                    $"суммы чисел, которые вы ему отправляете (одним сообщением через пробел)</b>\n",
                    cancellationToken: ct, parseMode: ParseMode.Html,
                    replyMarkup: new InlineKeyboardMarkup(buttons));
            }

            if (message.Text != "/start" && Button.Text == "len")
            {
                var lenghtText = LenSum.GetLengthText(message.Text);

                await _telegramClient.SendTextMessageAsync(message.Chat.Id,
                    $"Количество символов: {lenghtText}", cancellationToken: ct);
            }

            if (message.Text != "/start" && CheckAndSumNumber.CheckNumber(message.Text) == true &&
                Button.Text == "sum")
            {
                await _telegramClient.SendTextMessageAsync(message.Chat.Id,
                    $"Сумма чисел: {CheckAndSumNumber.SumNumber(message.Text)}", cancellationToken: ct);
            }
            else if (message.Text != "/start" && CheckAndSumNumber.CheckNumber(message.Text) == false &&
                     Button.Text == "sum")
            {
                await _telegramClient.SendTextMessageAsync(message.Chat.Id,
                    $"некорректный ввод. Введите числа через пробел!!! ", cancellationToken: ct);
            }

            {
            }
        }
    }
}