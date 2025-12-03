using Homy.Application.DTOs.Auth;
using Homy.Domin.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homy.Application.Mapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            // User → UserInfoDto
            CreateMap<User, UserInfoDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => GetRoleName(src.Role)));

            // RegisterDto → User
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnabled, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.AccessFailedCount, opt => opt.MapFrom(src => 0));
        }

        private string GetRoleName(UserRole role)
        {
            return role switch
            {
                UserRole.Owner => "Owner",
                UserRole.Agent => "Agent",
                UserRole.Admin => "Admin",
                _ => "Unknown"
            };
        }
    }
