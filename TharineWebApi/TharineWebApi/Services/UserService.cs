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
        public int ValidateUser(LoginViewModel viewModel)
        {
            var item = context.Usermaster.Where(u => u.Status == 1 && u.Username == viewModel.Username && u.Password == viewModel.Password).FirstOrDefault();
            if (item != null)
            {
                return item.Id;
            }
            else
            {
                return 0;
            }
        }
        public bool AddUser(UserViewModel viewModel)
        {
            try
            {
                var record = new Customermaster()
                {
                    Name = viewModel.Name,
                    Mobileno = viewModel.MobileNo,
                    Address = viewModel.Address,
                    City = viewModel.City,
                    State = viewModel.State
                };
                context.Customermaster.Add(record);
                context.Usermaster.Add(new Usermaster()
                {
                    Customerid = record.Id,
                    Username = viewModel.MobileNo,
                    Password = viewModel.Password,
                    Roleid = viewModel.RoleId,
                    Status = 1
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateUser(UserViewModel viewModel)
        {
            try
            {
                var customerid = context.Usermaster.Where(x => x.Id == viewModel.Id).FirstOrDefault().Customerid;
                var record = context.Customermaster.Where(x => x.Id == customerid).FirstOrDefault();
                record.Name = viewModel.Name;
                record.Address = viewModel.Address;
                record.City = viewModel.City;
                record.State = viewModel.State;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public UserViewModel GetUser(int id)
        {
            return context.Usermaster.Where(x => x.Id == id)
                .Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    Name = x.Username,
                    RoleId = x.Roleid.GetValueOrDefault()
                }).FirstOrDefault();
        }
        public bool UpdatePassword(UserViewModel viewModel)
        {
            try
            {
                var record = context.Usermaster.Where(x => x.Id == viewModel.Id).FirstOrDefault();
                record.Password = viewModel.Password;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddEmployee(UserViewModel viewModel)
        {
            try
            {
                context.Usermaster.Add(new Usermaster()
                {
                    Clientid = viewModel.ClientId,
                    Username = viewModel.MobileNo,
                    Password = viewModel.Password,
                    Roleid = viewModel.RoleId,
                    Status = 1
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteEmployee(int Id)
        {
            try
            {
                var record = context.Usermaster.Where(x => x.Id == Id).FirstOrDefault();
                record.Status = 0;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<CommonViewModel> GetRoles()
        {
            return context.Rolemaster.Where(x => x.Active == 1)
                .Select(x => new CommonViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }
        public List<CommonViewModel> GetServices()
        {
            return context.Servicemaster.Where(x => x.Active == 1)
                .Select(x => new CommonViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }
        public bool AddAddress(UserAddressViewModel viewModel)
        {
            try
            {
                context.Useraddress.Add(new Useraddress()
                {
                    Userid = viewModel.Userid,
                    Name = viewModel.Name,
                    Address = viewModel.Address,
                    City = viewModel.City,
                    State = viewModel.State,
                    Contactnumber = viewModel.Contactnumber
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteAddress(int Id)
        {
            try
            {
                var record = context.Useraddress.Where(x => x.Id == Id).FirstOrDefault();
                context.Useraddress.Remove(record);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<UserAddressViewModel> GetAddress(int userId)
        {
            return context.Useraddress.Where(x => x.Userid.Value == userId)
                .Select(a => new UserAddressViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Address = a.Address,
                    City = a.City,
                    State = a.State,
                    Contactnumber = a.Contactnumber
                }).ToList();
        }
    }
}
