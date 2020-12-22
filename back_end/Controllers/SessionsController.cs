using back_end.models;
using back_end.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {
        IService<Session> service;
        public SessionsController(ApplicationContext context)
        {
            service = new SessionsService(context);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<Session>> Get()
        {
            return new ActionResult<List<Session>>(service.GetAll());
        }

        //[HttpGet("{id}")]
        //public ActionResult<Session> GetById(Int32 id)
        //{
        //    Session seans = db.Sessions.FirstOrDefault(x => x.Id == id);
        //    if (seans == null)
        //        return NotFound();
        //    return new ObjectResult(seans);
        //}

        [HttpGet("byfilm/{filmId}")]
        public ActionResult<List<Session>> GetByFilmId(Int32 filmId)
        {
            return new ActionResult<List<Session>>(service.GetListById(filmId));
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Session> AddSession(Session session)
        {
            return new ObjectResult(service.Add(session));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Session> DeleteSession(Int32 id)
        {
            Session session = service.Delete(id);
            if (session == null)
                return NotFound();
            return new ObjectResult(session);
        }
    }
}
