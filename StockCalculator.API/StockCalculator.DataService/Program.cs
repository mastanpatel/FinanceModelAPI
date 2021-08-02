using StockCalculator.Data.Models.CsvModels;
using StockCalculator.Data.Repository;
using System;
using System.Collections.Generic;
using System.IO;

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

            string[] filePaths = Directory.GetFiles(@"F:\NSE Data", "*.csv",
                                         SearchOption.TopDirectoryOnly);

            string FileName = string.Empty;
            string rootPath = @"F:\Done\";

            foreach (string filepath in filePaths)
            {
                FileName = Path.GetFileName(filepath);

                //
                //csvData = excelData.getCSVDailyTradeData(filepath);
                csvData = excelData.getCSVDailyTradeUpdateData(filepath);

                Console.WriteLine(sqlData.AddDailyTradeUpdateToDb(csvData));
                //


                File.Move(filepath, rootPath + FileName);
            }
        }
    }
}
