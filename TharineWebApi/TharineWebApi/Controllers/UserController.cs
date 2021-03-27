using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TharineWebApi.Repository;
using TharineWebApi.ViewModel;

namespace TharineWebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        IUserService userService { get;  }
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpPost("ValidateUser")]
        public string ValidateUser([FromBody] LoginViewModel viewModel)
        {
            return userService.ValidateUser(viewModel);
        }
    }
}
