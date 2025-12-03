using AutoMapper;
using Homy.Application.DTOs.Admin;
using Homy.Domin.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.Mapping
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            // User → UserListDto
            CreateMap<User, UserListDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => GetRoleName(src.Role)))
                .ForMember(dest => dest.TotalProperties, opt => opt.MapFrom(src => src.Properties.Count))
                .ForMember(dest => dest.HasActiveSubscription, opt => opt.MapFrom(src =>
                    src.Subscriptions.Any(s => s.IsActive && s.EndDate > DateTime.Now)));

            // User → UserDetailsDto
            CreateMap<User, UserDetailsDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => GetRoleName(src.Role)))
                .ForMember(dest => dest.TotalProperties, opt => opt.MapFrom(src => src.Properties.Count))
                .ForMember(dest => dest.ActiveProperties, opt => opt.MapFrom(src =>
                    src.Properties.Count(p => p.Status == PropertyStatus.Active)))
                .ForMember(dest => dest.FeaturedProperties, opt => opt.MapFrom(src =>
                    src.Properties.Count(p => p.IsFeatured && p.FeaturedUntil > DateTime.Now)))
                .ForMember(dest => dest.CurrentSubscription, opt => opt.MapFrom(src =>
                    src.Subscriptions
                        .Where(s => s.IsActive && s.EndDate > DateTime.Now)
                        .OrderByDescending(s => s.EndDate)
                        .FirstOrDefault()));

            // UserSubscription → UserSubscriptionInfoDto
            CreateMap<UserSubscription, UserSubscriptionInfoDto>()
                .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PackageName, opt => opt.MapFrom(src => src.Package.Name))
                .ForMember(dest => dest.DaysRemaining, opt => opt.MapFrom(src =>
                    (src.EndDate - DateTime.Now).Days > 0 ? (src.EndDate - DateTime.Now).Days : 0));

            // UpdateUserDto → User
            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore())
                .ForMember(dest => dest.ProfileImageUrl, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.Properties, opt => opt.Ignore())
                .ForMember(dest => dest.SavedProperties, opt => opt.Ignore())
                .ForMember(dest => dest.Subscriptions, opt => opt.Ignore());

            // Property → PropertyReviewListDto
            CreateMap<Property, PropertyReviewListDto>()
                .ForMember(dest => dest.PropertyTypeName, opt => opt.MapFrom(src => src.PropertyType.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District != null ? src.District.Name : null))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.OwnerPhone, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => GetStatusName(src.Status)))
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src =>
                    src.Images.FirstOrDefault(img => img.IsMain) != null
                        ? src.Images.FirstOrDefault(img => img.IsMain)!.ImageUrl
                        : src.Images.OrderBy(img => img.SortOrder).FirstOrDefault() != null
                            ? src.Images.OrderBy(img => img.SortOrder).FirstOrDefault()!.ImageUrl
                            : null));
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

        private string GetStatusName(PropertyStatus status)
        {
            return status switch
            {
                PropertyStatus.Active => "نشط",
                PropertyStatus.SoldOrRented => "تم البيع/الإيجار",
                PropertyStatus.Hidden => "مخفي",
                _ => "غير معروف"
            };
        }
    }
}
