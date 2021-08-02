using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace stock.Data.Models.CsvModels
{
    public class CsvCompanies
    {
        [Name("symbol")]
        public string Symbol { get; set; }

        [Name("name of company")]
        public string Name { get; set; }

        [Name("series")]
        public string Exchange { get; set; }

        [Name("date of listing")]
        public DateTime? Listingdate { get; set; }

        [Name("paid up value")]
        public decimal? PaidUpValue { get; set; }

        [Name("market lot")]
        public int? Marketlot { get; set; }

        [Name("isin number")]
        public string Isin { get; set; }

        [Name("face value")]
        public int Facevalue { get; set; }
     
    }
}
