using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.LoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoanController : Controller
    {
        private readonly ApiContext _context;
        public LoanController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var loans = await _context.Loans                
                .ToArrayAsync();

            var response = loans.Select(l => new
            {
                loanId = l.LoanId,
                loanNumber = l.LoanNumber,                              
                description = l.Description,
                balance = l.Balance,
                balanceIncludeInterestof = l.BalanceIncludeInterestof,
                earlyPaymentFee = l.EarlyPaymentFee,
                payoutAmount = l.PayoutAmount,
                customerNumber = l.CustomerNumber
            });

            return Ok(response);
        }

        // GET api/<controller>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var loans = await _context.Loans
                .Where(l => l.LoanId == id)
                .ToArrayAsync();

            var response = loans.Select(l => new
            {
                loanId = l.LoanId,
                loanNumber = l.LoanNumber,                
                description = l.Description,
                balance = l.Balance,
                balanceIncludeInterestof = l.BalanceIncludeInterestof,
                earlyPaymentFee = l.EarlyPaymentFee,
                payoutAmount = l.PayoutAmount,
                customerNumber = l.CustomerNumber
            });

            return Ok(response);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
