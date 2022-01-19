using AliExpress.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliExpress
{
    public interface IUnitOfWork
    {
        public IAliexpressOrdersProductsRepository AliexpressOrdersProducts { get; }
        public IAppUserRepository AppUsers { get; }
        Task CompleteAsync();
    }
}
