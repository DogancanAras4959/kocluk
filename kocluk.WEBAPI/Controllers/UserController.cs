using kocluk.COMMON.Helpers.Cyroptography;
using kocluk.SERVICES.Dtos.UserData;
using kocluk.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;

namespace kocluk.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            return user == null ? NotFound() : user;
        }

        [HttpGet("getUser")]
        public async Task<ActionResult<UserDto>> GetUserByUserName([FromQuery] string userName)
        {
            var user = await _userService.GetUserAsyncUserName(userName);
            return user == null ? NotFound() : user;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, UserDto user)
        {
            if (id == user.Id)
                return BadRequest();

            await _userService.UpdateAsync(user);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto user)
        {
            await _userService.InsertAsync(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            
            if(user != null)
            _userService.Delete(user.Id);
            
            return NoContent();
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> login([FromBody] UserDto users)
        //{
        //    string passwordGenerate = new Crypto().TryEncrypt(users.Password);
        //    var user = _userService.login(users.UserName, passwordGenerate);

        //    return user != null ? BadRequest("Kullanıcı adı veya şifre yanlış") : Ok(user);
        //}
         
    }
}
