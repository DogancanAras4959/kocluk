using kocluk.SERVICES.Interface;
using koclukyonetim.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using kocluk.SERVICES.Dtos.StudyData;
using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Dtos.UserData;

namespace koclukyonetim.Controllers
{
    public class dersprogramiController : Controller
    {
        private readonly IStudyService _studySevice;
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;
        private readonly IBookingService _bookingService;
        public dersprogramiController(IStudentService studentService, IUserService userService, IStudyService studyService, IBookingService bookingService)
        {
            _studentService = studentService;
            _userService = userService;
            _studySevice = studyService;
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("ajanda")]
        public IActionResult ajanda()
        {
            ViewBag.Dersler = _studySevice.GetAll();
            ViewBag.Ogrenciler = _studentService.GetAll();
            return View();
        }

        public IActionResult ajandagetir()
        {
            try
            {
                var agency = _bookingService.GetAll();

                var agencyModelToCalendar = agency.Select(x => new CalendarModel()
                {
                    Id = x.Id,
                    Title = x.BookingName,
                    StartTime = x.BookingTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    EndTime = x.BookingTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    AllDay = false,
                    Color = x.Color,
                    TextColor = x.TextColor,
                    BookingCode = x.BookingCode,
                   
                }).ToList();

                return Json(new 
                {
                    data = agencyModelToCalendar,
                    IsSuccessful = true
                });

            }
            catch (Exception ex)
            {
                return Json(new ResponseViewModel { 
                   IsSuccessful = false,
                   Errors = new List<string> { ex.Message }
                });
            }
        }

        [HttpGet]
        public JsonResult randevugetir(string title)
        {
            var getLesson = _bookingService.getBookingByTitle(title);

            var agencyModelToCalendar = new CalendarModel()
            {
                Id = getLesson.Id,
                Title = getLesson.BookingName,
                StartTime = getLesson.BookingTime.ToString("yyyy-MM-dd HH:mm:ss"),
                EndTime = getLesson.BookingTime.ToString("yyyy-MM-dd HH:mm:ss"),
                AllDay = false,
                Color = getLesson.Color,
                TextColor = getLesson.TextColor,
                Student = getLesson.student!.StudentName,
            };

            return Json(new { data = agencyModelToCalendar, IsSuccessful = true });
        }

        [HttpPost]
        public JsonResult derskayityap(string eventsJson)
        {
            var optionsAccess = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            var events = System.Text.Json.JsonSerializer.Deserialize<CalendarModel>(eventsJson, optionsAccess);
            DateTime _currentEndTime = Convert.ToDateTime(events!.StartTime).AddHours(2);

            UserDto? getUser;

            if (User.Identity!.IsAuthenticated)
            {
                getUser = _userService.GetUserByName(User.Identity.Name!);
            }
            else
            {
                return Json(-1);
            }

            var getLesson = _studySevice.getStudyByName(events.Title!);
            var getStudent = _studentService.Get(4);

            CalendarModel newBook = new()
            {
                Id = getLesson.Id,
                Title = events.Title,
                StartTime = events.StartTime,
                EndTime = _currentEndTime.ToString(),
                AllDay = false,
                TextColor = "#fff",
                Color = getLesson.Color,
            };

            byte[] buffer = Guid.NewGuid().ToByteArray();
            string bookingCode = BitConverter.ToUInt32(buffer, 8).ToString();

            _bookingService.Insert(new BookingDto
            {
                StudyId = newBook.Id,
                BookingName = $"{events.Title} #{bookingCode}",
                BookingStatus = true,
                Color = newBook.Color,
                TextColor = "#fff",
                BookingTime = Convert.ToDateTime(newBook.StartTime),
                IsActive = true,
                UserId = getUser.Id,
                UpdatedTime = DateTime.Now,
                CreatedTime = DateTime.Now,
                StudentName = getStudent.StudentName,
                UserName = getUser.UserName,
                StudyName = getLesson.StudyName,
                StudentId = 4,
                BookingCode = bookingCode,
            });

            return Json(1);
        }

        [HttpGet]
        public JsonResult getStudents()
        {
            var students = _studentService.GetAll();
            return Json(new { data = students });
        }

        [HttpGet]
        public JsonResult getLesson()
        {
            var lesson = _studySevice.GetAll();
            return Json(new { data = lesson });
        }

        [HttpPost]
        public JsonResult bookingUpdate(string bookingObject)
        {
            try
            {
                var optionsAccess = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString
                };

                var serializeBooking = System.Text.Json.JsonSerializer.Deserialize<CalendarModel>(bookingObject, optionsAccess);
                var getBooking = _bookingService.getBookingByTitle(serializeBooking!.Title!);

                UserDto? user = null;

                if (User.Identity!.IsAuthenticated)
                {
                    user = _userService.GetUserByName(User.Identity.Name!);
                }

                getBooking.UpdatedTime = DateTime.Now;
                getBooking.BookingName = serializeBooking.Title;
                getBooking.BookingTime = Convert.ToDateTime(serializeBooking.StartTime);
                getBooking.UserId = user!.Id;

                _bookingService.Update(getBooking);

                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
           
        }
    }
}
