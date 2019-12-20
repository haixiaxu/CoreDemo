using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    /// <summary>
    /// 所有者仓储
    /// </summary>
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }
    }
}
