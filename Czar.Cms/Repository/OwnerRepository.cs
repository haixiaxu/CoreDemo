using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Helper;
using Entities.Models;

namespace Repository
{
    /// <summary>
    /// 所有者仓储
    /// </summary>
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        private readonly ISortHelper<Owner> _sortHelper;

        public OwnerRepository(RepositoryContext repositoryContext ,ISortHelper<Owner> sortHelper) :base(repositoryContext)
        {
            _sortHelper = sortHelper;
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
        /// <summary>
        ///分页获取所有者
        /// </summary>
        /// <param name="ownerParameters"></param>
        /// <returns></returns>
        public PagedList<Owner> GetOwners(OwnerParameters ownerParameters)
        {
            var owners = FindByCondition(c => c.DateOfBirth.Year >= ownerParameters.MinYearOfBirth && c.DateOfBirth.Year <= ownerParameters.MaxYearOfBirth);
            SearchByName(ref owners, ownerParameters.Name);
            var apiResult = _sortHelper.ApplySort(owners, ownerParameters.OrderBy);
            var result = PagedList<Owner>.ToPagedList(apiResult, ownerParameters.PageNumber, ownerParameters.PageSize);
            return result;
        }

        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }
        /// <summary>
        /// 根据姓名搜索
        /// </summary>
        /// <param name="owners"></param>
        /// <param name="ownerName"></param>
        private void SearchByName(ref IQueryable<Owner> owners,string ownerName)
        {
            if (!owners.Any() || string.IsNullOrWhiteSpace(ownerName))
                return;
            owners = owners.Where(c => c.Name.ToLower().Contains(ownerName.Trim().ToLower()));
        }

    }
}
