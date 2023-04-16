using kocluk.COMMON.Helpers.Cyroptography;
using kocluk.SERVICES.Dtos.AccountData;
using kocluk.SERVICES.Dtos.AccountRoleData;
using kocluk.SERVICES.Dtos.ImageData;
using kocluk.SERVICES.Dtos.RoleData;
using kocluk.SERVICES.Interface;
using koclukyonetim.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Construction;
using System.Security.Claims;

namespace koclukyonetim.Controllers
{
    public class yonetimController : Controller
    {

        #region Fields

        private readonly IAccountService _accountService;
        private readonly IAccountRoleService _accountRoleService;
        private readonly IImageService _imageService;

        public yonetimController(IAccountService accountService, IAccountRoleService accountRoleService, IImageService imageService)
        {
            _accountService = accountService;
            _accountRoleService = accountRoleService;
            _imageService = imageService;
        }

        #endregion

        #region Yonetim

        [HttpGet]
        public IActionResult anasayfa()
        {
            var userAuth = User.Identity!.IsAuthenticated;
            return userAuth != false ? View() : RedirectToAction("girisyap");
        }

        [HttpGet]
        [Route("girisyap")]
        public IActionResult girisyap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult oturumac(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string passwordEncrypted = new Crypto().TryEncrypt(model.Password!);
                var user = _accountService.login(model.AccountName!, passwordEncrypted);

                if (user == false)
                {
                    ModelState.AddModelError("name", "Kullanıcı adı veya şifre hatalı.");
                    return View(nameof(girisyap));
                }

                else
                {
                    var getUser = _accountService.getUserByName(model.AccountName!);

                    var userClaims = new List<Claim>()
                        {
                            new Claim("Name",getUser.AccountName!),
                            new Claim("UserId", getUser.Id.ToString()),
                            new Claim(ClaimTypes.Name,getUser.AccountName!),
                            new Claim(ClaimTypes.NameIdentifier, getUser.Id.ToString()),
                        };

                    var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

                    HttpContext.SignInAsync(
                        userPrincipal,
                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.UtcNow.AddYears(15)
                        });

                    return RedirectToAction("anasayfa", "yonetim");

                }
            }
            else
            {
                return View(nameof(girisyap));
            }
        }

        [HttpGet]
        [Route("oturumkapat")]
        public IActionResult oturumkapat()
        {
            HttpContext.SignOutAsync();
            return Redirect("/girisyap");
        }

        #endregion

        #region Yöneticiler

        [HttpGet]
        [Route("kullanicilar")]
        public IActionResult kullanicilar()
        {
            var user = _accountService.GetAll();
            return View(user);
        }

        [HttpGet]
        [Route("kullaniciduzenle")]
        public IActionResult kullaniciduzenle(int id)
        {
            var user = _accountService.Get(id);
            user.Password = new Crypto().DeCrypt(user.Password!);
            ViewBag.Roller = new SelectList(_accountRoleService.GetAll(), "Id", "RoleName");
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> kullaniciguncelle(AccountDto account, IFormFile file)
        {
            var user = _accountService.Get(account.Id);

            if (user != null)
            {
                if (file != null)
                {
                    string path = await _imageService.ProcessFile(new ImageInputModel
                    {
                        Content = file.OpenReadStream(),
                        Name = file.Name,
                        Type = file.ContentType,
                    });

                    user.Image = path;
                }

                user.AccountName = account.AccountName;
                user.DisplayName = account.DisplayName;
                user.Password = new Crypto().TryEncrypt(account.Password!);
                user.IsActive = account.IsActive;
                user.IsActivation = account.IsActivation;

                _accountService.Update(user);
                return RedirectToAction("kullaniciduzenle","yonetim", new { id = account.Id });
            }

            else
            {
                return RedirectToAction("kullaniciduzenle","yonetim", new { id = account.Id });
            }

        }

        [HttpGet]
        [Route("kullaniciekle")]
        public IActionResult kullaniciekle()
        {
            ViewBag.Roller = new SelectList(_accountRoleService.GetAll(), "Id", "RoleName");
            return View();
        }

        [HttpGet]
        [Route("kullanicisil")]
        public IActionResult kullanicisil(int id)
        {
            var user = _accountService.Get(id);
            _accountService.Delete(user.Id);
            return Redirect("/kullanicilar");
        }

        [HttpGet]
        [Route("kullanicidurumduzenle")]
        public IActionResult kullanicidurumduzenle(int id)
        {
            var user = _accountService.Get(id);

            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }

            _accountService.Update(user);
            return Redirect("/kullanicilar");
        }

        [HttpPost]
        public async Task<IActionResult> kullaniciolustur(AccountDto account, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (account.Password == account.RePassword)
                {
                    if (file != null)
                    {
                        string path = await _imageService.ProcessFile(new ImageInputModel
                        {
                            Content = file.OpenReadStream(),
                            Name = file.FileName,
                            Type = file.ContentType,
                        });

                        account.Image = path;
                        account.IsActivation = false;
                        string passwordEncrypted = new Crypto().TryEncrypt(account.Password!);
                        account.Password = passwordEncrypted;

                        _accountService.Insert(account);
                        return Redirect("/kullanicilar");
                    }
                    else
                    {
                        ModelState.AddModelError("image", "Fotoğraf seçimi zorunludur!");
                        return Redirect("/kullaniciekle");
                    }
                }
                else
                {
                    ModelState.AddModelError("password", "Şifreler birbiriyle uyuşmuyor!");
                    return Redirect("/kullaniciekle");
                }
            }
            else
            {
                return Redirect("/kullaniciekle");
            }
        }

        #endregion

        #region Roller

        [HttpGet]
        [Route("roller")]
        public IActionResult roller()
        {
            ViewBag.Roller = _accountRoleService.GetAll();
            return View();
        }

        public IActionResult _rolekle()
        {
            return PartialView("_rolekle", new RoleDto());
        }

        [HttpPost]
        public IActionResult rololustur(AccountRoleDto role)
        {

            if (ModelState.IsValid)
            {
                _accountRoleService.Insert(role);
                return Redirect("/roller");
            }

            else
            {
                ModelState.AddModelError("name", "Rol oluşturulurken bir hata meydana geldi!");
                return Redirect("/roller");
            }

        }

        [HttpPost]
        public IActionResult rolguncelle(RoleDto model)
        {
            var role = _accountRoleService.Get(model.Id);
            
            if (role != null) 
            {
                role.RoleName = model.RoleName;
                role.IsActive = model.IsActive;
                role.UpdatedTime = DateTime.Now;

                _accountRoleService.Update(role);
                return Redirect("/roller");
            }
            else
            {
                return Redirect("/roller");
            }
        }

        [HttpGet]
        [Route("rolduzenle")]
        public IActionResult rolduzenle(int id)
        {
            var role = _accountRoleService.Get(id);
            return View(role);
        }

        [HttpGet]
        [Route("rolsil")]
        public IActionResult rolsil(int id)
        {
            var role = _accountRoleService.Get(id);
            _accountRoleService.Delete(role.Id);
            return Redirect("/roller");
        }

        [HttpGet]
        [Route("roldurumduzenle")]
        public IActionResult roldurumduzenle(int id)
        {
            var role = _accountRoleService.Get(id);
            
            if(role.IsActive == true)
            {
                role.IsActive = false;
            }
            else
            {
                role.IsActive = true;
            }

            _accountRoleService.Update(role);
            return Redirect("/roller");
        }

        #endregion

    }
}
