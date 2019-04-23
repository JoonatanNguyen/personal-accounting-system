

using System.Collections.Generic;
using System.Linq;
using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Repositories;

namespace Personal_Accounting_System_WPFApp.Services
{
    class UserRoleService
    {
        private readonly UserRolesRepository userRolesRepository;

        public UserRoleService()
        {
            userRolesRepository = new UserRolesRepository();
        }

        public void CreateUserRole(UserRoleDto userRole)
        {
            userRolesRepository.CreateUserRole(userRole);
        }

        public int GetUserRole(int userId)
        {
            return userRolesRepository.GetUserRole(userId);
        }

        public List<UserRoleDto> GetChild()
        {
            return userRolesRepository.GetChild();
        }

        public List<UserRoleDto> GetAllUsers()
        {
            var childList = userRolesRepository.GetChild();
            var parentList = userRolesRepository.GetParents();

            return childList.Concat(parentList).ToList();
        }
    }
}
