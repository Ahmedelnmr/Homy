using AutoMapper;
using Homy.Application.DTOs.Property;
using Homy.Domin.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.Mapping
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            // Property → PropertyListDto
            CreateMap<Property, PropertyListDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District != null ? src.District.Name : null))
                .ForMember(dest => dest.PropertyTypeName, opt => opt.MapFrom(src => src.PropertyType.Name))
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src =>
                    src.Images.FirstOrDefault(img => img.IsMain) != null
                        ? src.Images.FirstOrDefault(img => img.IsMain)!.ImageUrl
                        : src.Images.OrderBy(img => img.SortOrder).FirstOrDefault() != null
                            ? src.Images.OrderBy(img => img.SortOrder).FirstOrDefault()!.ImageUrl
                            : null))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => GetPurposeName(src.Purpose)));

            // Property → PropertyDetailsDto
            CreateMap<Property, PropertyDetailsDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District != null ? src.District.Name : null))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project != null ? src.Project.Name : null))
                .ForMember(dest => dest.PropertyTypeName, opt => opt.MapFrom(src => src.PropertyType.Name))
                .ForMember(dest => dest.FinishingType, opt => opt.MapFrom(src => GetFinishingTypeName(src.FinishingType)))
                .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => GetPurposeName(src.Purpose)))
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.OwnerPhone, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.OwnerWhatsApp, opt => opt.MapFrom(src => src.User.WhatsAppNumber))
                .ForMember(dest => dest.OwnerProfileImage, opt => opt.MapFrom(src => src.User.ProfileImageUrl))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.OrderBy(img => img.SortOrder)))
                .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src =>
                    src.PropertyAmenities.Select(pa => pa.Amenity.Name).ToList()));

            // PropertyImage → PropertyImageDto
            CreateMap<PropertyImage, PropertyImageDto>();

            // CreatePropertyDto → Property
            CreateMap<CreatePropertyDto, Property>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => PropertyStatus.Active))
                .ForMember(dest => dest.ViewCount, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.WhatsAppClicks, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.PhoneClicks, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.IsFeatured, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.FeaturedUntil, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyAmenities, opt => opt.Ignore())
                .ForMember(dest => dest.SavedByUsers, opt => opt.Ignore())
                .ForMember(dest => dest.City, opt => opt.Ignore())
                .ForMember(dest => dest.District, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyType, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedById, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

            // UpdatePropertyDto → Property
            CreateMap<UpdatePropertyDto, Property>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.ViewCount, opt => opt.Ignore())
                .ForMember(dest => dest.WhatsAppClicks, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneClicks, opt => opt.Ignore())
                .ForMember(dest => dest.IsFeatured, opt => opt.Ignore())
                .ForMember(dest => dest.FeaturedUntil, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyAmenities, opt => opt.Ignore())
                .ForMember(dest => dest.SavedByUsers, opt => opt.Ignore())
                .ForMember(dest => dest.City, opt => opt.Ignore())
                .ForMember(dest => dest.District, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyType, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedById, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());
        }

        private string GetFinishingTypeName(FinishingType? finishingType)
        {
            return finishingType switch
            {
                FinishingType.None => "بدون تشطيب",
                FinishingType.Semi => "نصف تشطيب",
                FinishingType.Full => "تشطيب كامل",
                _ => "غير محدد"
            };
        }

        private string GetPurposeName(PropertyPurpose purpose)
        {
            return purpose switch
            {
                PropertyPurpose.ForSale => "للبيع",
                PropertyPurpose.ForRent => "للإيجار",
                PropertyPurpose.Both => "للبيع والإيجار",
                _ => "غير محدد"
            };
        }
    }
}
