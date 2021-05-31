using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Core.Domain;
using TodoApi.Dtos;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        #region Property
        private UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructor
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        #endregion



        [HttpGet]
        [Authorize]
        // Get : /api/UserProfile
        public async Task<IActionResult> GetUserProfile()        
        {
            string userId = User.Claims.First(e => e.Type == "userId").Value;
            var user = await this._userManager.FindByIdAsync(userId);
            return Ok(new AuthUserDtos
            {
                firstname = user.Fullname,
                email = user.Email,
                lastname = user.UserName,
                userTodos = user.Todos
            }) ;

        }
    }
}
