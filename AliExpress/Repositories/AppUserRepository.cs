using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliExpress.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AliExpress.Repositories
{
    public class AppUserRepository : GenericRepository<Appuser>, IAppUserRepository
    {
        public AppUserRepository(
            ApplicationDbContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }
        public Appuser GetByUserID(Appuser user)
        {
            try
            {
                Appuser _user = _dbSet.Where(o => o.Email == user.Email).SingleOrDefault();
                if (_user!=null)
                {
                    return _user;
                }
                else
                {
                    _logger.LogError("{Repo} User not found.", typeof(AppUserRepository));
                    return new Appuser();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetByUserID method error.", typeof(AppUserRepository));
                return new Appuser();
            }
        }
        
        public override async Task<IEnumerable<Appuser>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(AppUserRepository));
                return new List<Appuser>();
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

        public override async Task<bool> Update(Appuser entity)
        {
            try
            {
                var existingUser = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingUser == null)
                    return false;

                existingUser.Name = entity.Name;
                existingUser.Password = entity.Password;
                existingUser.Phone = entity.Phone;
                existingUser.Email = entity.Email;
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
