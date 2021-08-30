using StockCalculator.Data.Models.CsvModels;
using StockCalculator.Data.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace StockCalculator.DataService
{
    class Program
    {
        static void Main(string[] args)
        {

            ExcelRepository excelData = new ExcelRepository();
            SqlRepository sqlData = new SqlRepository();
            //@"C:\Users\mmast\OneDrive\Desktop\stock.csv"

            // IEnumerable<CsvCompanies> csvData = excelData.getCSVCompanyData(@"C:\Users\mmast\OneDrive\Desktop\stock.csv");

            //Console.WriteLine(sqlData.AddCompanyToDb(csvData));

            IEnumerable<CsvDailyTradeUpdate> csvData;

            IEnumerable<High_Low_52> HighLow52;

            string[] filePaths = Directory.GetFiles(@"F:\NSE Data", "*.csv",
                                         SearchOption.TopDirectoryOnly);

            string FileName = string.Empty;
            string rootPath = @"F:\Done\";

            foreach (string filepath in filePaths)
            {
                FileName = Path.GetFileName(filepath);

                //
                //csvData = excelData.getCSVDailyTradeData(filepath);
                //csvData = excelData.getCSVDailyTradeUpdateData(filepath);

                HighLow52 = excelData.getHighLow52(filepath);

               // Console.WriteLine(sqlData.AddDailyTradeUpdateToDb(csvData));

                Console.WriteLine(sqlData.AddHighLow52ToDb(HighLow52));


                File.Move(filepath, rootPath + FileName);
            }


            //https://archives.nseindia.com/content/historical/EQUITIES/2021/Aug/cm02Aug2021Bhav.csv.zip

            //WebClient Client = new WebClient();
            //Client.DownloadFile("https://archives.nseindia.com/content/historical/EQUITIES/2021/Aug/cm02Aug2021Bhav.csv.zip", @"F:\NSE Data\cm02Aug2021Bhav.zip");


            //using (WebClient client = new WebClient())
            //{
            //    client.Proxy = null;
            //  //  client.DownloadFile("http://www.contoso.com/library/homepage/images/ms-banner.gif", @"F:\NSE Data\cm02Aug2021Bhav.gif");

            //    //client.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
            //    //client.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
            //    client.DownloadFileAsync(new Uri("https://archives.nseindia.com/content/equities/bulk.csv"), @"F:\NSE Data\File.csv");
            //}
        }
    }
}
