using System;
using System.Collections.Generic;
using TharineWebApi.ViewModel;
namespace TharineWebApi.Repository
{
    public interface IUserService
    {
        string ValidateUser(LoginViewModel viewModel);
    }
}
