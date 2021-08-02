using Microsoft.EntityFrameworkCore;
using stock.Data.Models;
using stock.Data.Models.CsvModels;
using System;
using System.Collections.Generic;
using EFCore.BulkExtensions;

namespace stock.Data.Repository
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
    }
}
