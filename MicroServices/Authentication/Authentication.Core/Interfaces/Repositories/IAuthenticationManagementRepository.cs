namespace Authentication.Core.Interfaces.Repositories
{
    public interface IAuthenticationManagementRepository
    {
        ILoginRepository LoginRepository { get; }
    }
}