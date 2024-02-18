using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TgBot.Services;

namespace TgBot
{
    delegate void HandlerSteps(Update update, ITelegramBotClient client);
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("6901425527:AAGI4pp6eVcMsuxkQ23k_loyUyjmu9BqUys");
            botClient.StartReceiving(Update, Error);
            Console.ReadKey();
        }

        private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        private static async Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            try
            {
                if(update.Message.Text == "/start")
                {
                    ResponseWriters.WriteStartInformation(update, client);
                }
                else
                {
                    UserStatus.GetUserState(update.Message.Chat.Id).Invoke(update, client);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }                

        }
    }


    

}
