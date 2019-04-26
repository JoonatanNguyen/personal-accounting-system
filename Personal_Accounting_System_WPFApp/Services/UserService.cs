using Personal_Accounting_System_WPFApp.Dtos;
using Personal_Accounting_System_WPFApp.Repositories;
using Personal_Accounting_System_WPFApp.Validators;
using Personal_Accounting_System_WPFApp.Helpers;
using System;

namespace Personal_Accounting_System_WPFApp.Services
{
    class UserService
    {
        private readonly UserRepository userRepository;
        private readonly UserRolesRepository userRolesRepository;

        public UserService()
        {
            userRepository = new UserRepository();
            userRolesRepository = new UserRolesRepository();
        }

        public void RegisterUser(UserDto user, string password)
        {
            if (!RegisterRequestValidators.UserRegisterRequestValid(user, password))
            {
                throw new Exception("Validation failed");
            }
            if (!userRepository.IsEmailAvailable(user.Email))
            {
                throw new Exception("Email Available");
            }
            var hashedPassword = PasswordHasher.Hash(password);
            userRepository.RegisterUser(user, hashedPassword);
            var currentUserId = userRepository.GetUserId(user.Email);
            var accountService = new AccountService();
            accountService.CreateAccount(new AccountDto
            {
                UserId = currentUserId
            });
            var userRoleService = new UserRoleService();
            userRoleService.CreateUserRole(new UserRoleDto
            {
                UserId = currentUserId,
                RoleId = 2
            });
        }

        public bool LoginUser(string email, string password)
        {
            var hash = userRepository.GetHash(email);
            var currenUserId = userRepository.GetUserId(email);

            if(userRepository.IsUserAvailabe(currenUserId))
            {
                return false;
            }
            if (string.IsNullOrEmpty(hash) || !PasswordHasher.CompareHash(password, hash))
            {
                return false;
            }
            return true;
        }

        public bool IsParents(string email)
        {
            var currenUserId = userRepository.GetUserId(email);
            var currentUserRole = userRolesRepository.GetUserRole(currenUserId);

            if (currentUserRole == 2)
            {
                return false;
            }

            return true;
        }

        public bool IsAdmin(string email)
        {
            var currentUserId = userRepository.GetUserId(email);
            var currentUserRole = userRolesRepository.GetUserRole(currentUserId);

            if (currentUserRole != 1)
            {
                return false;
            }

            return true;
        }
    }
}
