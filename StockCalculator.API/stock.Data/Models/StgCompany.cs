using System;
using System.Collections.Generic;

#nullable disable

namespace stock.Data.Models
{
    public partial class StgCompany
    {
        public string StgId { get; set; }
        public string Isin { get; set; }
        public string Symbol { get; set; }
        public string AssetType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
        public DateTime? Listingdate { get; set; }
        public decimal? PaidUpValue { get; set; }
        public int? Marketlot { get; set; }
        public decimal? Facevalue { get; set; }
        public bool? IsActive { get; set; }
        public string Country { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Address { get; set; }
    }
}
