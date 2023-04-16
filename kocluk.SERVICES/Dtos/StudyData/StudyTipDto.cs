using kocluk.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.StudyData
{
    public class StudyTipDto : BaseEntityDto
    {
        public string? TipName { get; set; }

        public int StudyId { get; set; }

        public StudyDto? study { get; set; }
    }
}
