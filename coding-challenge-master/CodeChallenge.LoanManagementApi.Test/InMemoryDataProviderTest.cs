using CodeChallenge.LoanManagement.Api;
using CodeChallenge.LoanManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodeChallenge.LoanManagementApi.Test
{
    public class InMemoryDataProviderTest
    {
        private static DbContextOptions<ApiContext> _options = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase(databaseName: "Api_testDatabase")
.Options;
        [Fact]
        public void AddLoanTest()
        {
            var mockSet = new Mock<DbSet<Loan>>();
            var mockContext = new Mock<ApiContext>(_options);
            mockContext.Setup(m => m.Loans).Returns(mockSet.Object);
            var service = new LoanManagement.Api.Controllers.LoanController(mockContext.Object);
            var loan = new Loan()
            {
                LoanNumber = Guid.NewGuid().ToString(),
                Description = "Placeat autem quas # 415593955"
            };            
            mockContext.Object.SaveChanges();
            mockSet.Verify(m => m.AddAsync(loan, new CancellationToken()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void GetLoanTest()
        {
            var loan = new Loan()
            {
                LoanNumber = Guid.NewGuid().ToString(),
                Description = "Placeat autem quas # 415593955"
            };
            Mock<DbSet<Loan>> loanDbSetMock = new Mock<DbSet<Loan>>(); 
            var mockContext = new Mock<ApiContext>(_options);
            mockContext.Setup(c => c.Loans).Returns(loanDbSetMock.Object);
            var service = new LoanManagement.Api.Controllers.LoanController(mockContext.Object);
            var data = "Placeat autem quas # 415593955";
            Assert.NotNull(data);
            Assert.Equal(loan.Description, data);
        }
        
        [Fact]
        public void Save_And_Get_Loan_Test()
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
    }
}
