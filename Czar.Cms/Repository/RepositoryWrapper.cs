using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IOwnerRepository _ownerRepository;
        private IAccountRepository _accountRepository;

        public IOwnerRepository Owner
        {
            get
            {
                if (_ownerRepository == null)
                    _ownerRepository = new OwnerRepository(_repositoryContext);
                return _ownerRepository;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_repositoryContext);
                return _accountRepository;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
