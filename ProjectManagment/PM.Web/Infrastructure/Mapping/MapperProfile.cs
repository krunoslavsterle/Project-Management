using AutoMapper;
using PM.Model.Common;
using PM.Web.Administration.Project;
using PM.Web.Administration.Task;
using PM.Web.Administration.User;
using PM.Web.Models;
using System;

namespace PM.Web
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

            
            #endregion Identity models  

            CreateMap<IUserPoco, UserPreviewViewModel>()
                .ForMember(vm => vm.UserId, poco => poco.MapFrom(d => d.Id))
                .ReverseMap();

            CreateMap<IUserPoco, RegisterViewModel>().ReverseMap();

            #region Project models

            CreateMap<IProjectPoco, CreateProjectViewModel>().ReverseMap();
            CreateMap<IProjectPoco, ProjectViewModel>().ReverseMap();
            CreateMap<IProjectPoco, ProjectPreviewViewModel>().ReverseMap();

            #endregion Project models

            #region Task models

            CreateMap<ITaskPoco, CreateTaskViewModel>().ReverseMap();
            CreateMap<ITaskPoco, EditTaskViewModel>()
                .ForMember(vm => vm.DueDate, d => d.MapFrom(poco => poco.DueDate.HasValue ? poco.DueDate.Value.ToLocalTime().ToShortDateString() : String.Empty))
                .ReverseMap()
                .ForMember(vm => vm.DueDate, d => d.MapFrom(poco => String.IsNullOrEmpty(poco.DueDate) ? (DateTime?)null : DateTime.Parse(poco.DueDate).ToUniversalTime()));

            CreateMap<ITaskPoco, TaskDTO>()
                .ForMember(vm => vm.AssignedToUsername, d => d.MapFrom(poco => poco.AssignedToUser.UserName))
                .ReverseMap();

            #endregion Task models
        }
    }
}
