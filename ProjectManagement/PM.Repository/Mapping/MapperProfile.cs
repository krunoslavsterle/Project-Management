using AutoMapper;
using PM.DAL;
using PM.Model;
using PM.Model.Common;
using System;
using System.Linq;

namespace PM.Repository
{
    /// <summary>
    /// Automapper profile for model classes.
    /// </summary>
    public class MapperProfile : Profile
    {  
        [Obsolete]
        protected override void Configure()
        {
            #region Identity models

            CreateMap<UserPoco, IUserPoco>().ReverseMap();
            CreateMap<User, IUserPoco>()
                .MaxDepth(1)
                .ReverseMap()
                .ForMember(ent => ent.Projects, model => model.Ignore())
                .ForMember(ent => ent.Company, model => model.Ignore())
                .ForMember(ent => ent.ProjectUsers, model => model.Ignore())
                .MaxDepth(1);

            CreateMap<RolePoco, IRolePoco>().ReverseMap();
            CreateMap<Role, IRolePoco>()
                .ReverseMap()
                .ForMember(ent => ent.UserRoles, model => model.Ignore());

            CreateMap<ExternalLogin, IExternalLoginPoco>().ReverseMap();
            CreateMap<ExternalLoginPoco, IExternalLoginPoco>().ReverseMap();

            CreateMap<Claim, IClaimPoco>().ReverseMap();
            CreateMap<ClaimPoco, IClaimPoco>().ReverseMap();

            CreateMap<PM.Model.UserRolePoco, PM.Model.Common.IUserRolePoco>().ReverseMap();
            CreateMap<DAL.UserRole, IUserRolePoco>()
                .ForMember(ent => ent.User, model => model.Ignore())
                .ReverseMap()
                .ForMember(ent => ent.Role, model => model.Ignore())
                .ForMember(ent => ent.User, model => model.Ignore()); 
            
            #endregion Identity models

            #region Project models

            CreateMap<ProjectPoco, IProjectPoco>().ReverseMap();
            CreateMap<Project, IProjectPoco>()
                .MaxDepth(1)
                .ReverseMap()
                .ForMember(ent => ent.Company, e => e.Ignore())
                .ForMember(ent => ent.ProjectLeader, e => e.Ignore())
                .MaxDepth(1);
                

            CreateMap<ProjectUserPoco, IProjectUserPoco>().ReverseMap();
            CreateMap<ProjectUser, IProjectUserPoco>()
                .MaxDepth(1)
                .ReverseMap()
                .ForMember(ent => ent.Project, model => model.Ignore())
                .ForMember(ent => ent.User, model => model.Ignore())
                .ForMember(ent => ent.ProjectRole, model => model.Ignore())
                .MaxDepth(1);


            CreateMap<TaskPoco, ITaskPoco>().ReverseMap();
            CreateMap<Task, ITaskPoco>()
                .ReverseMap()
                .ForMember(ent => ent.AssignedToUser, model => model.Ignore())
                .ForMember(ent => ent.CreatedByUser, model => model.Ignore())
                .ForMember(ent => ent.Project, model => model.Ignore())
                .ForMember(ent => ent.TaskPriority, model => model.Ignore())
                .ForMember(ent => ent.TaskStatus, model => model.Ignore());

            CreateMap<TaskCommentPoco, ITaskCommentPoco>().ReverseMap();
            CreateMap<TaskComment, ITaskCommentPoco>()
                .MaxDepth(1)
                .ReverseMap()
                .ForMember(ent => ent.User, model => model.Ignore())
                .ForMember(ent => ent.Task, model => model.Ignore());

            CreateMap<TaskStatusPoco, ITaskStatusPoco>().ReverseMap();
            CreateMap<TaskStatus, ITaskStatusPoco>()
                .ReverseMap();

            CreateMap<TaskPriorityPoco, ITaskPriorityPoco>().ReverseMap();
            CreateMap<TaskPriority, ITaskPriorityPoco>()
                .ReverseMap();

            CreateMap<ProjectRolePoco, IProjectRolePoco>().ReverseMap();
            CreateMap<ProjectRole, IProjectRolePoco>()
                .ReverseMap();

            CreateMap<CompanyPoco, ICompanyPoco>().ReverseMap();
            CreateMap<Company, ICompanyPoco>()
                .ReverseMap();

            #endregion Project models
        }
    }
}
