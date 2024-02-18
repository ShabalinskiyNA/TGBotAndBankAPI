using HackathonTask.Models.AlfaBank;
using HackathonTask.Models.Banks;
using HackathonTask.Models.MyApp;
using System.Data;

namespace HackathonTask.Services.BankInfo
{
    public class NationalBankInfo : IBankInfo
    {
        public string BankName { get { return "NationalBank"; } }
        private string currenciesAddres = "https://api.nbrb.by/exrates/currencies";
        

        public async Task<IEnumerable<string>> GetAvailableCurrencies()
        {
            List<string> result = new List<string>();
            DateTime dateNow = DateTime.Now;
            
            Sender sender = new Sender();
            var response = await sender.SendRequest<IEnumerable<NBCurrencies>>(currenciesAddres);
            

            foreach (var item in response)
            {
                if (item.Cur_DateEnd > dateNow)
                {
                    result.Add(item.Cur_Abbreviation);
                }

            }
            return result;
        }

        public async Task<RateModel> GetRateByDate(string sellCurrensy, DateTime date)
        {
            int rateId = await GetIdByAbbreviation(sellCurrensy);
            string ratesAddres = $"https://api.nbrb.by/exrates/rates/{rateId}";

            

            Sender sender = new Sender();
            var response = await sender.SendRequest<NBRate>(ratesAddres);

            RateModel resultRate = new RateModel()
            {
                Name = response.Cur_Scale + " " + response.Cur_Abbreviation,
                sellRate = response.Cur_OfficialRate,
                buyRate = 0                
            };

            return resultRate;
        }

        private async Task<int> GetIdByAbbreviation(string abbreviation) 
        {
            int resultId = 0;
            DateTime dateNow = DateTime.Now;

            Sender sender = new Sender();
            var response = await sender.SendRequest<IEnumerable<NBCurrencies>>(currenciesAddres);


            foreach (var item in response)
            {                
                if (item.Cur_Abbreviation == abbreviation )
                {
                    if (item.Cur_DateEnd > dateNow)
                    {
                        resultId = item.Cur_ID;
                    }                    
                }
            }

            return resultId;
        }
    }
}
