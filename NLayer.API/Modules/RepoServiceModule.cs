using Autofac;
using NLayer.Caching;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using NLayerRepository;
using NLayerRepository.Repositoryies;
using NLayerRepository.UnitOfWork;
using System.Reflection;
using Module = Autofac.Module;


namespace NLayer.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        { 

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope(); // generic ama birer tane olanlar.
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            var apiAssembly = Assembly.GetExecutingAssembly(); // apiye ait assmbly yi al diyoruz.Üzerinde çalıştıgım assembly
            var repo = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repo, serviceAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repo, serviceAssembly).Where(x => x.Name.EndsWith
           ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();
            




            // InstancePerLifetimeScope x => scope ifadesine karşılık geliyor. // request başladı bitene kadar aynı instance ı kullansın
            //InstancePerDependency x => transient e karşılık gelir. // herhangi bir classın constracterinda o interface nerde geçildiyse her seferinde yeni instance oluşturur.
        }
    }
}
