using HackathonTask.Models.AlfaBank;
using HackathonTask.Models.Banks;
using HackathonTask.Models.MyApp;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HackathonTask.Services.BankInfo
{
    public class BelarusBankInfo : IBankInfo
    {
        public string BankName { get { return "BelarusBank"; } }
        private string currenciesAddres = "https://belarusbank.by/api/kurs_cards";
        public async Task<IEnumerable<string>> GetAvailableCurrencies()
        {
            return new List<string>() { "USD", "EUR", "RUB", "CNY" };
        }

        public async Task<RateModel> GetRateByDate(string sellCurrensy, DateTime date)
        {
            RateModel resultRate = new RateModel();
            DateTime bankDate;

            Sender sender = new Sender();
            var response = await sender.SendRequest<IEnumerable<BelarusbankRate>>(currenciesAddres);

            foreach (BelarusbankRate rate in response)
            {
                
                if (date >= rate.kurs_date_time)
                {
                    switch (sellCurrensy)
                    {
                        case "USD":
                            resultRate.Name = "1 USD";
                            resultRate.sellRate = rate.USDCARD_in;
                            resultRate.buyRate = rate.USDCARD_out;
                            break;

                        case "EUR":
                            resultRate.Name = "1 EUR";
                            resultRate.sellRate = rate.EURCARD_in;
                            resultRate.buyRate = rate.EURCARD_out;
                            break;

                        case "RUB":
                            resultRate.Name = "100 RUB";
                            resultRate.sellRate = rate.RUBCARD_in;
                            resultRate.buyRate = rate.RUBCARD_out;
                            break;

                        case "CNY":
                            resultRate.Name = "10 CNY";
                            resultRate.sellRate = rate.CNYCARD_in;
                            resultRate.buyRate = rate.CNYCARD_out;
                            break;
                        default:
                            resultRate.Name = "Валюта не найдена";
                            resultRate.sellRate = 0;
                            resultRate.buyRate = 0;
                            break;
                    }
                    break;
                }
            }

            return resultRate;
        }
    }
}
