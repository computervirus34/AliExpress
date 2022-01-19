using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliExpress.IRepositories
{
    public interface IAppUserRepository : IGenericRepository<Appuser>
    {
        Appuser GetByUserID(Appuser user);
    }
}
