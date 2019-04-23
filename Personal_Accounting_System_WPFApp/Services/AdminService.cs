using System;
using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Repositories;
using Personal_Accounting_System_WPFApp.Validators;
using Personal_Accounting_System_WPFApp.Helpers;

namespace Personal_Accounting_System_WPFApp.Services
{
    class AdminService
    {
        private readonly AdminRepository adminRepository;
        private readonly UserRolesRepository userRolesRepository;

        public AdminService()
        {
            adminRepository = new AdminRepository();
            userRolesRepository = new UserRolesRepository();
        }
        public void DisableUser(UserDto user)
        {
            adminRepository.DisableUser(user);
        }

    }
}
