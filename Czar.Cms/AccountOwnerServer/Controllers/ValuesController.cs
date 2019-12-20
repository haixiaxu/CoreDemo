using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountOwnerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        public ValuesController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
    
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var domesticAccounts = _repositoryWrapper.Account.FindByCondition(c => c.AccountType.Equals("Domestic"));
            var owners = _repositoryWrapper.Owner.FindAll();
            return new string[] { "value1", "value2" };
        }
    }
}
