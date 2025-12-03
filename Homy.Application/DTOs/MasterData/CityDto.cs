using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.MasterData
{
    public class CityListDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public int DistrictsCount { get; set; }
        public int PropertiesCount { get; set; }
        public int ProjectsCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CityDetailsDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public List<DistrictSimpleDto> Districts { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateCityDto
    {
        [Required(ErrorMessage = "اسم المدينة مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }

    public class UpdateCityDto
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "اسم المدينة مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}
