using Contracts;
using Entities;
using Entities.Helper;
using Entities.Models;

namespace Repository
{
    /// <summary>
    /// 账户仓储
    /// </summary>
    public  class AccountRepository:RepositoryBase<Account>,IAccountRepository
    {
        private readonly ISortHelper<Account> _sortHelper;

        public AccountRepository(RepositoryContext repositoryContext,ISortHelper<Account> sortHelper):base(repositoryContext)
        {
            _sortHelper = sortHelper;
        }
    }
}
