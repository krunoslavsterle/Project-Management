using AutoMapper;
using PM.DAL.Entities;
using PM.Web.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Web
{
    /// <summary>
    /// Automapper profile for model classes.
    /// </summary>
    public class MapperProfile : Profile
    {
        protected override void Configure()
        {
            #region Identity models

            CreateMap<User, IdentityUser>()
                .ForMember(x => x.Id, opt => opt.MapFrom(user => user.UserId))
                .ReverseMap()
                .ForMember(x => x.UserId, opt => opt.MapFrom(user => user.Id));

            #endregion Identity models
        }
    }
}
