using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculatorAPI.Models
{
    public class LoanCalculationRequest
    {
        public decimal Principal { get; set; } // Loan Amount
        public double AnnualInterestRate { get; set; } // Annual Interest Rate in percentage
        public int LoanTenureMonths { get; set; } // Tenure in months
    }
}