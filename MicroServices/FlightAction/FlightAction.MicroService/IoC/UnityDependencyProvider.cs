using FlightAction.Core.AIRFileParser;
using FlightAction.Core.Interfaces.Others;
using FlightAction.Core.Interfaces.Repositories;
using FlightAction.Core.Interfaces.Services;
using FlightAction.Core.Services;
using FlightAction.Repository.DBContext;
using FlightAction.Repository.Repositories;
using Framework.Core.IoC;
using Unity;
using Unity.Lifetime;

namespace FlightAction.MicroService.IoC
{
    public class UnityDependencyProvider : IDependencyProvider
    {
        public void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<IFlightActionDbContext, FlightActionDbContext>(new SingletonLifetimeManager());
            container.RegisterType<IFlightActionManagementRepository, FlightActionManagementRepository>();
            container.RegisterType<IFileUploadService, FileUploadService>();
            container.RegisterType<IAirFileParser, AirFileParser>();
        }
    }
}
