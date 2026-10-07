using Computer.Controllers.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Computer.Controllers
{
    [Route("osystem")]
    [ApiController]
    public class OsystemController : ControllerBase
    {
        public ComputerShopDbContext context = new ComputerShopDbContext();
        [HttpGet("getAll")]
        public object GetallOsystem()
        {
            var users = context.Osystems.ToList();
            return new { message = "Sikeres lekérdezés", result = users };
        }
        [HttpPost]
        public object AddNewOsystem(OsystemDTOs dto)
        {
            var osystem = new Osystem
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                version = dto.version,
                RegisterTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.Osystems.Add(osystem);
            context.SaveChanges();
            return StatusCode(201 ,new { message = "Sikeres hozzáadás:", result = osystem });
        }
        [HttpPut("update")]
        public object UpdateOsystem(Osystem osystem)
        {
            var existingOsystem = context.Osystems.FirstOrDefault(o => o.ID == osystem.ID);
            if (existingOsystem == null)
            {
                return NotFound(new { message = "Nem található a megadott operációs rendszer." });
            }
            existingOsystem.Name = osystem.Name;
            existingOsystem.version = osystem.version;
            existingOsystem.UpdateTime = DateTime.Now;
            context.SaveChanges();
            return new { message = "Sikeres frissítés:", result = existingOsystem };
        }
    }
}
