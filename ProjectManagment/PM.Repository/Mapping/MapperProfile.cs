using AutoMapper;
using PM.DAL.Entities;
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

            CreateMap<User, IUser>().ReverseMap();
            CreateMap<UserEntity, IUser>().ReverseMap();

            CreateMap<Role, IRole>().ReverseMap();
            CreateMap<RoleEntity, IRole>().ReverseMap();

            CreateMap<ExternalLoginEntity, IExternalLogin>().ReverseMap();
            CreateMap<ExternalLogin, IExternalLogin>().ReverseMap();

            CreateMap<ClaimEntity, IClaim>().ReverseMap();
            CreateMap<Claim, IClaim>().ReverseMap();

            #endregion Identity models

            #region Project models

            CreateMap<Project, IProject>().ReverseMap();
            CreateMap<ProjectEntity, IProject>().ReverseMap();

            #endregion Project models
        }
    }
}
