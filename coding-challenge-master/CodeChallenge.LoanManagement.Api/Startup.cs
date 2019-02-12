using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeChallenge.LoanManagement.Api.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CodeChallenge.LoanManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "loanDb"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApiContext>();
            LoadFirstLoanDetail(context);
            app.UseMvc();
            app.UseExceptionHandler(options =>
            {
                options.Run(
                HandleException());
            });
        }

        private void LoadFirstLoanDetail(ApiContext context)
        {
            String loanNumber = "933217230";
            String customerNumber = Guid.NewGuid().ToString();
            var firstLoan = new Loan
            {
                LoanId = 1,
                LoanNumber = loanNumber,                
                Description = "Tempore fuga quaerat # ",
                Balance = 1225,
                BalanceIncludeInterestof = 282,
                EarlyPaymentFee = 145,
                PayoutAmount = 1762,
                CustomerNumber = customerNumber
            };

            context.Loans.Add(firstLoan);
            context.SaveChanges();
        }

        private RequestDelegate HandleException()
        {
            return async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/html";
                var ex = context.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {
                    var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
                    // Here error can be logged in to log file
                    await context.Response.WriteAsync(err).ConfigureAwait(false);
                }
            };
        }
    }
}
