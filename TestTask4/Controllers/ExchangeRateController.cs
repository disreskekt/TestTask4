using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using TestTask4.Models;
using TestTask4.Services.Interfaces;

namespace TestTask4.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        public ExchangeRateController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        [HttpGet("{pageSize}")]
        [HttpGet("{pageSize}/{pageNumber}")]
        public IActionResult Currencies(int pageSize = int.MaxValue, int pageNumber = 1)
        {
            try
            {
                var currencies =_currencyService.GetCurrencies(pageSize, pageNumber);

                return Ok(currencies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Currency(string id)
        {
            try
            {
                var currency =_currencyService.GetCurrency(id);

                if (currency != null)
                {
                    return Ok(currency);
                }
                else
                {
                    return BadRequest("Идентификатора не существует");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
