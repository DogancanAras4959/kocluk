using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.ExamsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Interface
{
    public interface IExamService : ICrudService<Exams, ExamsDto>
    {
        List<ExamsDto> GetExamsByPaths();
    }
}
