using kocluk.COMMON.Helpers.Cyroptography;
using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Dtos.ImageData;
using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Dtos.StudyData;
using kocluk.SERVICES.Dtos.UserData;
using kocluk.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace koclukyonetim.Controllers
{
    public class uygulamaController : Controller
    {

        #region Fields

        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly IImageService _imageService;
        private readonly IStudyService _studyService;
        private readonly IBookingService _bookingService;
        private readonly IBookingRequestService _bookingRequestService;
        private readonly IStudyTipService _studyTipService;
        public uygulamaController(IStudentService studentService, IUserService userService, IImageService imageService, IStudyService studyService, IBookingService bookingService, IBookingRequestService bookingRequestService, IStudyTipService studyTipService)
        {
            _studentService = studentService;
            _userService = userService;
            _imageService = imageService;
            _studyService = studyService;
            _bookingService = bookingService;
            _bookingRequestService = bookingRequestService;
            _studyTipService = studyTipService;
        }

        #endregion

        #region Koçlar

        [HttpGet]
        [Route("koclar")]
        public IActionResult koclar()
        {
            var usersByTeach = _userService.GetUserByRole(1);
            return View(usersByTeach);
        }

        [HttpGet]
        [Route("kocekle")]
        public IActionResult kocekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> kocolustur(UserDto model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = await _imageService.ProcessFile(new ImageInputModel
                    {
                        Content = file.OpenReadStream(),
                        Name = file.Name,
                        Type = file.ContentType,
                    });

                    model.Image = path;
                    model.Password = new Crypto().TryEncrypt(model.Password);
                    model.RoleId = 1;

                    await _userService.InsertAsync(model);
                    return Redirect("/koclar");
                }

                else
                {
                    ModelState.AddModelError("image", "Fotoğraf zorunludur");
                    return Redirect("/kocekle");
                }
            }
            else
            {
                ModelState.AddModelError("name", "Eksik veri girmeyiniz");
                return Redirect("/kocekle");
            }
        }

        [HttpPost]
        public async Task<IActionResult> kocguncelle(UserDto model, IFormFile file)
        {
            var roleGet = _userService.Get(model.Id);

            if (roleGet != null)
            {
                if (file != null)
                {
                    string path = await _imageService.ProcessFile(new ImageInputModel
                    {
                        Content = file.OpenReadStream(),
                        Name = file.Name,
                        Type = file.ContentType,
                    });

                    roleGet.Image = path;

                }
                else
                {

                }

                roleGet.UserName = model.UserName;
                roleGet.DisplayName = model.DisplayName;
                roleGet.UpdatedTime = DateTime.Now;
                roleGet.IsActive = model.IsActive;

                if (model.Password != null)
                {
                    roleGet.Password = new Crypto().TryEncrypt(model.Password);
                }

                _userService.Update(roleGet);
                return RedirectToAction("kocduzenle", "uygulama", new { id = model.Id });
            }
            else
            {
                return RedirectToAction("kocduzenle", "uygulama", new { id = model.Id });
            }

        }

        [HttpGet]
        [Route("kocduzenle")]
        public IActionResult kocduzenle(int id)
        {
            var user = _userService.Get(id);
            string passwordEncrypted = new Crypto().TryDecrypt(user.Password);
            user.Password = passwordEncrypted;

            return View(user);
        }

        [HttpGet]
        [Route("kocsil")]
        public IActionResult kocsil(int id)
        {
            var user = _userService.Get(id);
            _userService.Delete(user.Id);
            return Redirect("/koclar");
        }

        [HttpGet]
        [Route("kocdurumduzenle")]
        public IActionResult kocdurumduzenle(int id)
        {
            var user = _userService.Get(id);
            if (user.IsActive == false)
            {
                user.IsActive = true;
            }
            else
            {
                user.IsActive = false;
            }
            _userService.Update(user);
            return Redirect("/koclar");
        }

        #endregion

        #region Veliler

        [HttpGet]
        [Route("veliler")]
        public IActionResult veliler()
        {
            var usersByTeach = _userService.GetUserByRole(2);
            return View(usersByTeach);
        }

        [HttpGet]
        [Route("veliekle")]
        public IActionResult veliekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> veliolustur(UserDto model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = await _imageService.ProcessFile(new ImageInputModel
                    {
                        Content = file.OpenReadStream(),
                        Name = file.Name,
                        Type = file.ContentType,
                    });

                    model.Image = path;
                    model.Password = new Crypto().TryEncrypt(model.Password);
                    model.RoleId = 2;

                    await _userService.InsertAsync(model);
                    return Redirect("/veliler");
                }

                else
                {
                    ModelState.AddModelError("image", "Fotoğraf zorunludur");
                    return Redirect("/veliekle");
                }
            }
            else
            {
                ModelState.AddModelError("name", "Eksik veri girmeyiniz");
                return Redirect("/veliekle");
            }
        }

        [HttpPost]
        public async Task<IActionResult> veliguncelle(UserDto model, IFormFile file)
        {
            var roleGet = _userService.Get(model.Id);

            if (roleGet != null)
            {
                if (file != null)
                {
                    string path = await _imageService.ProcessFile(new ImageInputModel
                    {
                        Content = file.OpenReadStream(),
                        Name = file.Name,
                        Type = file.ContentType,
                    });

                    roleGet.Image = path;

                }
                else
                {

                }

                roleGet.UserName = model.UserName;
                roleGet.DisplayName = model.DisplayName;
                roleGet.UpdatedTime = DateTime.Now;
                roleGet.IsActive = model.IsActive;

                if (model.Password != null)
                {
                    roleGet.Password = new Crypto().TryEncrypt(model.Password);
                }

                _userService.Update(roleGet);
                return RedirectToAction("veliduzenle", "uygulama", new { id = model.Id });
            }
            else
            {
                return RedirectToAction("veliduzenle", "uygulama", new { id = model.Id });
            }

        }

        [HttpGet]
        [Route("veliduzenle")]
        public IActionResult veliduzenle(int id)
        {
            var user = _userService.Get(id);
            string passwordEncrypted = new Crypto().TryDecrypt(user.Password);
            user.Password = passwordEncrypted;

            return View(user);
        }

        [HttpGet]
        [Route("velisil")]
        public IActionResult velisil(int id)
        {
            var user = _userService.Get(id);
            _userService.Delete(user.Id);
            return Redirect("/koclar");
        }

        [HttpGet]
        [Route("velidurumduzenle")]
        public IActionResult velidurumduzenle(int id)
        {
            var user = _userService.Get(id);
            if (user.IsActive == false)
            {
                user.IsActive = true;
            }
            else
            {
                user.IsActive = false;
            }
            _userService.Update(user);
            return Redirect("/veliler");
        }

        #endregion

        #region Ogrenciler

        [HttpGet]
        [Route("ogrenciler")]
        public async Task<IActionResult> ogrenciler()
        {
            var students = await _studentService.GetAllAsync();
            return View(students);
        }

        [HttpGet]
        [Route("ogrenciekle")]
        public IActionResult ogrenciekle()
        {
            var users = _userService.GetUserByRole(2);
            ViewBag.Users = new SelectList(users, "Id", "DisplayName");
            return View();
        }

        [HttpGet]
        [Route("ogrenciduzenle")]
        public IActionResult ogrenciduzenle(int id)
        {
            var student = _studentService.Get(id);
            ViewBag.Users = new SelectList(_userService.GetUserByRole(2), "Id", "DisplayName", student.Id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> ogrenciolustur(StudentsDto model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = await _imageService.ProcessFile(new ImageInputModel
                    {
                        Content = file.OpenReadStream(),
                        Name = file.Name,
                        Type = file.ContentType,
                    });

                    model.Image = path;

                    _studentService.Insert(model);

                    return Redirect("/ogrenciler");
                }
                else
                {
                    ModelState.AddModelError("student", "Bölümleri eksiksiz giriniz");
                    return Redirect("/ogrenciekle");
                }
            }
            else
            {
                ModelState.AddModelError("student", "Bölümleri eksiksiz giriniz");
                return Redirect("/ogrenciekle");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ogrenciguncelle(StudentsDto model, IFormFile file)
        {
            var student = _studentService.Get(model.Id);

            if (file != null)
            {
                string path = await _imageService.ProcessFile(new ImageInputModel
                {

                    Content = file.OpenReadStream(),
                    Name = file.Name,
                    Type = file.ContentType,
                });

                student.Image = path;
            }

            else
            {

            }

            student.StudentName = model.StudentName;
            student.ClassLevel = model.ClassLevel;
            student.CountryId = model.CountryId;
            student.IsActive = model.IsActive;
            student.UserId = model.UserId;
            student.UpdatedTime = DateTime.Now;

            _studentService.Update(student);
            return RedirectToAction("ogrenciduzenle", "uygulama", new { id = model.Id });

        }

        [HttpGet]
        [Route("ogrencisil")]
        public IActionResult ogrencisil(int id)
        {
            var student = _studentService.Get(id);
            _studentService.Delete(student.Id);
            return Redirect("/ogrenciler");
        }

        [HttpGet]
        [Route("ogrencidurumduzenle")]
        public IActionResult ogrencidurumduzenle(int id)
        {
            var student = _studentService.Get(id);
            if (student.IsActive == true)
            {
                student.IsActive = false;
            }
            else
            {
                student.IsActive = true;
            }

            _studentService.Update(student);
            return Redirect("/ogrenciler");
        }

        #endregion

        #region Dersler

        [HttpGet]
        [Route("dersler")]
        public IActionResult dersler()
        {
            var studies = _studyService.GetAll();
            return View(studies);
        }

        [HttpGet]
        [Route("dersekle")]
        public IActionResult dersekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> dersolustur(StudyDto model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = await _imageService.ProcessFile(new ImageInputModel
                    {
                        Content = file.OpenReadStream(),
                        Name = file.Name,
                        Type = file.ContentType
                    });

                    _studyService.Insert(model);
                    return Redirect("/dersler");
                }
                else
                {
                    ModelState.AddModelError("dershata", "Fotoğraf eklenmesi zorunludur!");
                    return Redirect("/dersekle");
                }
            }
            else
            {
                ModelState.AddModelError("dershata", "Ders oluşturulurken zorunlu alanları eksiksiz doldurunuz!");
                return Redirect("/dersekle");
            }
        }

        [HttpGet]
        [Route("dersduzenle")]
        public IActionResult dersduzenle(int id)
        {
            var study = _studyService.Get(id);
            return View(study);
        }

        [HttpPost]
        public async Task<IActionResult> dersguncelle(StudyDto model, IFormFile file)
        {
            var studyGet = _studyService.Get(model.Id);

            if (studyGet != null)
            {
                if (file != null)
                {
                    string path = await _imageService.ProcessFile(new ImageInputModel
                    {
                        Content = file.OpenReadStream(),
                        Type = file.ContentType,
                        Name = file.Name,
                    });

                }

                studyGet.StudyName = model.StudyName;
                studyGet.UpdatedTime = DateTime.Now;
                studyGet.Type = model.Type;
                studyGet.Color = model.Color;

                _studyService.Update(studyGet);
                return RedirectToAction("dersduzenle", "uygulama", new { id = model.Id });

            }
            else
            {
                return RedirectToAction("dersduzenle", "uygulama", new { id = model.Id });
            }
        }

        [HttpGet]
        [Route("derssil")]
        public IActionResult derssil(int id)
        {
            var study = _studyService.Get(id);
            _studyService.Delete(study.Id);
            return Redirect("/dersler");
        }

        [HttpGet]
        [Route("dersdurumduzenle")]
        public IActionResult dersdurumduzenle(int id)
        {
            var study = _studyService.Get(id);

            if (study.IsActive == true)
            {
                study.IsActive = false;
            }

            else
            {
                study.IsActive = true;
            }

            _studyService.Update(study);

            return Redirect("/dersler");
        }

        #endregion

        #region DersKonulari

        [HttpGet]
        [Route("derskonulari")]
        public IActionResult derskonulari(int id)
        {
            var studyTips = _studyTipService.GetStudyTipsWithStudy(id);
            return View(studyTips);
        }

        [HttpGet]
        [Route("derskonusuekle")]
        public IActionResult derskonusuekle()
        {
            ViewBag.Dersler = new SelectList(_studyService.GetAll(), "Id", "StudyName");
            return View();
        }

        [HttpPost]
        public IActionResult derkonususolustur(StudyTipDto model)
        {
            if (ModelState.IsValid)
            {
                _studyTipService.Insert(model);
                return Redirect($"/derskonulari?Id={model.StudyId}");
            }
            else
            {
                ModelState.AddModelError("dershata", "Ders konusu oluşturulurken zorunlu alanları eksiksiz doldurunuz!");
                return Redirect("/derskonusuekle");
            }
        }

        [HttpGet]
        [Route("derskonusuduzenle")]
        public IActionResult derskonusuduzenle(int id)
        {
            var studyTip = _studyTipService.Get(id);
            return View(studyTip);
        }

        [HttpPost]
        public IActionResult derskonusuguncelle(StudyTipDto model)
        {
            var studyTipGet = _studyTipService.Get(model.Id);

            if (studyTipGet != null)
            {

                studyTipGet.TipName = model.TipName;
                studyTipGet.StudyId = model.StudyId;
                studyTipGet.UpdatedTime = DateTime.Now;
             
                _studyTipService.Update(studyTipGet);
                return RedirectToAction("derskonusuduzenle", "uygulama", new { id = model.Id });

            }
            else
            {
                return RedirectToAction("derskonusuduzenle", "uygulama", new { id = model.Id });
            }
        }

        [HttpGet]
        [Route("derskonususil")]
        public IActionResult derskonususil(int id)
        {
            var studyTip = _studyTipService.Get(id);
            _studyTipService.Delete(studyTip.Id);
            return Redirect($"/derskonulari?Id={studyTip.StudyId}");
        }

        [HttpGet]
        [Route("derskonudurumduzenle")]
        public IActionResult derskonudurumduzenle(int id)
        {
            var studyTip = _studyTipService.Get(id);

            if (studyTip.IsActive == true)
            {
                studyTip.IsActive = false;
            }

            else
            {
                studyTip.IsActive = true;
            }

            _studyTipService.Update(studyTip);

            return Redirect($"/derskonulari?Id={studyTip.StudyId}");
        }

        #endregion

        #region Randevular

        [HttpGet]
        [Route("randevular")]
        public IActionResult randevular()
        {
            return View(_bookingService.GetAll());
        }

        [HttpGet]
        [Route("randevuolustur")]
        public IActionResult randevuolustur()
        {
            ViewBag.Studies = new SelectList(_studyService.GetAll(), "Id", "StudyName");
            ViewBag.Students = new SelectList(_studentService.GetAll(), "Id", "StudentName");
            ViewBag.Teachers = new SelectList(_userService.GetAll(), "Id", "UserName");
            return View();
        }

        [HttpGet]
        [Route("randevuduzenle")]
        public IActionResult randevuduzenle(int id)
        {
            var book = _bookingService.Get(id);

            ViewBag.Studies = new SelectList(_studyService.GetAll(), "Id", "StudyName", book.StudyId);
            ViewBag.Students = new SelectList(_studentService.GetAll(), "Id", "StudentName", book.StudentId);
            ViewBag.Teachers = new SelectList(_userService.GetAll(), "Id", "DisplayName", book.UserId);

            return View(book);
        }

        [HttpPost]
        public IActionResult randevuguncelle(BookingDto booking)
        {
            var getBooking = _bookingService.Get(booking.Id);

            if (getBooking != null)
            {
                getBooking.StudentId = booking.StudentId;
                getBooking.UserId = booking.UserId;
                getBooking.StudyId = booking.StudyId;
                getBooking.BookingTime = booking.BookingTime;
                getBooking.BookingStatus = booking.BookingStatus;
                getBooking.UpdatedTime = DateTime.Now;
                getBooking.IsActive = booking.IsActive;

                var user = _userService.Get(booking.UserId);
                var student = _studentService.Get(booking.StudentId);
                var study = _studyService.Get(booking.StudyId);

                getBooking.UserName = user.DisplayName;
                getBooking.StudyName = study.StudyName;
                getBooking.StudentName = student.StudentName;

                _bookingService.Update(getBooking);
                return Redirect($"/randevuduzenle?Id={getBooking.Id}");
            }
            else
            {
                return Redirect($"/randevuduzenle?Id={booking.Id}");
            }
        }

        [HttpGet]
        [Route("randevudurumduzenle")]
        public IActionResult randevudurumduzenle(int Id)
        {
            var book = _bookingService.Get(Id);

            if (book != null)
            {

                if (book.IsActive == true)
                    book.IsActive = false;

                else
                    book.IsActive = true;

                _bookingService.Update(book);
                return Redirect("/randevular");

            }

            else
            {
                return Redirect("/randevular");
            }
        }

        [HttpGet]
        [Route("randevusil")]
        public IActionResult randevusil(int id)
        {
            var book = _bookingService.Get(id);

            if (book != null)
                _bookingService.Delete(book.Id);

            else
                return Redirect("/randevular");

            return Redirect("/randevular");
        }

        [HttpGet]
        [Route("randevutalepleri")]
        public IActionResult randevutalepleri()
        {
            var requests = _bookingRequestService.GetAll();
            return View(requests);
        }

        [HttpGet]
        [Route("randevuonayla")]
        public IActionResult randevuonayla(int id)
        {
            var getRequest = _bookingRequestService.Get(id);

            if (getRequest != null)
            {
                getRequest.BookingStatus = true;
                getRequest.IsActive = true;
                getRequest.BookingProcess = "Onaylandı";

                _bookingRequestService.Update(getRequest);

                var getStudy = _studyService.getStudyByName(getRequest.StudyName!);
                var getStudent = _studentService.GetStudentByName(getRequest.StudentName!);
                var getUser = _userService.GetUserByDisplayName(getRequest.TeacherName!);

                byte[] buffer = Guid.NewGuid().ToByteArray();
                string bookingCode = BitConverter.ToUInt32(buffer, 8).ToString();

                BookingDto newBooking = new()
                {
                    BookingStatus = true,
                    IsActive = true,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    StudentId = getStudent.Id,
                    StudentName = getStudent.StudentName,
                    StudyName = getStudy.StudyName,
                    StudyId = getStudy.Id,
                    UserId = getUser.Id,
                    UserName = getUser.UserName,
                    BookingCode = bookingCode,
                    BookingTime = getRequest.BookingTime,
                    BookingName = $"{getStudy.StudyName} #{bookingCode}",
                    Color = getStudy.Color,
                    TextColor = "#000",
                };

                _bookingService.Insert(newBooking);
                return Redirect("/randevutalepleri");
            }

            else
            {
                return Redirect("/randevutalepleri");
            }
        }

        [HttpGet]
        [Route("randevureddet")]
        public IActionResult randevureddet(int id)
        {
            var getRequest = _bookingRequestService.Get(id);
            if (getRequest != null)
            {
                getRequest.BookingProcess = "Reddedildi";
                getRequest.BookingStatus = false;
                getRequest.IsActive = false;
                _bookingRequestService.Update(getRequest);
            }
            return Redirect("/randevutalepleri");
        }

        [HttpGet]
        [Route("randevutalebinisil")]
        public IActionResult randevutalebinisil(int id)
        {
            var getRequest = _bookingRequestService.Get(id);
            if (getRequest != null)
            {
                _bookingRequestService.Delete(getRequest.Id);
            }
            return Redirect("/randevutalepleri");
        }

        #endregion
    }
}
