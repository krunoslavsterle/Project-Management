using AutoMapper;
using PM.Model.Common;
using PM.Web.Administration.Project;
using PM.Web.Administration.Task;
using PM.Web.Administration.User;
using PM.Web.Areas.Administration.Models;
using PM.Web.Models;
using System;
using System.Linq;
using System.Globalization;

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

            CreateMap<ITaskPoco, CreateTaskViewModel>()
                .ReverseMap()
                .ForMember(vm => vm.DueDate, d => d.MapFrom(poco => String.IsNullOrEmpty(poco.DueDate) ? (DateTime?)null : DateTime.ParseExact(poco.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToUniversalTime())); ;
            CreateMap<ITaskPoco, EditTaskViewModel>()
                .ForMember(vm => vm.DueDate, d => d.MapFrom(poco => poco.DueDate.HasValue ? poco.DueDate.Value.ToLocalTime().ToString("dd/MM/yyyy") : String.Empty))
                .ReverseMap()
                .ForMember(vm => vm.DueDate, d => d.MapFrom(poco => String.IsNullOrEmpty(poco.DueDate) ? (DateTime?)null : DateTime.ParseExact(poco.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToUniversalTime()));

            CreateMap<ITaskPoco, TaskDTO>()
                .ForMember(vm => vm.AssignedToUsername, d => d.MapFrom(poco => poco.AssignedToUser.UserName))
                .ForMember(vm => vm.CommentsCount, d => d.MapFrom(poco => poco.TaskComments != null ? poco.TaskComments.Count() : 0))
                .ReverseMap();

            CreateMap<ITaskPoco, DashboardTaskDTO>()
                .ForMember(vm => vm.ProjectName, p => p.MapFrom(poco => poco.Project != null ? poco.Project.Name : "No project"))
                .ReverseMap();

            CreateMap<ITaskCommentPoco, TaskCommentDTO>()
                .ReverseMap();

            #endregion Task models
        }
    }
}
