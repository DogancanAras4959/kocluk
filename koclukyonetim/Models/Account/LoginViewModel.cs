using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace koclukyonetim.Models.Account
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı Adı")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "{0} gereklidir.")]
        [StringLength(20, MinimumLength=5, ErrorMessage ="{0} uzunluğu {2} ile {1} arasında olmalıdır")]
        public string? AccountName { get; set; }

        [DisplayName("Şifre")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "{0} gereklidir.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} uzunluğu {2} ile {1} arasında olmalıdır")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
