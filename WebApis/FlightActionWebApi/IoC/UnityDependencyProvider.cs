using Framework.Core.IoC;
using Framework.Core.Logger;
using Unity;

namespace FlightActionWebApi.IoC
{
    public class UnityDependencyProvider : IDependencyProvider
    {
        public void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<IProLogger, ProLogger>();
        }
    }
}