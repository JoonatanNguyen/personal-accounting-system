using Personal_Accounting_System_WPFApp.Dtos;

namespace Personal_Accounting_System_WPFApp.Validators
{
    class RegisterRequestValidators
    {
        public static bool UserRegisterRequestValid(UserDto user, string password)
        {
            return !string.IsNullOrEmpty(user.Name) || !string.IsNullOrEmpty(user.Email) || !string.IsNullOrEmpty(password);
        }
    }
}
