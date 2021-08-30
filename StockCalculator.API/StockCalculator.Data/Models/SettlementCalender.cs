using System;
using System.Collections.Generic;

#nullable disable

namespace StockCalculator.Data.Models
{
    public partial class SettlementCalender
    {
        public int SettlementCalenderId { get; set; }
        public string YearMonth { get; set; }
        public string SettlementType { get; set; }
        public int SettlementNo { get; set; }
        public DateTime? TradeStartDate { get; set; }
        public DateTime? TradeEndDate { get; set; }
        public DateTime? CustodialConfirmationDate { get; set; }
        public DateTime? SettlementDate { get; set; }
    }
}
