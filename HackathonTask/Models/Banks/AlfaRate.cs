namespace HackathonTask.Models.AlfaBank
{
    public class AlfaRates
    {
        public AlfaRate[] Rates { get; set; }
    }

    public class AlfaRate
    {
        public decimal sellRate { get; set; }
        public string sellIso { get; set; }
        public int sellCode { get; set; }
        public decimal buyRate { get; set; }
        public string buyIso { get; set; }
        public int buyCode { get; set; }
        public int quantity { get; set; }
        public string name { get; set; }
        public string date { get; set; }
    }

}
