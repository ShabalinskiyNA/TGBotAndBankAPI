using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TgBot.Services
{
    internal class KeyboardMaker
    {
        public ReplyKeyboardMarkup GetStartKeyBoard(IEnumerable<string> names)
        {
            List<KeyboardButton> arr = new List<KeyboardButton>();
            foreach (string item in names)
            {
                arr.Add(new KeyboardButton(item));
            }

            ReplyKeyboardMarkup replyKeyboardMarkup = new(arr)
            {
                ResizeKeyboard = true
            };
            return replyKeyboardMarkup;
        }
        public ReplyKeyboardMarkup GetCurrensiesKeyBoard(IEnumerable<string> names)
        {
            Queue<string> items = new Queue<string>(names);

            double numberOfkeybords = Math.Ceiling((double)names.Count()/5);
            List<List<KeyboardButton>> keyboard = new List<List<KeyboardButton>>((int)numberOfkeybords);
            for (int i = 0; i < numberOfkeybords; i++)
            {
                List<KeyboardButton> keyboardButtons = new List<KeyboardButton>();
                for (int j = 0; j < 5; j++)
                {
                    if(items.Count > 0)
                    {
                        keyboardButtons.Add(items.Dequeue());
                    }
                }
                keyboard.Add(keyboardButtons);
            }

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboard)
            {
                ResizeKeyboard = true
            };

            return replyKeyboardMarkup;
            
        }
    }
}
