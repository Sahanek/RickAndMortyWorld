using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    /// <summary>
        /// Informacje potrzebne do Rejestracji
        /// </summary>
    public class RegisterDto
    {
        /// <summary>
        /// Nazwa użytkownika musi być unikalna
        /// </summary>        
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z",
         ErrorMessage = "Wrong Email Schema")]
        public string Email { get; set; }
        /// <summary>
        /// Hasło
        /// </summary>
        [Required]
        [RegularExpression("(?=^.{8,15}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
            ErrorMessage = "Password must have 1 Uppercase, 1 Lowercase, 1 number, 1 non alphanumeric and 8 to 15 characters")]
        public string Password { get; set; }
    }
}
