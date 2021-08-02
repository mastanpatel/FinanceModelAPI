using System;
using System.Collections.Generic;

#nullable disable

namespace StockCalculator.Data.Models
{
    public partial class QuarterDetail
    {
        public QuarterDetail()
        {
            CompanyQuarterDetails = new HashSet<CompanyQuarterDetail>();
        }

        public int QuarterId { get; set; }
        public string QuarterName { get; set; }
        public int? Year { get; set; }
        public int? Quarter { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte[] CreatedTimeStamp { get; set; }

        public virtual ICollection<CompanyQuarterDetail> CompanyQuarterDetails { get; set; }
    }
}
