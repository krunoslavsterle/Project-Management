using Ninject.Modules;

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
        }
    }
}
