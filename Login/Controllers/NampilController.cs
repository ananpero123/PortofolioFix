using Login.Context;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NampilController : ControllerBase
    {
        private readonly Dbcontexts _getsContext;

        public NampilController(Dbcontexts getscontext)
        {
            _getsContext = getscontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Portofolio>>> GetPorto()
        {
            return Ok(await _getsContext.Portofolio.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Portofolio>> GetPortoById(int id)
        {
            var portofolio = await _getsContext.Portofolio.FindAsync(id);

            if (portofolio == null)
            {
                return NotFound();
            }

            return Ok(portofolio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePortofolio(int id, [FromBody] Portofolio updatedPortofolio)
        {
            if (id != updatedPortofolio.id)
            {
                return BadRequest();
            }

            var existingPortofolio = await _getsContext.Portofolio.FindAsync(id);

            if (existingPortofolio == null)
            {
                return NotFound();
            }

            existingPortofolio.nama = updatedPortofolio.nama;
            existingPortofolio.keahlian = updatedPortofolio.keahlian;
            existingPortofolio.keahlian1 = updatedPortofolio.keahlian1;
            existingPortofolio.keahlian2 = updatedPortofolio.keahlian2;
            existingPortofolio.keahlian3 = updatedPortofolio.keahlian3;
            existingPortofolio.pengalaman2 = updatedPortofolio.pengalaman2;
            existingPortofolio.pengalaman3 = updatedPortofolio.pengalaman3;
            existingPortofolio.foto = updatedPortofolio.foto;
            existingPortofolio.link = updatedPortofolio.link;
            existingPortofolio.telp = updatedPortofolio.telp;
            existingPortofolio.deskripsi = updatedPortofolio.deskripsi;
            existingPortofolio.pendidikan = updatedPortofolio.pendidikan;
            existingPortofolio.pengalaman = updatedPortofolio.pengalaman;

            try
            {
                _getsContext.Entry(existingPortofolio).State = EntityState.Modified;
                await _getsContext.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500);
            }
        }


    }
}
