using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfisi.WebUI.Models
{
    public class AgentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        public string ConfirmPassword { get; set; }
    }
}
