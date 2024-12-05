using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculatorAPI.Models;

namespace LoanCalculatorAPI.Services
{
    public class LoanCalculatorService
    {
        public LoanCalculationResponse CalculateLoan(LoanCalculationRequest request)
        {
            // Convert annual interest rate to monthly and decimal form
            double monthlyInterestRate = request.AnnualInterestRate / 100 / 12;

            // Calculate monthly payment using the amortization formula
            decimal monthlyPayment = request.Principal * 
                (decimal)(monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, request.LoanTenureMonths) /
                          (Math.Pow(1 + monthlyInterestRate, request.LoanTenureMonths) - 1));

            // Total Payment over the entire loan period
            decimal totalPayment = monthlyPayment * request.LoanTenureMonths;

            // Total Interest paid
            decimal totalInterest = totalPayment - request.Principal;

            return new LoanCalculationResponse
            {
                MonthlyPayment = monthlyPayment,
                TotalPayment = totalPayment,
                TotalInterest = totalInterest
            };
        }
    }
}