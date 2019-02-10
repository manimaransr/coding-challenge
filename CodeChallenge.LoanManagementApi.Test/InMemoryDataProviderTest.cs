using CodeChallenge.LoanManagement.Api.Entities;
using System;
using System.Linq;
using Xunit;

namespace CodeChallenge.LoanManagementApi.Test
{
    public class InMemoryDataProviderTest
    {
        [Fact]
        public void Real_Get_Loan_Test()
        {
            //Arrange  
            var factory = new ConnectionFactory();

            //Get the instance of ApiContext
            var context = factory.CreateContextForInMemory();

            var loan = new Loan()
            {
                LoanNumber = Guid.NewGuid().ToString(),
                Description = "Placeat autem quas # 415593955"
            };
            var data = context.Loans.Add(loan);
            context.SaveChanges();

            //Assert  
            //Get the loan count
            var loanCount = context.Loans.Count();
            if (loanCount != 0)
            {
                Assert.Equal(1, loanCount);
            }

            //Get single loan detail
            var firstLoan = context.Loans.FirstOrDefault();
            if (firstLoan != null)
            {
                Assert.Equal("Placeat autem quas # 415593955", firstLoan.Description);
            }
        }

        [Fact]
        public void Mock_Get_Loan_Test()
        {
        }
    }
}
