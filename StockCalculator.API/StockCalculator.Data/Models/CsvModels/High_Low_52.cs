using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCalculator.Data.Models.CsvModels
{
    public class High_Low_52
    {

        [Name("SYMBOL")]
        public string Symbol { get; set; }

        [Name("SERIES")]
        public string Series { get; set; }

        [Name("Adjusted 52_Week_High")]
        public decimal? Adjusted52WeekHigh { get; set; }

        [Name("52_Week_High_Date")]
        public DateTime? Week52HighDate { get; set; }

        [Name("Adjusted 52_Week_Low")]
        public decimal? Adjusted52WeekLow { get; set; }

        [Name("52_Week_Low_DT")]
        public DateTime? Week52LowDt { get; set; }

    }
}
