using CodeChallenge.LoanManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.LoanManagement.Api
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
           : base(options)
        {
        }

        public DbSet<Loan> Loans { get; set; }
    }
}
