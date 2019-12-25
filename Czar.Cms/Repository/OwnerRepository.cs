using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            var result = FindAll().OrderBy(c => c.Name).ToList();
            return result;
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            return FindByCondition(c => c.Id.Equals(ownerId)).FirstOrDefault();
        }

        public PagedList<Owner> GetOwners(OwnerParameters ownerParameters)
        {
            var result = PagedList<Owner>.ToPagedList(FindAll().OrderBy(c => c.Name), ownerParameters.PageNumber, ownerParameters.PageSize);
            return result;
        }

        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }
    }
}
