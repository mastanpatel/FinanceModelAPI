using System;
using System.Collections.Generic;

#nullable disable

namespace StockCalculator.Data.Models
{
    public partial class VCompaniesDailyStock
    {
        public int CompanyId { get; set; }
        public string Isin { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public DateTime? ListingDate { get; set; }
        public string Description { get; set; }
        public decimal? FaceValue { get; set; }
        public int? MarketLot { get; set; }
        public string Industry { get; set; }
        public bool? IsActive { get; set; }
        public decimal? PaidUpValue { get; set; }
        public string Sector { get; set; }
        public DateTime? Date { get; set; }
        public decimal? LastPrice { get; set; }
        public decimal? OpenPrice { get; set; }
        public decimal? AveragePrice { get; set; }
        public decimal? HighPrice { get; set; }
        public decimal? LowPrice { get; set; }
        public decimal? PrevClose { get; set; }
        public int? TradesCount { get; set; }
        public decimal? Turnover { get; set; }
        public decimal? Change { get; set; }
        public decimal? PctChange { get; set; }
    }
}
