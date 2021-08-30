using Microsoft.EntityFrameworkCore;
using StockCalculator.Data.Models;
using StockCalculator.Data.Models.CsvModels;
using System;
using System.Collections.Generic;
using EFCore.BulkExtensions;
using System.Linq;

namespace StockCalculator.Data.Repository
{
    public class SqlRepository
    {
        private StockCalculatorContext Context = new StockCalculatorContext();

        public string AddCompanyToDb(IEnumerable<CsvCompanies> companies)
        {
            var currentTimeStamp = DateTime.Now.ToString();

            foreach (CsvCompanies Csvcompany in companies)
            {
                StgCompany stgcompany = new StgCompany();
                stgcompany.StgId = currentTimeStamp;
                stgcompany.Symbol = Csvcompany.Symbol;
                stgcompany.Name = Csvcompany.Name;
                stgcompany.Isin = Csvcompany.Isin;
                stgcompany.Listingdate = Csvcompany.Listingdate;
                stgcompany.Marketlot = Csvcompany.Marketlot;
                stgcompany.PaidUpValue = Csvcompany.PaidUpValue;
                stgcompany.Exchange = Csvcompany.Exchange;
                stgcompany.Facevalue = Csvcompany.Facevalue;

                 Context.StgCompanies.Add(stgcompany);

                Context.SaveChanges();

            }


            return "companies added to staging.";
        }

        public string AddHighLow52ToDb(IEnumerable<High_Low_52> companies)
        {
            var currentTimeStamp = DateTime.Now.ToString();
            Random random = new Random();

            foreach (High_Low_52 Csvcompany in companies)
            {

                StgCompany stgcompany = new StgCompany();
                stgcompany.Isin = random.Next().ToString();
                stgcompany.StgId = currentTimeStamp;
                stgcompany.Symbol = Csvcompany.Symbol;
                stgcompany.Exchange = Csvcompany.Series;
                stgcompany.Adjusted_52_Week_High = Csvcompany.Adjusted52WeekHigh;
                stgcompany.Adjusted_52_Week_Low = Csvcompany.Adjusted52WeekLow;
                stgcompany.Week_52_High_Date = Csvcompany.Week52HighDate;
                stgcompany.Week_52_Low_Dt = Csvcompany.Week52LowDt;
               
                Context.StgCompanies.Add(stgcompany);

                Context.SaveChanges();

            }


            return "companies added to staging.";
        }

        public string AddDailyTradeToDb(IEnumerable<CsvDailyTrade> DailyTradeData)
        {
            var currentTimeStamp = DateTime.Now.ToString();

            List<StgDailyStock> dailyStockList = new List<StgDailyStock>();

            StgDailyStock stgDailyStock;
            foreach (CsvDailyTrade Csvtrade in DailyTradeData)
            {
                stgDailyStock = new StgDailyStock();

                stgDailyStock.StgId = currentTimeStamp;
                stgDailyStock.Symbol = Csvtrade.Symbol.Trim();
                stgDailyStock.Series = Csvtrade.Series.Trim();
                stgDailyStock.Date = Csvtrade.Date;
                stgDailyStock.PrevClose = Csvtrade.PrevClose;
                stgDailyStock.OpenPrice = Csvtrade.OpenPrice;
                stgDailyStock.HighPrice = Csvtrade.HighPrice;
                stgDailyStock.LowPrice = Csvtrade.LowPrice;
                stgDailyStock.LastPrice = Csvtrade.LastPrice;
                stgDailyStock.ClosePrice = Csvtrade.ClosePrice;
                stgDailyStock.AveragePrice = Csvtrade.AveragePrice;
                stgDailyStock.TotalTradedQuantity = Csvtrade.TotalTradedQuantity;
                stgDailyStock.Turnover = Csvtrade.Turnover;
                stgDailyStock.TradesCount = Csvtrade.TradesCount;
                stgDailyStock.DeliverableQty = (Csvtrade.DeliverableQty.Contains("-")) ? 0 : Convert.ToInt32(Csvtrade.DeliverableQty.Trim());
                stgDailyStock.PctDlyQttoTradedQty = (Csvtrade.PctDlyQttoTradedQty.Contains("-")) ? 0 : Convert.ToDecimal(Csvtrade.PctDlyQttoTradedQty.Trim());



                dailyStockList.Add(stgDailyStock);
                
            }
            Context.BulkInsert(dailyStockList);

            Context.Database.ExecuteSqlRaw("dbo.stp_stgToMainDailyStock @stgId = {0}", currentTimeStamp);

            return "daily trade added to staging.";
        }

        public string AddDailyTradeUpdateToDb(IEnumerable<CsvDailyTradeUpdate> DailyTradeData)
        {
            var currentTimeStamp = DateTime.Now.ToString();

            List<StgDailyStock> dailyStockList = new List<StgDailyStock>();

            StgDailyStock stgDailyStock;
            foreach (CsvDailyTradeUpdate Csvtrade in DailyTradeData)
            {
                stgDailyStock = new StgDailyStock();

                stgDailyStock.StgId = currentTimeStamp;
                stgDailyStock.Symbol = Csvtrade.Symbol.Trim();
                stgDailyStock.Series = Csvtrade.Series.Trim();
                stgDailyStock.Date = Csvtrade.Date;
                stgDailyStock.PrevClose = Csvtrade.PrevClose;
                stgDailyStock.OpenPrice = Csvtrade.OpenPrice;
                stgDailyStock.HighPrice = Csvtrade.HighPrice;
                stgDailyStock.LowPrice = Csvtrade.LowPrice;
                stgDailyStock.LastPrice = Csvtrade.LastPrice;
                stgDailyStock.ClosePrice = Csvtrade.ClosePrice;
                stgDailyStock.TotalTradedQuantity = Csvtrade.TotalTradedQuantity;
                stgDailyStock.Turnover = Csvtrade.Turnover;
                stgDailyStock.TradesCount = Csvtrade.TradesCount;



                dailyStockList.Add(stgDailyStock);

            }
            Context.BulkInsert(dailyStockList);

            Context.Database.ExecuteSqlRaw("dbo.stp_stgToMainDailyStock @stgId = {0}", currentTimeStamp);

            return "daily trade added to staging.";
        }

        public string UpdateDailytradeToDb(IEnumerable<CsvDailyTradeUpdate> DailyTradeData)
        {
            var currentTimeStamp = DateTime.Now.ToString();

            List<StgDailyStock> dailyStockList = new List<StgDailyStock>();

            StgDailyStock stgDailyStock;

            foreach (CsvDailyTradeUpdate Csvtrade in DailyTradeData)
            {
                stgDailyStock = new StgDailyStock();

                stgDailyStock.StgId = currentTimeStamp;
                stgDailyStock.Symbol = Csvtrade.Symbol.Trim();
                stgDailyStock.Series = Csvtrade.Series.Trim();
                stgDailyStock.Date = Csvtrade.Date;
                stgDailyStock.PrevClose = Csvtrade.PrevClose;
                stgDailyStock.OpenPrice = Csvtrade.OpenPrice;
                stgDailyStock.HighPrice = Csvtrade.HighPrice;
                stgDailyStock.LowPrice = Csvtrade.LowPrice;
                stgDailyStock.LastPrice = Csvtrade.LastPrice;
                stgDailyStock.ClosePrice = Csvtrade.ClosePrice;
               // stgDailyStock.AveragePrice = Csvtrade.AveragePrice;
                stgDailyStock.TotalTradedQuantity = Csvtrade.TotalTradedQuantity;
                stgDailyStock.Turnover = Csvtrade.Turnover;
                stgDailyStock.TradesCount = Csvtrade.TradesCount;
              
                dailyStockList.Add(stgDailyStock);

            }
            Context.BulkInsert(dailyStockList);

            Context.Database.ExecuteSqlRaw("dbo.stp_stgToMainDailyStock @stgId = {0}", currentTimeStamp);


            return "updated data";
        }

        public List<VCompaniesDailyStock> GetComapniesDailyStocks(DateTime stockDate)
        {
            DateTime Date = Convert.ToDateTime(stockDate);
            return  Context.VCompaniesDailyStocks.FromSqlRaw("dbo.stp_getDailyStockData @stockDate = {0}", Date).ToList();

        }
    }
}
