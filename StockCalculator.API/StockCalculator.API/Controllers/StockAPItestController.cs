using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StockCalculator.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockCalculator.API.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("{controller}/{action=Index}/{id?}")]
    public class StockAPItestController : ControllerBase
    {
        private StockDetails GetStockDetails()
        {
            // replace the "demo" apikey below with your own key from https://www.alphavantage.co/support/#api-key
            string QUERY_URL = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=RELIANCE.BSE&outputsize=full&apikey=demo";
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {

                var json_data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, dynamic>>(client.DownloadString(queryUri));

                StockDetails stocksDetails = new StockDetails();
                List<Stockinfo> stockInfoList = new List<Stockinfo>();
                List<Stock> stockDic = new List<Stock>();

                foreach (var item in json_data)
                {
                    if (item.Key == "Meta Data")
                    {
                      
                        var b = item.Value.ToString();
                        string CleanedString = Regex.Replace(b, "1. Information", "Information");
                        CleanedString = Regex.Replace(CleanedString, "2. Symbol", "Symbol");
                        CleanedString = Regex.Replace(CleanedString, "3. Last Refreshed", "LastRefreshed");
                        CleanedString = Regex.Replace(CleanedString, "4. Output Size", "OutputSize");
                        CleanedString = Regex.Replace(CleanedString, "5. Time Zone", "TimeZone");


                        Stockinfo stockInfo = System.Text.Json.JsonSerializer.Deserialize<Stockinfo>(CleanedString);
                        stockInfoList.Add(stockInfo);
                    }
                    if (item.Key == "Time Series (Daily)")
                    {
                        var b = item.Value.ToString();
                        string CleanedString = Regex.Replace(b, "1. open", "open");
                        CleanedString = Regex.Replace(CleanedString, "2. high", "high");
                        CleanedString = Regex.Replace(CleanedString, "3. low", "low");
                        CleanedString = Regex.Replace(CleanedString, "4. close", "close");
                        CleanedString = Regex.Replace(CleanedString, "5. adjusted close", "adjusted_close");
                        CleanedString = Regex.Replace(CleanedString, "6. volume", "volume");
                        CleanedString = Regex.Replace(CleanedString, "7. dividend amount", "dividend_amount");
                        CleanedString = Regex.Replace(CleanedString, "8. split coefficient", "split_coefficient");

                        var blist = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(CleanedString);

                        foreach (var stock in blist)
                        {
                            Stock stockList = System.Text.Json.JsonSerializer.Deserialize<Stock>(stock.Value.ToString());

                            stockList.TradeDate = stock.Key;

                            stockDic.Add(stockList);
                            //stockDic.Add(stock.Key, stockList);
                        }
                    }
                    
                }

                stocksDetails.StockInfo = stockInfoList;
                stocksDetails.Stocks = stockDic;

                return stocksDetails;
            }
        }

        public string GetDailyStock()
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=RELIANCE.BSE&apikey=demo";
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {

                dynamic json_data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, dynamic>>(client.DownloadString(queryUri));

            }

            return "";
        } 

        [HttpGet]
        public string index()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(GetStockDetails());
        }

        [HttpGet]
        public string GetStockInfo()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(GetStockDetails().StockInfo);
        }

        [HttpGet]
        public string GetStockValues()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(GetStockDetails().Stocks);
        }
    }
}
