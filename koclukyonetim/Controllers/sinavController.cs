using kocluk.SERVICES.Dtos.ExamsData;
using kocluk.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace koclukyonetim.Controllers
{
    public class sinavController : Controller
    {

        private readonly IStudentService _studentService;
        private readonly IStudyService _studyService;
        private readonly IUserService _userService;
        private readonly IExamService _examService;

        public sinavController(IStudyService studyService, IStudentService studentService, IExamService examService, IUserService userService)
        {
            _studyService = studyService;
            _examService = examService;
            _studentService = studentService;
            _userService = userService;
        }

        [HttpGet]
        [Route("sinavlar")]
        public IActionResult sinavlar()
        {
            var exams = _examService.GetExamsByPaths();
            return View(exams);
        }

        [HttpGet]
        [Route("sinavekle")]
        public IActionResult sinavekle() 
        {
            ViewBag.Ogrenciler = new SelectList(_studentService.GetAll(),"Id","StudentName");
            ViewBag.Dersler = new SelectList(_studyService.GetAll(), "Id", "StudyName");
            ViewBag.Koclar = new SelectList(_userService.GetUserByRole(1), "Id", "DisplayName");

            return View();
        }

        [HttpPost]
        public IActionResult sinavolustur(ExamsDto model)
        {
            if (ModelState.IsValid)
            {
                _examService.Insert(model);
                return Redirect("/sinavlar");
            }
            else
            {
                ModelState.AddModelError("sinav", "Sınav bilgilerini eksik giriniz!");
                return Redirect("/sinavekle");
            }
        }

        [HttpGet]
        [Route("sinavduzenle")]
        public IActionResult sinavduzenle(int id)
        {
            var exam = _examService.Get(id);
            if(exam != null)
            {
                ViewBag.Ogrenciler = new SelectList(_studentService.GetAll(), "Id", "StudentName", exam.Id);
                ViewBag.Dersler = new SelectList(_studyService.GetAll(), "Id", "StudyName", exam.Id);
                ViewBag.Koclar = new SelectList(_userService.GetUserByRole(1), "Id", "DisplayName", exam.Id);
                return View(exam);
            }
            else
            {
                return Redirect("sinavlar");
            }
        }

        [HttpGet]
        [Route("sinavsil")]
        public IActionResult sinavsil(int id)
        {
            var exam = _examService.Get(id);
            _examService.Delete(exam.Id);
            return Redirect("/sinavlar");
        }

        [HttpGet]
        [Route("sinavdurumduzenle")]
        public IActionResult sinavdurumduzenle(int id)
        {
            var exam = _examService.Get(id);
            
            if(exam.IsActive == true)
            {
                exam.IsActive = false;
            }
            
            else
            {
                exam.IsActive = true;
            }

            _examService.Update(exam);
            return Redirect("/sinavlar");
        }
    }
}
