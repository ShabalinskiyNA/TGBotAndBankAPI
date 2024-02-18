using HackathonTask.Models.MyApp;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace HackathonTask.Services.Interfaces
{
    public interface IBankService
    {
        public IEnumerable<string> GetAvailiableBanksNames();
        public Task<IEnumerable<string>> GetCurrencies(string bankName);
        public Task<RateModel> GetByDate(string bankName, string cur, DateTime date);

    }
}
