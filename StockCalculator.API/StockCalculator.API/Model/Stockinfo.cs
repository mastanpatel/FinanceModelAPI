namespace StockCalculator.API.Model
{
    public class Stockinfo
    {
        public string Information { get; set; }
        public string Symbol { get; set; }
        public string LastRefreshed { get; set; }
        public string OutputSize { get; set; }
        public string TimeZone { get; set; }

    }
}


//{
//    "Meta Data": {
//        "1. Information": "Daily Time Series with Splits and Dividend Events",
//        "2. Symbol": "RELIANCE.BSE",
//        "3. Last Refreshed": "2021-07-26",
//        "4. Output Size": "Full size",
//        "5. Time Zone": "US/Eastern"
//    },
//    "Time Series (Daily)": {
//        "2021-07-26": {
//            "1. open": "2110.0",
//            "2. high": "2121.6001",
//            "3. low": "2071.7",
//            "4. close": "2077.7",
//            "5. adjusted close": "2077.7",
//            "6. volume": "378150",
//            "7. dividend amount": "0.0000",
//            "8. split coefficient": "1.0"
//        },