using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliExpress.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AliExpress.Repositories
{
    public class AliexpressProductRepository:GenericRepository<AliexpressProduct>, IAliexpressProductRepository
    {
        public AliexpressProductRepository(
            ApplicationDbContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<AliexpressProduct>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(AliexpressProductRepository));
                return new List<AliexpressProduct>();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(AliexpressProductRepository));
                return false;
            }
        }

        public override async Task<bool> Update(AliexpressProduct entity)
        {
            try
            {
                var existingUser = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingUser == null)
                    return false;

                existingUser.Url = entity.Url;
                existingUser.ProductName = entity.ProductName;
                existingUser.Specification1 = entity.Specification1;
                existingUser.MainImage = entity.MainImage;
                existingUser.Images = entity.Images;
                existingUser.Sku = entity.Sku;
                existingUser.Description = entity.Description;
                existingUser.SpecInformation = entity.SpecInformation;

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
