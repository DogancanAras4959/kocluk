using AutoMapper;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Dtos.AccountData;
using kocluk.SERVICES.Dtos.AccountRoleData;
using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Dtos.ExamsData;
using kocluk.SERVICES.Dtos.RoleData;
using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Dtos.StudyData;
using kocluk.SERVICES.Dtos.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Mapper
{
    public class GeneralMapper : Profile
    {
        public GeneralMapper() 
        {
            CreateMap<Roles, RoleDto>();
            CreateMap<RoleDto, Roles>();

            CreateMap<Users, UserDto>();/*.ForMember(x => x.role, y => y.MapFrom(t => t.role));*/
            CreateMap<UserDto, Users>();

            CreateMap<Students, StudentsDto>();
            CreateMap<StudentsDto, Students>();

            CreateMap<Account, AccountDto>();/*.ForMember(x => x.role, y => y.MapFrom(t => t.role));*/
            CreateMap<AccountDto, Account>();

            CreateMap<AccountRole, AccountRoleDto>();
            CreateMap<AccountRoleDto, AccountRole>();

            CreateMap<Studies, StudyDto>();
            CreateMap<StudyDto, Studies>();

            CreateMap<BookingRequest, BookingRequestDto>();
            CreateMap<BookingRequestDto, BookingRequest>();

            CreateMap<Exams, ExamsDto>();
            CreateMap<ExamsDto, Exams>();

            CreateMap<Booking, BookingDto>();
            CreateMap<BookingDto, Booking>();

            CreateMap<StudyTips, StudyTipDto>();
            CreateMap<StudyTipDto, StudyTips>();
        }
    }
}
