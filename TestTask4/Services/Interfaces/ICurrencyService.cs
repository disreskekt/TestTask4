using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask4.Models;

namespace TestTask4.Services.Interfaces
{
    public interface ICurrencyService
    {
        IEnumerable<CurrencyModel> GetCurrencies(int pageSize, int pageNumber);
        CurrencyModel GetCurrency(string id);
    }
}
