using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.PosgreSQL.Providers
{
    public abstract class BaseProvider
    {
        private readonly LimosaNetDbContext _dbContext;

        public BaseProvider(LimosaNetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected LimosaNetDbContext DBContext { get { return _dbContext; } }
    }
}
