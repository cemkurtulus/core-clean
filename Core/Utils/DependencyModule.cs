using Core.Interfaces;
using Core.Service;
using Autofac;
using Infra.Adapters.Postgres;
using Infra.Interfaces;
using AutoMapper;
using Infra.Adapters;
using Microsoft.Extensions.Configuration;

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
            
            //Register Services
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerDependency();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerDependency();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerDependency();

            // Register DbContext
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();
                return new PostgresqlDbContext(config);
            }).As<PostgresqlDbContext>().InstancePerLifetimeScope();
            
        }
    }
}
