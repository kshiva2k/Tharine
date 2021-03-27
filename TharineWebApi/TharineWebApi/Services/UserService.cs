using System;
using System.Collections.Generic;
using System.Linq;
using TharineWebApi.Models;
using TharineWebApi.Repository;
using TharineWebApi.ViewModel;

namespace TharineWebApi.Services
{    
    public class UserService : IUserService
    {
        tharineContext context { get; }
        public UserService(tharineContext _tharineContext)
        {
            context = _tharineContext;
        }
        public string ValidateUser(LoginViewModel viewModel)
        {
            var item = context.Usermaster.Where(u => u.Status == 1 && u.Username == viewModel.Username && u.Password == viewModel.Password).FirstOrDefault();
            if (item != null)
                return "true";
            else
                return "false";
        }
    }
}
