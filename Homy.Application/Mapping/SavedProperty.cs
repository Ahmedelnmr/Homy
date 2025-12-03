using AutoMapper;
using Homy.Application.DTOs.SavedProperty;
using Homy.Domin.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.Mapping
{
    public class SavedPropertyProfile : Profile
    {
        public SavedPropertyProfile()
        {
            CreateMap<SavedProperty, SavedPropertyListDto>()
                .ForMember(dest => dest.PropertyTitle, opt => opt.MapFrom(src => src.Property.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Property.Price))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Property.City.Name))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src =>
                    src.Property.District != null ? src.Property.District.Name : null))
                .ForMember(dest => dest.PropertyTypeName, opt => opt.MapFrom(src => src.Property.PropertyType.Name))
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src =>
                    src.Property.Images.FirstOrDefault(img => img.IsMain) != null
                        ? src.Property.Images.FirstOrDefault(img => img.IsMain)!.ImageUrl
                        : src.Property.Images.OrderBy(img => img.SortOrder).FirstOrDefault() != null
                            ? src.Property.Images.OrderBy(img => img.SortOrder).FirstOrDefault()!.ImageUrl
                            : null));
        }
    }
}
