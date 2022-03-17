using ShoppingPrep.Data.Entities;
using ShoppingPrep.Enums;
using ShoppingPrep.Helpers;

namespace ShoppingPrep.Data
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
            await CheckCategoriesAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Rafa", "Saints", "rafasaints@yopmail.com", "322 311 4289", "Rua da Liberdade", UserType.Admin);
            await CheckUserAsync("2020", "Mada", "Saints", "madasaints@yopmail.com", "322 311 4289", "Rua da Liberdade", UserType.User);
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if(user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Portugal",
                    States = new List<State>()
                    {
                        new State
                        {
                            Name = "Estremadura",
                            Cities = new List<City>()
                            {
                                new City { Name = "Lisboa" },
                                new City { Name = "Loures" },
                                new City { Name = "Setúbal" },
                                new City { Name = "Torres Vedras" },
                                new City { Name = "Almada" },
                            }
                        },

                        new State
                        {
                            Name = "Ribatejo",
                            Cities = new List<City>()
                            {
                                new City { Name = "Cartaxo" },
                                new City { Name = "Santarém" },
                            }
                        },
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos da Améria",
                    States = new List<State>()
                    {
                        new State
                        {
                            Name = "Florida",
                            Cities = new List<City>()
                            {
                                new City { Name = "Miami" },
                                new City { Name = "Melbourne" },
                            }
                        },

                        new State
                        {
                            Name = "Nova York",
                            Cities = new List<City>()
                            {
                                new City { Name = "Montgomery" },
                                new City { Name = "New Jersey" },
                            }
                        },
                    }
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Tecnología" });
                _context.Categories.Add(new Category { Name = "Roupa" });
                _context.Categories.Add(new Category { Name = "Calçado" });
                _context.Categories.Add(new Category { Name = "Beleza" });
                _context.Categories.Add(new Category { Name = "Nutrição" });
                _context.Categories.Add(new Category { Name = "Desporto" });
                _context.Categories.Add(new Category { Name = "Apple" });
                _context.Categories.Add(new Category { Name = "Brinquedos" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
