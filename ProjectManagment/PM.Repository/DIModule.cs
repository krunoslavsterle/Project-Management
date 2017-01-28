using AutoMapper;
using Ninject.Modules;
using Ninject.Web.Common;
using PM.DAL;
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
            Bind<PMDatabaseEntities>().ToSelf().InRequestScope();
            Bind<Profile>().To<MapperProfile>().InTransientScope();

            Bind(typeof(IGenericRepository<,>)).To(typeof(GenericRepository<,>));
            Bind(typeof(IUserRepository)).To(typeof(UserRepository));
            Bind(typeof(IRoleRepository)).To(typeof(RoleRepository));
            Bind(typeof(IExternalLoginRepository)).To(typeof(ExternalLoginRepository));
            Bind(typeof(IProjectRepository)).To(typeof(ProjectRepository));
            Bind(typeof(ITaskRepository)).To(typeof(TaskRepository));
            Bind(typeof(ITaskPriorityRepository)).To(typeof(TaskPriorityRepository));
        }
    }
}
    