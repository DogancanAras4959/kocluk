using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Dtos.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Interface
{
    public interface IStudentService : ICrudService<Students, StudentsDto>
    {
        StudentsDto GetStudentByName(string userName);
        Task<List<StudentsDto>> GetAllAsync();
        Task<StudentsDto> GetStudentAsync(int id);
        Task<StudentsDto> GetStudentAsyncStudentName(string userName);
        Task<StudentsDto> UpdateAsync(StudentsDto user);
        Task<StudentsDto> InsertAsync(StudentsDto user);
    }
}
