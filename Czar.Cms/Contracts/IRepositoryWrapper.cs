namespace Contracts
{
    /// <summary>
    ///用户类包装器
    /// </summary>
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }
        void Save();
    }
}
