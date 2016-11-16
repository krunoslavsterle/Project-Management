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

            CreateMap<UserPoco, IUser>().ReverseMap();
            CreateMap<User, IUser>().ReverseMap();

            CreateMap<RolePoco, IRole>().ReverseMap();
            CreateMap<Role, IRole>().ReverseMap();

            CreateMap<ExternalLogin, IExternalLogin>().ReverseMap();
            CreateMap<ExternalLoginPoco, IExternalLogin>().ReverseMap();

            CreateMap<Claim, IClaim>().ReverseMap();
            CreateMap<ClaimPoco, IClaim>().ReverseMap();

            #endregion Identity models

            #region Project models

            CreateMap<ProjectPoco, IProject>().ReverseMap();
            CreateMap<Project, IProject>().ReverseMap();

            #endregion Project models
        }
    }
}
