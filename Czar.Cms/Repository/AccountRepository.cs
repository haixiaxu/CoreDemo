using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    /// <summary>
    /// 账户仓储
    /// </summary>
    public  class AccountRepository:RepositoryBase<Account>,IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }
    }
}
