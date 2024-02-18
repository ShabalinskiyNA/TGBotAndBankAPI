using HackathonTask.Models.MyApp;
using HackathonTask.Services.BankInfo;
using HackathonTask.Services.Interfaces;

namespace HackathonTask.Services
{
    public class BanksService : IBankService 
    {
        public List<IBankInfo> Banks { get; }
       

        public BanksService() 
        { 
            Banks = new List<IBankInfo>() 
            { 
                new AlfaBankInfo(), 
                new BelarusBankInfo(), 
                new NationalBankInfo() 
            };        
        }

        public IEnumerable<string> GetAvailiableBanksNames()
        {
            string[] result = new string[Banks.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Banks[i].BankName;
            }
            return result;
        }

        public async Task<IEnumerable<string>> GetCurrencies(string bankName)
        {            
            var bank = Banks.Where(x => x.BankName == bankName).FirstOrDefault();
            return await bank.GetAvailableCurrencies();
        }

        public async Task<RateModel> GetByDate(string bankName, string cur, DateTime date)
        {
            var bank = Banks.Where(x => x.BankName == bankName).FirstOrDefault();
            return await bank.GetRateByDate(cur, date);
        }
    }
}
