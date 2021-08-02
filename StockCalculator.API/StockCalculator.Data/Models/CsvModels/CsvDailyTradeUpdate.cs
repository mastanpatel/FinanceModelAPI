using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCalculator.Data.Models.CsvModels
{
    public class CsvDailyTradeUpdate
    {
        [Name("SYMBOL")]
        public string Symbol { get; set; }

        [Name("SERIES")]
        public string Series { get; set; }

        [Name("TIMESTAMP")]
        public DateTime Date { get; set; }

        [Name("PREVCLOSE")]
        public decimal? PrevClose { get; set; }

        [Name("OPEN")]
        public decimal? OpenPrice { get; set; }

        [Name("HIGH")]
        public decimal? HighPrice { get; set; }

        [Name("LOW")]
        public decimal? LowPrice { get; set; }

        [Name("LAST")]
        public decimal? LastPrice { get; set; }

        [Name("CLOSE")]
        public decimal? ClosePrice { get; set; }

        [Name("TOTTRDQTY")]
        public int? TotalTradedQuantity { get; set; }

        [Name("TOTTRDVAL")]
        public decimal? Turnover { get; set; }

        [Name("TOTALTRADES")]
        public int? TradesCount { get; set; }


    }
}

