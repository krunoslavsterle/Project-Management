using AutoMapper;
using PM.DAL;
using PM.Model;
using PM.Model.Common;
using System;

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
                .ReverseMap()
                .ForMember(ent => ent.Company, model => model.Ignore());

            CreateMap<RolePoco, IRolePoco>().ReverseMap();
            CreateMap<Role, IRolePoco>().ReverseMap();

            CreateMap<ExternalLogin, IExternalLoginPoco>().ReverseMap();
            CreateMap<ExternalLoginPoco, IExternalLoginPoco>().ReverseMap();

            CreateMap<Claim, IClaimPoco>().ReverseMap();
            CreateMap<ClaimPoco, IClaimPoco>().ReverseMap();

            #endregion Identity models

            #region Project models

            CreateMap<ProjectPoco, IProjectPoco>().ReverseMap();
            CreateMap<Project, IProjectPoco>()
                .ReverseMap()
                .ForMember(ent => ent.Company, e => e.Ignore())
                .ForMember(ent => ent.ProjectLeader, e => e.Ignore());

            CreateMap<TaskPoco, ITaskPoco>().ReverseMap();
            CreateMap<Task, ITaskPoco>()
                .ReverseMap()
                .ForMember(ent => ent.AssignedToUser, model => model.Ignore())
                .ForMember(ent => ent.CreatedByUser, model => model.Ignore())
                .ForMember(ent => ent.Project, model => model.Ignore())
                .ForMember(ent => ent.TaskPriority, model => model.Ignore())
                .ForMember(ent => ent.TaskStatus, model => model.Ignore());


            CreateMap<TaskStatusPoco, ITaskStatusPoco>().ReverseMap();
            CreateMap<TaskStatus, ITaskStatusPoco>()
                .ReverseMap();

            CreateMap<TaskPriorityPoco, ITaskPriorityPoco>().ReverseMap();
            CreateMap<TaskPriority, ITaskPriorityPoco>()
                .ReverseMap();

            CreateMap<CompanyPoco, ICompanyPoco>().ReverseMap();
            CreateMap<Company, ICompanyPoco>()
                .ReverseMap();

            #endregion Project models
        }
    }
}
