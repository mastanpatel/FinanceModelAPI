using System;
using System.Collections.Generic;

#nullable disable

namespace stock.Data.Models
{
    public partial class StgDailyStock
    {
        public string StgId { get; set; }
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        public string Series { get; set; }
        public decimal? PrevClose { get; set; }
        public decimal? OpenPrice { get; set; }
        public decimal? HighPrice { get; set; }
        public decimal? LowPrice { get; set; }
        public decimal? LastPrice { get; set; }
        public decimal? ClosePrice { get; set; }
        public decimal? AveragePrice { get; set; }
        public int? TotalTradedQuantity { get; set; }
        public decimal? Turnover { get; set; }
        public int? TradesCount { get; set; }
        public int? DeliverableQty { get; set; }
        public decimal? PctDlyQttoTradedQty { get; set; }
        public string CreatedBy { get; set; }
    }
}
