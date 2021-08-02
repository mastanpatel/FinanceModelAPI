using CsvHelper;
using CsvHelper.Configuration;
using StockCalculator.Data.Models.CsvModels;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace StockCalculator.Data.Repository
{
    public class ExcelRepository
    {
      
        public IEnumerable<CsvCompanies> getCSVCompanyData(string csvFilePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower().Trim(),
            };

            //read the file
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                var content = csv.GetRecords<CsvCompanies>().ToList();
                return content;
            }
        }

        public IEnumerable<CsvDailyTrade> getCSVDailyTradeData(string csvFilePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower().Trim(),
            };

            //read the file
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                var content = csv.GetRecords<CsvDailyTrade>().ToList();
                return content;
            }
        }

        public IEnumerable<CsvDailyTradeUpdate> getCSVDailyTradeUpdateData(string csvFilePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower().Trim(),
            };

            //read the file
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                var content = csv.GetRecords<CsvDailyTradeUpdate>().ToList();
                return content;
            }
        }


    }
}
