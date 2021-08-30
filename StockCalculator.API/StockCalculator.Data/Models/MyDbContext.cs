using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StockCalculator.Data.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyQuarterDetail> CompanyQuarterDetails { get; set; }
        public virtual DbSet<DailyStock> DailyStocks { get; set; }
        public virtual DbSet<DataFile> DataFiles { get; set; }
        public virtual DbSet<DataFileManager> DataFileManagers { get; set; }
        public virtual DbSet<QuarterDetail> QuarterDetails { get; set; }
        public virtual DbSet<SettlementCalender> SettlementCalenders { get; set; }
        public virtual DbSet<StgCompany> StgCompanies { get; set; }
        public virtual DbSet<StgDailyStock> StgDailyStocks { get; set; }
        public virtual DbSet<VCompaniesDailyStock> VCompaniesDailyStocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-R3MPILK;Database=StockCalculator;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Adjusted52WeekHigh)
                    .HasColumnType("money")
                    .HasColumnName("Adjusted_52_Week_High");

                entity.Property(e => e.Adjusted52WeekLow)
                    .HasColumnType("money")
                    .HasColumnName("Adjusted_52_Week_Low");

                entity.Property(e => e.AssetType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Exchange)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FaceValue).HasColumnType("money");

                entity.Property(e => e.Industry)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Isin)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISIN");

                entity.Property(e => e.ListingDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PaidUpValue).HasColumnType("money");

                entity.Property(e => e.Sector)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Week52HighDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Week_52_High_Date");

                entity.Property(e => e.Week52LowDt)
                    .HasColumnType("datetime")
                    .HasColumnName("Week_52_Low_DT");
            });

            modelBuilder.Entity<CompanyQuarterDetail>(entity =>
            {
                entity.HasKey(e => e.ComanyDetailsId)
                    .HasName("PK__CompanyQ__3BA228C7524C67AE");

                entity.Property(e => e.ComanyDetailsId).HasColumnName("ComanyDetailsID");

                entity.Property(e => e.AnalystTargetPrice).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.Beta).HasColumnType("numeric(30, 3)");

                entity.Property(e => e.BookValue).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Day200MovingAverage).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.Day50MovingAverage).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.DilutedEpsttm)
                    .HasColumnType("numeric(30, 2)")
                    .HasColumnName("DilutedEPSTTM");

                entity.Property(e => e.DividendDate).HasColumnType("date");

                entity.Property(e => e.DividendPerShare).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.DividendYield).HasColumnType("numeric(30, 4)");

                entity.Property(e => e.Eps)
                    .HasColumnType("numeric(30, 2)")
                    .HasColumnName("EPS");

                entity.Property(e => e.EvtoEbitda)
                    .HasColumnType("numeric(30, 2)")
                    .HasColumnName("EVToEBITDA");

                entity.Property(e => e.EvtoRevenue)
                    .HasColumnType("numeric(30, 3)")
                    .HasColumnName("EVToRevenue");

                entity.Property(e => e.ExDividendDate).HasColumnType("date");

                entity.Property(e => e.FiscalYearEnd)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ForwardAnnualDividendRate).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.ForwardAnnualDividendYield).HasColumnType("numeric(30, 4)");

                entity.Property(e => e.ForwardPe)
                    .HasColumnType("numeric(30, 1)")
                    .HasColumnName("ForwardPE");

                entity.Property(e => e.GrossProfitTtm).HasColumnName("GrossProfitTTM");

                entity.Property(e => e.LastSplitDate).HasColumnType("date");

                entity.Property(e => e.LastSplitFactor)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LatestQuarter).HasColumnType("date");

                entity.Property(e => e.OperatingMarginTtm)
                    .HasColumnType("numeric(30, 3)")
                    .HasColumnName("OperatingMarginTTM");

                entity.Property(e => e.PayoutRatio).HasColumnType("numeric(30, 3)");

                entity.Property(e => e.Pegratio)
                    .HasColumnType("numeric(30, 3)")
                    .HasColumnName("PEGRatio");

                entity.Property(e => e.Peratio)
                    .HasColumnType("numeric(30, 2)")
                    .HasColumnName("PERatio");

                entity.Property(e => e.PercentInsiders).HasColumnType("numeric(30, 3)");

                entity.Property(e => e.PercentInstitutions).HasColumnType("numeric(30, 1)");

                entity.Property(e => e.PriceToBookRatio).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.PriceToSalesRatioTtm)
                    .HasColumnType("numeric(30, 3)")
                    .HasColumnName("PriceToSalesRatioTTM");

                entity.Property(e => e.ProfitMargin).HasColumnType("numeric(30, 4)");

                entity.Property(e => e.QuarterId).HasColumnName("QuarterID");

                entity.Property(e => e.QuarterlyEarningsGrowthYoy)
                    .HasColumnType("numeric(30, 3)")
                    .HasColumnName("QuarterlyEarningsGrowthYOY");

                entity.Property(e => e.QuarterlyRevenueGrowthYoy)
                    .HasColumnType("numeric(30, 3)")
                    .HasColumnName("QuarterlyRevenueGrowthYOY");

                entity.Property(e => e.ReturnOnAssetsTtm)
                    .HasColumnType("numeric(30, 4)")
                    .HasColumnName("ReturnOnAssetsTTM");

                entity.Property(e => e.ReturnOnEquityTtm)
                    .HasColumnType("numeric(30, 3)")
                    .HasColumnName("ReturnOnEquityTTM");

                entity.Property(e => e.RevenuePerShareTtm)
                    .HasColumnType("numeric(30, 1)")
                    .HasColumnName("RevenuePerShareTTM");

                entity.Property(e => e.RevenueTtm).HasColumnName("RevenueTTM");

                entity.Property(e => e.ShortPercentFloat).HasColumnType("numeric(30, 4)");

                entity.Property(e => e.ShortPercentOutstanding).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.ShortRatio).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.TrailingPe)
                    .HasColumnType("numeric(30, 2)")
                    .HasColumnName("TrailingPE");

                entity.Property(e => e.Week52High).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.Week52Low).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.YearMonth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyQuarterDetails)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__CompanyQu__Compa__571DF1D5");

                entity.HasOne(d => d.Quarter)
                    .WithMany(p => p.CompanyQuarterDetails)
                    .HasForeignKey(d => d.QuarterId)
                    .HasConstraintName("FK__CompanyQu__Quart__5812160E");
            });

            modelBuilder.Entity<DailyStock>(entity =>
            {
                entity.HasKey(e => e.DailyStocksId)
                    .HasName("PK__DailySto__B9BC47478F10C377");

                entity.Property(e => e.DailyStocksId).HasColumnName("DailyStocksID");

                entity.Property(e => e.AveragePrice).HasColumnType("money");

                entity.Property(e => e.ClosePrice).HasColumnType("money");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.HighPrice).HasColumnType("money");

                entity.Property(e => e.LastPrice).HasColumnType("money");

                entity.Property(e => e.LowPrice).HasColumnType("money");

                entity.Property(e => e.OpenPrice).HasColumnType("money");

                entity.Property(e => e.PctDlyQttoTradedQty).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PrevClose).HasColumnType("money");

                entity.Property(e => e.Series)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Turnover).HasColumnType("money");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.DailyStocks)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__DailyStoc__Compa__74AE54BC");
            });

            modelBuilder.Entity<DataFile>(entity =>
            {
                entity.ToTable("DataFile");

                entity.Property(e => e.DataFileId).HasColumnName("DataFileID");

                entity.Property(e => e.ChildId).HasColumnName("ChildID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DataFileDesc)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.DataFileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataFileType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsEnable).HasColumnName("isEnable");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<DataFileManager>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DataFileManager");

                entity.Property(e => e.DataFileId).HasColumnName("DataFileID");

                entity.Property(e => e.DataFileManagerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DataFileManagerID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DownloadLink).IsUnicode(false);

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FilePath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("filePath");

                entity.Property(e => e.YearMonth)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.DataFile)
                    .WithMany()
                    .HasForeignKey(d => d.DataFileId)
                    .HasConstraintName("FK__DataFileM__DataF__3F115E1A");
            });

            modelBuilder.Entity<QuarterDetail>(entity =>
            {
                entity.HasKey(e => e.QuarterId)
                    .HasName("PK__QuarterD__1D2BD182B2D75185");

                entity.Property(e => e.QuarterId).HasColumnName("QuarterID");

                entity.Property(e => e.CreatedTimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.QuarterName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SettlementCalender>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("settlementCalender");

                entity.Property(e => e.CustodialConfirmationDate).HasColumnType("datetime");

                entity.Property(e => e.SettlementCalenderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("settlementCalenderID");

                entity.Property(e => e.SettlementDate).HasColumnType("datetime");

                entity.Property(e => e.SettlementType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TradeEndDate).HasColumnType("datetime");

                entity.Property(e => e.TradeStartDate).HasColumnType("datetime");

                entity.Property(e => e.YearMonth)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StgCompany>(entity =>
            {
                entity.HasKey(e => new { e.StgId, e.Isin })
                    .HasName("PK__stgCompa__562A45172BDE45D7");

                entity.ToTable("stgCompanies");

                entity.Property(e => e.StgId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("stg_Id");

                entity.Property(e => e.Isin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISIN");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Adjusted_52_Week_High)
                    .HasColumnType("money")
                    .HasColumnName("Adjusted_52_Week_High");

                entity.Property(e => e.Adjusted_52_Week_Low)
                    .HasColumnType("money")
                    .HasColumnName("Adjusted_52_Week_Low");

                entity.Property(e => e.AssetType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Exchange)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Facevalue)
                    .HasColumnType("money")
                    .HasColumnName("FACEVALUE");

                entity.Property(e => e.Industry)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Listingdate)
                    .HasColumnType("date")
                    .HasColumnName("LISTINGDate");

                entity.Property(e => e.Marketlot).HasColumnName("MARKETLOT");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PaidUpValue).HasColumnType("money");

                entity.Property(e => e.Sector)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Week_52_High_Date)
                    .HasColumnType("datetime")
                    .HasColumnName("Week_52_High_Date");

                entity.Property(e => e.Week_52_Low_Dt)
                    .HasColumnType("datetime")
                    .HasColumnName("Week_52_Low_DT");
            });

            modelBuilder.Entity<StgDailyStock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stgDailyStocks");

                entity.Property(e => e.AveragePrice).HasColumnType("money");

                entity.Property(e => e.ClosePrice).HasColumnType("money");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.HighPrice).HasColumnType("money");

                entity.Property(e => e.LastPrice).HasColumnType("money");

                entity.Property(e => e.LowPrice).HasColumnType("money");

                entity.Property(e => e.OpenPrice).HasColumnType("money");

                entity.Property(e => e.PctDlyQttoTradedQty).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PrevClose).HasColumnType("money");

                entity.Property(e => e.Series)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StgId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("stgID");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Turnover).HasColumnType("money");
            });

            modelBuilder.Entity<VCompaniesDailyStock>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vCompaniesDailyStock");

                entity.Property(e => e.AveragePrice).HasColumnType("money");

                entity.Property(e => e.Change).HasColumnType("money");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FaceValue).HasColumnType("money");

                entity.Property(e => e.HighPrice).HasColumnType("money");

                entity.Property(e => e.Industry)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Isin)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISIN");

                entity.Property(e => e.LastPrice).HasColumnType("money");

                entity.Property(e => e.ListingDate).HasColumnType("date");

                entity.Property(e => e.LowPrice).HasColumnType("money");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OpenPrice).HasColumnType("money");

                entity.Property(e => e.PaidUpValue).HasColumnType("money");

                entity.Property(e => e.PctChange).HasColumnType("money");

                entity.Property(e => e.PrevClose).HasColumnType("money");

                entity.Property(e => e.Sector)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Series)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Turnover).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
