using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace stock.Data.Models.CsvModels
{
    public class CsvDailyTrade
    {
        [Name("Symbol")]
        public string Symbol { get; set; }

        [Name("Series")]
        public string Series { get; set; }

        [Name("Date")]
        public DateTime Date { get; set; }

        [Name("Prev Close")]
        public decimal? PrevClose { get; set; }

        [Name("Open Price")]
        public decimal? OpenPrice { get; set; }

        [Name("High Price")]
        public decimal? HighPrice { get; set; }

        [Name("Low Price")]
        public decimal? LowPrice { get; set; }

        [Name("Last Price")]
        public decimal? LastPrice { get; set; }

        [Name("Close Price")]
        public decimal? ClosePrice { get; set; }

        [Name("Average Price")]
        public decimal? AveragePrice { get; set; }

        [Name("Total Traded Quantity")]
        public int? TotalTradedQuantity { get; set; }

        [Name("Turnover")]
        public decimal? Turnover { get; set; }

        [Name("No. of Trades")]
        public int? TradesCount { get; set; }

        [Name("Deliverable Qty")]
        public string DeliverableQty { get; set; }

        [Name("% Dly Qt to Traded Qty")]
        public string PctDlyQttoTradedQty { get; set; }

    }
}

