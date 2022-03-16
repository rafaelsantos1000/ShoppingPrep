using ShoppingPrep.Data.Entities;

namespace ShoppingPrep.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }


        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
            await CheckCountriesAsync();
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
