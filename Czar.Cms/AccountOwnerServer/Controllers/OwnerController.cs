using System;
using System.Collections.Generic;
using System.Dynamic;
using AutoMapper;
using Contracts;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountOwnerServer.Controllers
{
    /// <summary>
    /// 所有者
    /// </summary>
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public OwnerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        /// <summary>
        /// 分页获取所得者
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetOwners([FromQuery] OwnerParameters ownerParameters)
        {
            if(!ownerParameters.ValidYearRange)
            {
                return BadRequest("最大出生年份不能小于最小出生年份");
            }
            var owners = _repository.Owner.GetOwners(ownerParameters);
            var metadata = new 
            { 
                owners.TotalCount,
                owners.PageSize,
                owners.CurrentPage,
                owners.TotalPages,
                owners.HasNext,
                owners.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            _logger.LogInfo($"返回{owners.TotalCount}数据库中的所有者");
            return Ok(owners);
        }
        /// <summary>
        /// 根据查询编号查询所有者
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}",Name ="OwnerById")]
        public IActionResult GetOwnerById(Guid id,[FromQuery] string fields)
        {
            var owner = _repository.Owner.GetOwnerById(id,fields);
            if (owner == default(Entity))
            {
                _logger.LogError($"所有者id为: {id}, 在数据库中找不到.");
                return NotFound();
            }
            _logger.LogInfo($"返回id为的所有者: {id}");
            var ownerResult = _mapper.Map<OwnerDto>(owner);
            return Ok(ownerResult);
        }
        /// <summary>
        /// 创建所有者
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateOwner([FromBody] OwnerForCreationDto owner)
        {
            if (owner == null)
            {
                _logger.LogError("从客户端发送的所有者对象为空");
                return BadRequest("所有者对象为空");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("从客户端发送的所有者对象无效");
                return BadRequest("无效的模型对象");
            }
            var ownerEntity = _mapper.Map<Owner>(owner);
            _repository.Owner.CreateOwner(ownerEntity);
            _repository.Save();
            var createOwner = _mapper.Map<OwnerDto>(ownerEntity);
            return CreatedAtRoute("OwnerById", new { id = createOwner.Id }, createOwner);
        }
        /// <summary>
        /// 更新所有者
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id,[FromBody] OwnerForUpdateDto owner)
        {
            if (owner == null)
            {
                _logger.LogError("从客户端发送的所有者对象为空");
                return BadRequest("所有者对象为空");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("从客户端发送的所有者对象无效");
                return BadRequest("无效的模型对象");
            }
            var ownerEntity = _repository.Owner.GetOwnerById(id);
            if (ownerEntity == null)
            {
                _logger.LogError($"所有者id为: {id}, 在数据库中找不到.");
                return NotFound();
            }
            _mapper.Map(owner, ownerEntity);
            _repository.Owner.UpdateOwner(ownerEntity);
            _repository.Save();
            return NoContent();
        }
        /// <summary>
        /// 删除所有者
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            var owner = _repository.Owner.GetOwnerById(id);
            if (owner==null)
            {
                _logger.LogError($"所有者id为: {id}, 在数据库中找不到.");
                return NotFound();
            }
            _repository.Owner.DeleteOwner(owner);
            _repository.Save();
            return NoContent();
        }
    }
}