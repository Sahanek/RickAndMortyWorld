using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    /// <summary>
    /// Klasa dzieczy po Identity User. Dziedziczy z niego wszystkie property.
    /// If you want to know more check the implemantation of IdentityUser(Shortcut F12)
    /// </summary>
    public class AppUser : IdentityUser
    {

    }
}
