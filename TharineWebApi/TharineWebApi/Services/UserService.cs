using System;
using System.Collections.Generic;
using System.Linq;
using TharineWebApi.Models;
using TharineWebApi.Repository;

namespace TharineWebApi.Services
{    
    public class UserService : IUserService
    {
        tharineContext context { get; }
        public UserService(tharineContext _tharineContext)
        {
            context = _tharineContext;
        }
    }
}
