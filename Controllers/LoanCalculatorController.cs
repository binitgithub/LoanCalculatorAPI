using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculatorAPI.Models;
using LoanCalculatorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanCalculatorController : ControllerBase
    {
        private readonly LoanCalculatorService _loanCalculatorService;

        public LoanCalculatorController()
        {
            _loanCalculatorService = new LoanCalculatorService();
        }
    //Calculate Loan
    [HttpPost("calculate")]
    public IActionResult CalculateLoan([FromBody] LoanCalculationRequest request)
    {
        if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            var response = _loanCalculatorService.CalculateLoan(request);
            return Ok(response);
    }
    }
}