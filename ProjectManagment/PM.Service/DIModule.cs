using Ninject.Modules;

namespace PM.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<ITestService>().To<TestService>();
        }
    }
}
