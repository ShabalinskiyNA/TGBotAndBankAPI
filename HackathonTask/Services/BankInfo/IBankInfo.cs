using HackathonTask.Models.MyApp;

namespace HackathonTask.Services.BankInfo
{
    public interface IBankInfo
    {
        public string BankName { get; }
        public Task<IEnumerable<string>> GetAvailableCurrencies();
        public Task<RateModel> GetRateByDate(string sellCurrensy, DateTime date);


    }
}
