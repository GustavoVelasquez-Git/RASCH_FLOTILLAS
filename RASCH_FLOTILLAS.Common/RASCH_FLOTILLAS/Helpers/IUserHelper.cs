using Microsoft.AspNetCore.Identity;
using RASCH_FLOTILLAS.Data.Entities;
using RASCH_FLOTILLAS.Models;
using RASCH_FLOTILLAS.Common.Enums;
using System.Threading.Tasks;
using System;

namespace RASCH_FLOTILLAS.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<User> GetUserAsync(Guid id);

        Task<IdentityResult> AddUserAsync(User user, string password);

        //creacion del usuario mediante el registro
        Task<User> AddUserAsync(AddUserViewModel model, Guid imageId, UserType userType);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> DeleteUserAsync(User user);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

    }
}
