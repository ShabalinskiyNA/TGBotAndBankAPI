namespace HackathonTask.Models.Banks
{    
    public class BelarusbankRates
    {
        public BelarusbankRate[] Rates { get; set; }
    }

    public class BelarusbankRate
    {
        public DateTime kurs_date_time { get; set; }
        public decimal USDCARD_in { get; set; }
        public decimal USDCARD_out { get; set; }
        public decimal EURCARD_in { get; set; }
        public decimal EURCARD_out { get; set; }
        public decimal RUBCARD_in { get; set; }
        public decimal RUBCARD_out { get; set; }
        public decimal CNYCARD_in { get; set; }
        public decimal CNYCARD_out { get; set; }
        public decimal USDCARD_EURCARD_in { get; set; }
        public decimal USDCARD_EURCARD_out { get; set; }
        public decimal USDCARD_RUBCARD_in { get; set; }
        public decimal USDCARD_RUBCARD_out { get; set; }
        public decimal RUBCARD_EURCARD_out { get; set; }
        public decimal RUBCARD_EURCARD_in { get; set; }
        public decimal CNYCARD_USDCARD_in { get; set; }
        public decimal CNYCARD_USDCARD_out { get; set; }
        public decimal CNYCARD_EURCARD_in { get; set; }
        public decimal CNYCARD_EURCARD_out { get; set; }
        public decimal CNYCARD_RUBCARD_in { get; set; }
        public decimal CNYCARD_RUBCARD_out { get; set; }
    }

}
