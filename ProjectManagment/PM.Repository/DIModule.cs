using AutoMapper;
using Ninject.Modules;
using PM.Repository.Common;

namespace PM.Repository
{
    /// <summary>
    /// DI module class.
    /// </summary>
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWork));
            Bind<Profile>().To<MapperProfile>().InTransientScope();
        }
    }
}
    