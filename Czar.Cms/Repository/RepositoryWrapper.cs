using Contracts;
using Entities;
using Entities.Helper;
using Entities.Models;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IDataShaper<Owner> _ownerDataShaper;
        private  ISortHelper<Owner> _ownerSortHelper;
        private  ISortHelper<Account> _accountsortHelper;
        private RepositoryContext _repositoryContext;
        private IOwnerRepository _ownerRepository;
        private IAccountRepository _accountRepository;

        public RepositoryWrapper(RepositoryContext repositoryContext,ISortHelper<Owner> ownerSortHelper,ISortHelper<Account> accountSortHelper,IDataShaper<Owner> ownerDataShaper)
        {
            _repositoryContext = repositoryContext;
            _ownerSortHelper = ownerSortHelper;
            _accountsortHelper = accountSortHelper;
            _ownerDataShaper = ownerDataShaper;
        }
        public IOwnerRepository Owner
        {
            get
            {
                if (_ownerRepository == null)
                    _ownerRepository = new OwnerRepository(_repositoryContext,_ownerSortHelper,_ownerDataShaper);
                return _ownerRepository;
            }
        }


        public IAccountRepository Account
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_repositoryContext, _accountsortHelper);
                return _accountRepository;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
