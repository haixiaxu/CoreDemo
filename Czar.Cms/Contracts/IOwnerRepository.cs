
using Entities.Helper;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    /// <summary>
    /// 仓储所有者类
    /// </summary>
    public interface IOwnerRepository:IRepositoryBase<Owner>
    {
        /// <summary>
        /// 获取所有所得者
        /// </summary>
        /// <returns></returns>
        IEnumerable<Owner> GetAllOwners();
        /// <summary>
        /// 根据所有者编号查询
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        Owner GetOwnerById(Guid ownerId);
        /// <summary>
        /// 创建所有者
        /// </summary>
        /// <param name="owner"></param>
        void CreateOwner(Owner owner);
        /// <summary>
        /// 更新所有者
        /// </summary>
        /// <param name="owner"></param>
        void UpdateOwner(Owner owner);
        /// <summary>
        /// 删除所有者
        /// </summary>
        /// <param name="owner"></param>
        void DeleteOwner(Owner owner);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="ownerParameters"></param>
        /// <returns></returns>
        PagedList<Owner> GetOwners(OwnerParameters ownerParameters);
    }
}
