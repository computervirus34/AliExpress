using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliExpress.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AliExpress.Repositories
{
    public class AliexpressOrdersProductsRepository : GenericRepository<AliexpressOrdersProduct>, IAliexpressOrdersProductsRepository
    {
        public AliexpressOrdersProductsRepository(
            ApplicationDbContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<AliexpressOrdersProduct>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(AliexpressOrdersProductsRepository));
                return new List<AliexpressOrdersProduct>();
            }
        }

        public override async Task<bool> Delete(int Id)
        {
            try
            {
                var exist = await _dbSet.Where(o => o.Id == Id)
                                        .SingleOrDefaultAsync();

                if (exist != null)
                {
                    _dbSet.Remove(exist);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(AliexpressOrdersProductsRepository));
                return false;
            }
        }

        public override async Task<bool> Update(AliexpressOrdersProduct entity)
        {
            try
            {
                var existingUser = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingUser == null)
                    return false;

                existingUser.Url = entity.Url;
                existingUser.Specification1 = entity.Specification1;
                existingUser.Quantity = entity.Quantity;
                existingUser.UnitPrice = entity.UnitPrice;
                existingUser.TotalProductTax = entity.TotalProductTax;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(AliexpressOrdersProductsRepository));
                return false;
            }
        }
    }
}
