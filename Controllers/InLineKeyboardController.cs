using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

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

            switch (callbackQuery.Data)
            {
                case "len":

                {
                    var buttons = new List<InlineKeyboardButton[]>();
                    Button.Text = callbackQuery.Data;
                    Console.WriteLine($"нажата клавиша {Button.Text}");
                    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                        $"{Environment.NewLine}Введите слово или фразу", cancellationToken: ct,
                        parseMode: ParseMode.Html);


                    break;
                }
                case "back":
                {
                    Button.Text = callbackQuery.Data;
                    //Console.WriteLine($"нажата клавиша {Button.Text}");
                    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                        $"{Environment.NewLine}что то происходит", cancellationToken: ct,
                        parseMode: ParseMode.Html);

                    break;
                }
                case "sum":
                {
                    Button.Text = callbackQuery.Data;
                    Console.WriteLine($"нажата клавиша {Button.Text}");
                    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                        $"{Environment.NewLine}Введите числа через пробел", cancellationToken: ct,
                        parseMode: ParseMode.Html);
                    break;
                }
            }

            //if (callbackQuery.Data == "len")
            //{
            //    Button.Text = callbackQuery.Data;

            //    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
            //        $"{Environment.NewLine}Введите слово или фразу", cancellationToken: ct,
            //        parseMode: ParseMode.Html);
            //}
            //else if (callbackQuery.Data == "sum")
            //{
            //    Button.Text = callbackQuery.Data;

            //    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
            //        $"{Environment.NewLine}Введите числа через пробел", cancellationToken: ct,
            //        parseMode: ParseMode.Html);
            //}
            //else if (callbackQuery.Data == "len1")
            //{
            //    Button.Text = callbackQuery.Data;
            //    Console.WriteLine($"нажата клавиша {Button.Text}");
            //    await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
            //        $"{Environment.NewLine}что то происходит", cancellationToken: ct,
            //        parseMode: ParseMode.Html);
            //}
        }
    }
}