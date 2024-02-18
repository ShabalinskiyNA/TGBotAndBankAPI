using HackathonTask.Models.AlfaBank;
using HackathonTask.Models.MyApp;

namespace HackathonTask.Services.BankInfo
{
    public class AlfaBankInfo : IBankInfo
    {
        private string currenciesAddres = "https://developerhub.alfabank.by:8273/partner/1.0.1/public/rates";
        public string BankName { get { return "AlfaBank"; } }


        public async Task<IEnumerable<string>> GetAvailableCurrencies()
        {
            Sender sender = new Sender();
            var response = await sender.SendRequest<AlfaRates>(currenciesAddres);
            List<string> alfaCurrencies = new List<string>();

            foreach (AlfaRate rate in response.Rates)
            {
                if (rate.buyIso == "BYN")
                {
                    alfaCurrencies.Add(rate.sellIso);
                }
            }

            return alfaCurrencies;
        }

        public async Task<RateModel> GetRateByDate(string sellCurrensy, DateTime date)
        {
            RateModel resultRate = new RateModel();

            Sender sender = new Sender();
            var response = await sender.SendRequest<AlfaRates>(currenciesAddres);

            foreach (AlfaRate rate in response.Rates)
            {
                if (rate.buyIso == "BYN" && rate.sellIso == sellCurrensy)
                {
                    DateTime bankDate;
                    DateTime.TryParse(rate.date, out bankDate);
                    if (date >= bankDate)
                    {
                        resultRate.Name = rate.quantity + " " + rate.sellIso;
                        resultRate.sellRate = rate.sellRate;
                        resultRate.buyRate = rate.buyRate;

                        break;
                    }

                }
            }

            return resultRate;
        }

    }
}
