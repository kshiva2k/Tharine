using System.Collections.Generic;
using TharineWebApi.ViewModel;
namespace TharineWebApi.Repository
{
    public interface IUserService
    {
        int ValidateUser(LoginViewModel viewModel);
        bool AddUser(UserViewModel viewModel);
        bool UpdateUser(UserViewModel viewModel);
        UserViewModel GetUser(int id);
        bool UpdatePassword(UserViewModel viewModel);
        bool AddEmployee(UserViewModel viewModel);
        bool DeleteEmployee(int Id);
        List<CommonViewModel> GetRoles();
        List<CommonViewModel> GetServices();
        bool AddAddress(UserAddressViewModel viewModel);
        bool DeleteAddress(int Id);
        List<UserAddressViewModel> GetAddress(int userId);
    }
}
