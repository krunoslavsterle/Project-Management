using Ninject.Modules;
using PM.Service.Common;

namespace PM.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IIdentityService>().To<IdentityService>();
        }
    }
}
