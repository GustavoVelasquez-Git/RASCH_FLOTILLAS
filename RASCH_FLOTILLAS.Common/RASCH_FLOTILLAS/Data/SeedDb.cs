using RASCH_FLOTILLAS.Common.Enums;
using RASCH_FLOTILLAS.Data.Entities;
using RASCH_FLOTILLAS.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace RASCH_FLOTILLAS.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }


        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckBusinessAsync();
            await CheckRolesAsycn();
            await CheckUserAsync("Luis", "Salazar", "luis@yopmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.Admin);
            await CheckUserAsync("Juan", "Zuluaga", "zulu@yopmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.User);
            await CheckUserAsync("Ledys", "Bedoya", "ledys@yopmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.User);
            await CheckUserAsync("Sandra", "Lopera", "sandra@yopmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.Admin);
        }

        private async Task CheckUserAsync(string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Business = _context.Business.FirstOrDefault(x => x.Description == "RASCH"),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task CheckBusinessAsync()
        {
            if (!_context.Business.Any())
            {
                _context.Business.Add(new Business { Description = "RASCH" });
                _context.Business.Add(new Business { Description = "Amazon" });
                _context.Business.Add(new Business { Description = "Telmex" });
                _context.Business.Add(new Business { Description = "Banco Azteca" });
                await _context.SaveChangesAsync();
            }
        }


        private async Task CheckRolesAsycn()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

    }
}