using HackathonTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TgBot.Models;
using static System.Net.WebRequestMethods;

namespace TgBot
{
    internal class InfoService
    {
        private string baseAdress = "https://localhost:7057/api/";

        public async Task<IEnumerable<string>> GetBanks()
        {
            Sender sender = new Sender();
            return await sender.SendRequest<IEnumerable<string>>(baseAdress + "banks");
        }

        public async Task<IEnumerable<string>> GetCurrencies(string bankName)
        {
            Sender sender = new Sender();
            return await sender.SendRequest<IEnumerable<string>>(baseAdress + $"banks/{bankName}/currencies/");
        }

        public async Task<string> GetRate(string bankName, string cur)
        {
            string nowDate = DateTime.Now.ToString("yyyy'.'MM'.'dd");

            Sender sender = new Sender();
            var rate = await sender.SendRequest<RateModel>(baseAdress + $"banks/rate/{bankName}/{cur}/{nowDate}");
            
            return $"{rate.Name}\n" +
                $"покупка : {rate.buyRate}\n" +
                $"продажа : {rate.sellRate}";
        }
    }
}
