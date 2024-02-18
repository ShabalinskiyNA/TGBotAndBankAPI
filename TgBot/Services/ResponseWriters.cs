using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace TgBot.Services
{
    internal static class ResponseWriters
    {
        static IEnumerable<string> Banki;
        
        public static async void WriteStartInformation(Update update, ITelegramBotClient client)
        {
            UserStatus.AddUser(update.Message.Chat.Id);
            IEnumerable<string> names = await new InfoService().GetBanks();
            Banki = names;


            await client.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
                text: $"Здравствуй, {update.Message.Chat.FirstName}!!!\n" +
                "Наш сревис с радостью поможет Вам узнать информацию о текущем курсе валют.\n" +
                "Для начала выберете банк.",
                replyMarkup: new KeyboardMaker().GetStartKeyBoard(names));
        }


        public static async void WriteCurrency(Update update, ITelegramBotClient client)
        {
            if(!Banki.Contains(update.Message.Text))
            {
                await client.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: $"Мне очень жаль, но банк \"{update.Message.Text}\" не найден.\n" +
                $"Попробуйте выбрать другой банк.");
                return;
            }

            UserStatus.AddMessageText(update.Message.Chat.Id, update.Message.Text);
            var info = await new InfoService().GetCurrencies(update.Message.Text);
            
            string answer = "";
            foreach (string currency in info)
            {
                answer = answer + currency + "\n";
                
            }
            
            await client.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
                text: answer,
                replyMarkup: new KeyboardMaker().GetCurrensiesKeyBoard(info));
            
            UserStatus.NextStatusStep(update.Message.Chat.Id, WriteRate); 
        }

        public async static void WriteRate(Update update, ITelegramBotClient client)
        {
            var info = await new InfoService()
            .GetRate(UserStatus.GetUserMessage(update.Message.Chat.Id), update.Message.Text);

            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] { "/start" }
                
            })
            {
                ResizeKeyboard = true
            };


            await client.SendTextMessageAsync(
            chatId: update.Message.Chat.Id,
                text: info,
                replyMarkup: replyKeyboardMarkup);
            UserStatus.RemoveUser(update.Message.Chat.Id);
            UserStatus.RemoveMes(update.Message.Chat.Id);
        }
    }
}
