using System.Data.Common;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Nepremicnine_RGIS.Controllers
{
    [ApiController]
    [Route("api/auth/")]
    public class AvtentikacijaController : ControllerBase
    {
        private readonly BazaContext _db;
        
        public AvtentikacijaController(BazaContext db)
        {
            _db = db;
        }

        [HttpPost("registracija")]
        public async Task<IActionResult> Registracija(RegistracijaDTO dto)
        {
            bool obstaja = await _db.Uporabniki.AnyAsync(u => u.UporabniskoIme == dto.UporabniskoIme);
            if (obstaja)
            {
                return Conflict("Uporabniško ime je že zasedeno");
            }

            var hasher = new PasswordHasher<Uporabnik>();

            var uporabnik = new Uporabnik
            {
                UporabniskoIme = dto.UporabniskoIme,
            };
            uporabnik.GesloHash = hasher.HashPassword(uporabnik, dto.Geslo);

            _db.Uporabniki.Add(uporabnik);
            await _db.SaveChangesAsync();

            return StatusCode(201);
        }
        [HttpPost("prijava")]
        public async Task<IActionResult> Prijava(PrijavaDTO dto)
        {
            var uporabnik = await _db.Uporabniki.FirstAsync(u => u.UporabniskoIme == dto.uporabniskoIme);
            if(uporabnik == null)
            {
                return Unauthorized("Napačno uporabniško ime ali geslo.");
            }

            var hasher =  new PasswordHasher<Uporabnik>();
            var rezultat = hasher.VerifyHashedPassword(uporabnik, uporabnik.GesloHash, dto.Geslo);

            if(rezultat == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Napačno uporabniško ime ali geslo.");
            }

            return StatusCode(200);
        }

    }
}