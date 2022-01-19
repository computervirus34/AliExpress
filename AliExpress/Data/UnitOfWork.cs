using AliExpress.IRepositories;
using AliExpress.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliExpress.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IAliexpressOrdersProductsRepository AliexpressOrdersProducts { get; private set; }
        public IAppUserRepository AppUsers { get; private set; }
        public UnitOfWork(
            ApplicationDbContext context,
            ILoggerFactory loggerFactory
            )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            AliexpressOrdersProducts = new AliexpressOrdersProductsRepository(_context, _logger);
            AppUsers = new AppUserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
