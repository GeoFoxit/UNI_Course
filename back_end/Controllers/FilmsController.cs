using back_end.models;
using back_end.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        IService<Film> service;
        public FilmsController(ApplicationContext context)
        {
            service = new FilmsService(context);
        }

        [HttpGet]
        public ActionResult<List<Film>> Get()
        {
            return new ActionResult<List<Film>>(service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Film> GetById(Int32 id)
        {
            Film film = service.GetById(id);
            if (film == null)
                return NotFound();
            return new ObjectResult(film);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Film> AddFilm(Film film)
        {
            return new ObjectResult(service.Add(film));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Film> DeleteFilm(Int32 id)
        {
            Film film = service.Delete(id);
            if (film == null)
                return NotFound();
            return new ObjectResult(film);
        }
    }
}
