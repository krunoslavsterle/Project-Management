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
            CreateMap<User, IUserPoco>().ReverseMap();

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
                .ForMember(ent => ent.User, e => e.Ignore());

            #endregion Project models
        }
    }
}
