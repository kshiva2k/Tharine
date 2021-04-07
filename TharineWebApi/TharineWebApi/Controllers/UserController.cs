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
        public UserViewModel ValidateUser([FromBody] LoginViewModel viewModel)
        {
            UserViewModel view = new UserViewModel();
            int userid = userService.ValidateUser(viewModel);
            if(userid == 0)
            {
                view.Id = userid;
                view.Name = "Invalid credentials";
            }
            else
            {
                view = userService.GetUser(userid);
            }
            return view;
        }
        [HttpPost("AddUser")]
        public bool AddUser([FromBody] UserViewModel viewModel)
        {
            return userService.AddUser(viewModel);
        }
        [HttpPost("AddEmployee")]
        public bool AddEmployee([FromBody] UserViewModel viewModel)
        {
            return userService.AddEmployee(viewModel);
        }
        [HttpGet("GetRoles")]
        public List<CommonViewModel> GetRoles()
        {
            return userService.GetRoles();
        }
        [HttpGet("GetServices")]
        public List<CommonViewModel> GetServices()
        {
            return userService.GetServices();
        }
    }
}
