using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Domain;
using Todo.Core.Infrastructures.Configuration;
using Todo.Core.Infrastructures.Data;
using TodoApi.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;
        public UserController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IOptions<ApplicationSettings> appSetings)
        {
            
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._appSettings = appSetings.Value;
        }


        // GET: api/<UserController>
        [HttpGet]
        
        // Get : /api/UserProfile
        public async Task<IActionResult> GetUserProfile(string userId)
        {
          // var x =  User.Claims.First(e => e.Type == "userId").Value;
            var user = await this._userManager.FindByIdAsync(userId);
            return Ok(new AuthUserDtos
            {
                firstname = user.Fullname,
                email = user.Email,
                lastname = user.UserName,
                userTodos = user.Todos
            });

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AuthUserDtos model)
        {
            IActionResult actionResult = this.BadRequest();

            var applicationUser = new ApplicationUser()
            {
                UserName = model.firstname,
                Email = model.email,
                Fullname = model.lastname,               
                
            };
            try
            {
                var result = await this._userManager.CreateAsync(applicationUser,model.password);
                return Ok(result);
            }
            catch(Exception ex)
            {
                var x = ex.Message;
                return actionResult;
            }         
    
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]AuthUserDtos model)
        {
            
            var user = await this._userManager.FindByEmailAsync(model.email);
            if (user != null && await this._userManager.CheckPasswordAsync(user,model.password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                        new Claim("userId", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._appSettings.JWt_Secret)),SecurityAlgorithms.HmacSha256Signature),
                    
                    
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var SecurityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(SecurityToken);
                return await GetUserProfile(user.Id);
            }

            return this.BadRequest(new { message = "Utilisateur ou mot de passe incorect" });
        }
           
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
