using AutoMapper;
using Entities.Dto;
using Entities.Models;

namespace AccountOwnerServer.Extensions
{
    /// <summary>
    /// /映射AutoMapper
    /// </summary>
    public class MappingProfile:Profile
    {
        /// <summary>
        /// 创建映射
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerForCreationDto, Owner>();
            CreateMap<OwnerForUpdateDto, Owner>();
        }
    }
}
