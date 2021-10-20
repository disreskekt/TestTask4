using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TestTask4.Models;
using TestTask4.Services.Interfaces;

namespace TestTask4.Services
{
    public class CurrencyService : ICurrencyService
    {
        public IEnumerable<CurrencyModel> GetCurrencies(int pageSize, int pageNumber)
        {
            var jsonModel = GetJsonModel();

            var currencies = jsonModel.Valute.Select(kvp => kvp.Value)
                                             .ToList();


            return currencies.Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();
        }

        public CurrencyModel GetCurrency(string id)
        {
            var jsonModel = GetJsonModel();

            if (jsonModel.Valute.TryGetValue(id, out CurrencyModel currencyModel))
            {
                return currencyModel;
            }
            else
            {
                return null;
            }
        }

        private JsonModel GetJsonModel()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(new Uri("https://www.cbr-xml-daily.ru/daily_json.js"));

                var content = response.GetAwaiter()
                                      .GetResult().Content;

                using (var taskStream = content.ReadAsStreamAsync())
                {
                    return JsonSerializer.DeserializeAsync<JsonModel>(taskStream.GetAwaiter()
                                                                                .GetResult()).GetAwaiter()
                                                                                             .GetResult();
                }
            }
        }
    }
}
