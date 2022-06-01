using RASCH_FLOTILLAS.Data.Entities;
using RASCH_FLOTILLAS.Models;
using System;
using System.Threading.Tasks;

namespace RASCH_FLOTILLAS.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew);

        UserViewModel ToUserViewModel(User user);

    }
}