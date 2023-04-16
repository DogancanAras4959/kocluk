using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.StudyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Interface
{
    public interface IStudyTipService : ICrudService<StudyTips,StudyTipDto>
    {
        List<StudyTipDto> GetStudyTipsWithStudy(int id);
    }
}
