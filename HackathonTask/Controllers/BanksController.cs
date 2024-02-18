using HackathonTask.Models.MyApp;
using HackathonTask.Services;
using HackathonTask.Services.BankInfo;
using HackathonTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackathonTask.Controllers
{
    [Route("api/banks")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private IBankService bankService;
        public BanksController(IBankService bankServ)
        {
            bankService = bankServ;
        }
        [HttpGet]
        public IEnumerable<string> AvailiableBanks() 
        {
            return bankService.GetAvailiableBanksNames();        
        }
        
        [HttpGet("{bankName}/currencies")]
        public Task<IEnumerable<string>> GetAvailableCurrencies(string bankName)
        {
            return bankService.GetCurrencies(bankName);            
        }

        [HttpGet("rate/{bankName}/{cur}/{date}")]
        public Task<RateModel> GetRateByDate(string bankName, string cur, DateTime date )
        {
            return bankService.GetByDate(bankName, cur, date);            
        }
    }
}
