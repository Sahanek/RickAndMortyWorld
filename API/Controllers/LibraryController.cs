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
    public class LibraryController : BaseApiController
    {
        private readonly LibraryDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public LibraryController(LibraryDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        // GET: LibraryController
        [Authorize]
        [HttpGet]
        public async Task<List<int>> GetCharacters()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return _dbContext.AppUserCharacters.Where(ch => ch.AppUserId == user.Id).Select(x => x.Character.Id).ToList();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<bool> CheckIfCharacterExists(int id)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            var character = _dbContext.AppUserCharacters.Where(ch => ch.AppUserId == user.Id).FirstOrDefault(x => x.CharacterId == id);

            return character is not null;
        }

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

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacterFromLibrary(int id)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            var appUserCharacter = _dbContext.AppUserCharacters.FirstOrDefault(c => c.CharacterId == id);

            _dbContext.AppUserCharacters.Remove(appUserCharacter);

            await _dbContext.SaveChangesAsync();
            return Ok();

        }



    }
}
