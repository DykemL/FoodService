using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Models.DtoModels
{
    public class CardPaymentDto
    {
        public string CardNumber { get; set; }
        public string MonthYear { get; set; }
        public string Cvc { get; set; }
        public string MoneyAmount { get; set; }
    }
}
