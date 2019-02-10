using CodeChallenge.LoanManagement.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.LoanManagementApi.Test
{
    public class ConnectionFactory : IDisposable
    {
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public ApiContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new ApiContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
