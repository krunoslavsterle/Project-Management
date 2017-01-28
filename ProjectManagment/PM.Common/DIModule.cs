using Ninject.Modules;
using PM.Common.Cache;

namespace PM.Common
{
    public class DIModule : NinjectModule
    {
        /// <summary>
        /// Load dependency injection bindings.
        /// </summary>
        public override void Load()
        {
            Bind<IMapper>().To<Mapper>().InSingletonScope();
            Bind<IPagingParameters>().To<PagingParameters>();
            Bind<ICacheProvider>().To<MemoryCacheProvider>().InSingletonScope();
        }
    }
}
