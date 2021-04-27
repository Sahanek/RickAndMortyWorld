using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    /// <summary>
    /// Informacje zwracane na frontend
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Nazwa użytkownika
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Email użytkownika
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Token indywidualny dla użytkownika
        /// </summary>
        public string Token { get; set; }

    }
}
