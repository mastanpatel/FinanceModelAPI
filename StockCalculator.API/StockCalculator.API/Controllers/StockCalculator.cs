using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StockCalculator.Data.Repository;
using System;

namespace StockCalculator.API.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("{controller}/{action=Index}/{id?}")]
    public class StockCalculator : Controller
    {
        public string Index(DateTime stockDate)
        {
            SqlRepository sqlData = new SqlRepository();

            return Newtonsoft.Json.JsonConvert.SerializeObject(sqlData.GetComapniesDailyStocks(stockDate));

        }
    }
}
