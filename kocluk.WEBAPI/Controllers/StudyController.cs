using kocluk.SERVICES.Dtos.StudyData;
using kocluk.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;

namespace kocluk.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudyController : Controller
    {
        private readonly IStudyService _studyService;

        public StudyController(IStudyService studyService)
        {
            _studyService = studyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudyDto>>> GetStudies()
        {
            return await _studyService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudyDto>> GetStudy(int id)
        {
            var study = await _studyService.GetStudyAsync(id);
            return study == null ? NotFound() : study;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutStudy(int id, StudyDto study)
        {
            if (id == study.Id)
                return BadRequest();

            await _studyService.UpdateAsync(study);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<StudyDto>> PostStudy(StudyDto study)
        {
            await _studyService.InsertAsync(study);
            return CreatedAtAction("GetStudy", new { id = study.Id }, study);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudyDto>> DeleteStudy(int id)
        {
            var study = await _studyService.GetStudyAsync(id);
            if (study != null)
                _studyService.Delete(study.Id);
            return NoContent();
        }
    }
}
