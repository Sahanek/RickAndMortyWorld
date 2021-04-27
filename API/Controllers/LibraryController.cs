using API.Dtos;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Controller zarządzający bibliotekami użytkownika.
    /// </summary>
    public class LibraryController : BaseApiController
    {
        private readonly LibraryDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        /// <summary>
        /// Konstruktor z wstrzykiwanymi zależnościami
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="userManager"></param>
        public LibraryController(LibraryDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        /// <summary>
        /// Zwraca listę id ulubionych bohaterów, dla aktualnie zalogowanego użytkownika.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<List<int>> GetCharacters()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return _dbContext.AppUserCharacters.Where(ch => ch.AppUserId == user.Id).Select(x => x.Character.CharacterId).ToList();
        }


        /// <summary>
        /// GET: ../api/library/{id}
        /// Sprawdza czy dany bohater jest już w bibliotece aktualnego użytkownika.
        /// </summary>
        /// <param name="id">id bohatera do sprawdzenia czy istnieje w bibliotece użytkownika</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<bool> CheckIfCharacterExists(int id)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            var characterDb = _dbContext.Characters.FirstOrDefault(x => x.CharacterId == id);

            var character = _dbContext.AppUserCharacters.Where(ch => ch.AppUserId == user.Id)
                .FirstOrDefault(x => x.CharacterId == characterDb.Id);

            return character is not null;
        }

        /// <summary>
        /// Dodaje do aktualnie zalogowanego użytkownika biblioteki, bohatera.
        /// Jeśli ktoś dodał wcześniej bohatera do własnej biblioteki, będzie on już w bazie danych i zostanie mu przypisany.
        /// </summary>
        /// <param name="character">id bohatera do dodania w formacie JSON</param>
        /// <returns></returns>

        [Authorize]
        [HttpPost]
        public async Task<Character> AddCharacter(CharacterDto character)
        {
            AppUserCharacter appUserChar;
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            var characterInDb = _dbContext.Characters.FirstOrDefault(c => c.CharacterId == character.Id);
            if (characterInDb is null)
            {
                appUserChar = new AppUserCharacter
                {
                    AppUserId = user.Id,
                    Character = new Character
                    {
                        CharacterId = character.Id,
                    }
                };
            }
            else
            {
                appUserChar = new AppUserCharacter
                {
                    AppUserId = user.Id,
                    Character = characterInDb
                };
            }


            await _dbContext.AppUserCharacters.AddAsync(appUserChar);
            await _dbContext.SaveChangesAsync();
            return appUserChar.Character;
        }

        /// <summary>
        /// Usuwa z aktualnie zalogowanego użytkownika biblioteki bohatera o podanym id
        /// </summary>
        /// <param name="id"> id bohatera do usunięcia</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacterFromLibrary(int id)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            var character = _dbContext.Characters.FirstOrDefault(x => x.CharacterId == id);

            var appUserCharacter = _dbContext.AppUserCharacters.Where(ch => ch.AppUserId == user.Id)
                .FirstOrDefault(x => x.CharacterId == character.Id);

            if (appUserCharacter is null) return BadRequest();

            _dbContext.AppUserCharacters.Remove(appUserCharacter);

            await _dbContext.SaveChangesAsync();
            return Ok();

        }



    }
}
