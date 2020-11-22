using Authentication.Core.Interfaces.Repositories;
using Authentication.Core.Interfaces.Services;
using Authentication.Core.Services;
using Authentication.Repository.DBContext;
using Authentication.Repository.Repositories;
using Framework.Core.IoC;
using Unity;
using Unity.Lifetime;

namespace Authentication.MicroService.IoC
{
    public class UnityDependencyProvider : IDependencyProvider
    {
        public void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<IAuthenticationDbContext, AuthenticationDbContext>(new SingletonLifetimeManager());
            container.RegisterType<IAuthenticationManagementRepository, AuthenticationManagementRepository>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
        }
    }
}
