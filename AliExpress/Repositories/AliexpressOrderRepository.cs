using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliExpress.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AliExpress.Repositories
{
    public class AliexpressOrderRepository : GenericRepository<AliexpressOrder>, IAliexpressOrderRepository
    {
        public AliexpressOrderRepository(
            ApplicationDbContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<AliexpressOrder>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(AliexpressOrderRepository));
                return new List<AliexpressOrder>();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(AliexpressOrderRepository));
                return false;
            }
        }

        public override async Task<bool> Update(AliexpressOrder entity)
        {
            try
            {
                var existingUser = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingUser == null)
                    return false;

                existingUser.TotalUnitsInOrder = entity.TotalUnitsInOrder;
                existingUser.TotalCostOfProducts = entity.TotalCostOfProducts;
                existingUser.CostOfShipping = entity.CostOfShipping;
                existingUser.TotalOrderTax = entity.TotalOrderTax;
                existingUser.Currency = entity.Currency;
                existingUser.AdjustedPrice = entity.AdjustedPrice;
                existingUser.TotalAmount = entity.TotalAmount;
                existingUser.Discount = entity.Discount;
                existingUser.NzSupplyOrderId = entity.NzSupplyOrderId;
                existingUser.ReceiptDocument = entity.ReceiptDocument;
                existingUser.AliExpressStoreName = entity.AliExpressStoreName;
                existingUser.OrderCancelled = entity.OrderCancelled;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(AliexpressProductRepository));
                return false;
            }
        }
    }
}
