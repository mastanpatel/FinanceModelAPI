using System;
using System.Collections.Generic;

#nullable disable

namespace stock.Data.Models
{
    public partial class CompanyQuarterDetail
    {
        public int ComanyDetailsId { get; set; }
        public string YearMonth { get; set; }
        public int? QuarterId { get; set; }
        public int? CompanyId { get; set; }
        public string FiscalYearEnd { get; set; }
        public DateTime? LatestQuarter { get; set; }
        public int? MarketCapitalization { get; set; }
        public int? Ebitda { get; set; }
        public decimal? Peratio { get; set; }
        public decimal? Pegratio { get; set; }
        public decimal? BookValue { get; set; }
        public decimal? DividendPerShare { get; set; }
        public decimal? DividendYield { get; set; }
        public decimal? Eps { get; set; }
        public decimal? RevenuePerShareTtm { get; set; }
        public decimal? ProfitMargin { get; set; }
        public decimal? OperatingMarginTtm { get; set; }
        public decimal? ReturnOnAssetsTtm { get; set; }
        public decimal? ReturnOnEquityTtm { get; set; }
        public int? RevenueTtm { get; set; }
        public int? GrossProfitTtm { get; set; }
        public decimal? DilutedEpsttm { get; set; }
        public decimal? QuarterlyEarningsGrowthYoy { get; set; }
        public decimal? QuarterlyRevenueGrowthYoy { get; set; }
        public decimal? AnalystTargetPrice { get; set; }
        public decimal? TrailingPe { get; set; }
        public decimal? ForwardPe { get; set; }
        public decimal? PriceToSalesRatioTtm { get; set; }
        public decimal? PriceToBookRatio { get; set; }
        public decimal? EvtoRevenue { get; set; }
        public decimal? EvtoEbitda { get; set; }
        public decimal? Beta { get; set; }
        public decimal? Week52High { get; set; }
        public decimal? Week52Low { get; set; }
        public decimal? Day50MovingAverage { get; set; }
        public decimal? Day200MovingAverage { get; set; }
        public int? SharesOutstanding { get; set; }
        public int? SharesFloat { get; set; }
        public int? SharesShort { get; set; }
        public int? SharesShortPriorMonth { get; set; }
        public decimal? ShortRatio { get; set; }
        public decimal? ShortPercentOutstanding { get; set; }
        public decimal? ShortPercentFloat { get; set; }
        public decimal? PercentInsiders { get; set; }
        public decimal? PercentInstitutions { get; set; }
        public decimal? ForwardAnnualDividendRate { get; set; }
        public decimal? ForwardAnnualDividendYield { get; set; }
        public decimal? PayoutRatio { get; set; }
        public DateTime? DividendDate { get; set; }
        public DateTime? ExDividendDate { get; set; }
        public string LastSplitFactor { get; set; }
        public DateTime? LastSplitDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual QuarterDetail Quarter { get; set; }
    }
}
