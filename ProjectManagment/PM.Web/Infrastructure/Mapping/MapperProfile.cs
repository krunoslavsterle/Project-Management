using AutoMapper;
using PM.Model.Common;
using PM.Web.Administration.Models;
using PM.Web.Administration.Project;
using PM.Web.Identity;
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

            CreateMap<Model.Common.IUserPoco, IdentityUser>()
                .ForMember(v => v.Id, opt => opt.MapFrom(d => d.UserId))
                .ReverseMap()
                .ForMember(d => d.UserId, opt => opt.MapFrom(v => v.Id));

            CreateMap<Model.Common.IRolePoco, IdentityRole>()
                .ForMember(v => v.Id, opt => opt.MapFrom(d => d.RoleId))
                .ReverseMap()
                .ForMember(d => d.RoleId, opt => opt.MapFrom(v => v.Id));

            #endregion Identity models  

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
