using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.DTOs.MasterData
{
    public class DistrictListDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long CityId { get; set; }
        public string CityName { get; set; } = null!;
        public int PropertiesCount { get; set; }
        public int ProjectsCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class DistrictSimpleDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class CreateDistrictDto
    {
        [Required(ErrorMessage = "اسم الحي مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "المدينة مطلوبة")]
        public long CityId { get; set; }
    }

    public class UpdateDistrictDto
    {
        [Required]
        public long Id { get; set; }

        [Required(ErrorMessage = "اسم الحي مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "المدينة مطلوبة")]
        public long CityId { get; set; }
    }
}
