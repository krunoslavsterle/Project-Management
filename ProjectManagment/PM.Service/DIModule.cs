using Ninject.Modules;
using PM.Service.Common;

namespace PM.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPMUserStore>().To<PMUserStore>();
            Bind<IProjectService>().To<ProjectService>();
            Bind<ITaskService>().To<TaskService>();
            Bind<ICompanyService>().To<CompanyService>();
            Bind<ILookupService>().To<LookupService>().InSingletonScope();
        }
    }
}
