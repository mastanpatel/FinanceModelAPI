using System;
using System.Collections.Generic;

#nullable disable

namespace stock.Data.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyQuarterDetails = new HashSet<CompanyQuarterDetail>();
            DailyStocks = new HashSet<DailyStock>();
        }

        public int CompanyId { get; set; }
        public string Isin { get; set; }
        public string Symbol { get; set; }
        public string AssetType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
        public DateTime? ListingDate { get; set; }
        public decimal? PaidUpValue { get; set; }
        public int? MarketLot { get; set; }
        public decimal? FaceValue { get; set; }
        public bool? IsActive { get; set; }
        public string Country { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Address { get; set; }

        public virtual ICollection<CompanyQuarterDetail> CompanyQuarterDetails { get; set; }
        public virtual ICollection<DailyStock> DailyStocks { get; set; }
    }
}
