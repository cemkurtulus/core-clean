using Core.Interfaces;
using Core.Service;
using Autofac;
using Infra.Adapters.Postgres;
using Infra.Interfaces;
using AutoMapper;

namespace Core.Utils
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // AutoMapper configuration
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                var profile = new MappingProfile();
                configuration.AddProfile(profile);
            });

            // Register AutoMapper
            builder.RegisterInstance(mapperConfiguration.CreateMapper()).As<IMapper>().SingleInstance();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerDependency();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerDependency();
        }
    }
}
