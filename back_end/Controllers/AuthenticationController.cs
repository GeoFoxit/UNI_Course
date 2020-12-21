using back_end.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;



namespace back_end.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        ApplicationContext db;
        public AuthenticationController(ApplicationContext context)
        {
            db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Login = "adminn", Password = "password" });
                db.SaveChanges();
            }
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<User>> Get()
        //{
        //    return db.Users.ToList();
        //}

        //[HttpGet("{id}")]
        //public ActionResult<User> GetById(Int32 id)
        //{
        //    User user = db.Users.FirstOrDefault(x => x.Id == id);
        //    if (user == null)
        //        return NotFound();
        //    return new ObjectResult(user);
        //}

        //[HttpPost]
        //public ActionResult<User> AddUser(User user)
        //{
        //    db.Users.Add(user);
        //    db.SaveChanges();
        //    return new ObjectResult(user);
        //}

        //[HttpDelete("{id}")]
        //public ActionResult<User> DeleteUser(Int32 id)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //        return NotFound();

        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    return new ObjectResult(user);
        //}

        [HttpPost("token")]
        public IActionResult Token(User user)
        {
            var identity = GetIdentity(user.Login, user.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return new ObjectResult(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            User user = db.Users.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token");
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
