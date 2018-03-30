using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BABurgessWebApp.Models
{
    public class FinancialTradingModels
    {
        [Key]
        public int Id { get; set; }
        public string Symbol { get; set; }
    }
}