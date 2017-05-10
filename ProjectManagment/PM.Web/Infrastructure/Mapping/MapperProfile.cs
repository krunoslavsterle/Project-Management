using AutoMapper;
using PM.Model.Common;
using PM.Web.Administration.Models;
using PM.Web.Administration.Project;
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

            CreateMap<IUserPoco, UserPreviewViewModel>().ReverseMap();
            CreateMap<IUserPoco, RegisterViewModel>().ReverseMap();

            #region Project models

            CreateMap<IProjectPoco, CreateProjectViewModel>().ReverseMap();
            CreateMap<IProjectPoco, ProjectViewModel>().ReverseMap();
            CreateMap<IProjectPoco, ProjectPreviewViewModel>().ReverseMap();

            #endregion Project models

            #region Task models

            CreateMap<ITaskPoco, CreateTaskViewModel>().ReverseMap();
            CreateMap<ITaskPoco, EditTaskViewModel>().ReverseMap();

            #endregion Task models
        }
    }
}
