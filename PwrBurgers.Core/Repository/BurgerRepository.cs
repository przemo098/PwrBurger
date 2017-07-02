using System.Collections.Generic;
using System.Linq;
using PwrBurgers.Core.Model;

namespace PwrBurgers.Core.Repository
{
    public class BurgerRepository
    {
        private static readonly List<burgerGroup> burgerGroups = new List<burgerGroup>
        {
            new burgerGroup
            {
                BurgerGroupId = 1,
                Title = "Meat lovers",
                ImagePath = "",
                Burgers = new List<Burger>
                {
                    new Burger
                    {
                        BurgerId = 1,
                        Name = "Regular Burger",
                        ShortDescription = "The best there is on this planet",
                        Description =
                            "Super classy burger, great for small hungry",
                        ImagePath =
                            @"http://aht.seriouseats.com/images/images/04042011-145862-sessions-public-burger-1.jpg",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string> {"Regular bun", "100% Beef", "Ketchup"},
                        Price = 8,
                        IsFavorite = true
                    },
                    new Burger
                    {
                        BurgerId = 2,
                        Name = "Super whooper",
                        ShortDescription = "The classy one",
                        Description =
                            "Trololo some description",
                        ImagePath =
                            @"https://media-cdn.tripadvisor.com/media/photo-s/0c/57/e9/d3/the-classic-burger.jpg",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string> {"Baked bun", "200% Beef", "Fancy mustard from Australia"},
                        Price = 10,
                        IsFavorite = false
                    },
                    new Burger
                    {
                        BurgerId = 3,
                        Name = "Extra big",
                        ShortDescription = "For when a regular one isn't enough",
                        Description =
                            "Super whooper",
                        ImagePath =
                            @"https://s-media-cache-ak0.pinimg.com/originals/de/ae/02/deae02dee88a637d6a2310564de25361.jpg",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string> {"Extra big bun", "1000% Beef in Beef", "Moar all"},
                        Price = 8,
                        IsFavorite = true
                    }
                }
            },
            new burgerGroup
            {
                BurgerGroupId = 2,
                Title = "Veggie lovers",
                ImagePath = "",
                Burgers = new List<Burger>
                {
                   new Burger
                    {
                        BurgerId = 4,
                        Name = "Regular Burger",
                        ShortDescription = "The best there is on this planet",
                        Description =
                            "Super classy burger, great for small hungry",
                        ImagePath =
                            @"http://aht.seriouseats.com/images/images/04042011-145862-sessions-public-burger-1.jpg",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string> {"Regular bun", "100% Beef", "Ketchup"},
                        Price = 8,
                        IsFavorite = true
                    },
                    new Burger
                    {
                        BurgerId = 5,
                        Name = "Super whooper",
                        ShortDescription = "The classy one",
                        Description =
                            "Trololo some description",
                        ImagePath =
                            @"https://media-cdn.tripadvisor.com/media/photo-s/0c/57/e9/d3/the-classic-burger.jpg",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string> {"Baked bun", "200% Beef", "Fancy mustard from Australia"},
                        Price = 10,
                        IsFavorite = false
                    },
                    new Burger
                    {
                        BurgerId = 6,
                        Name = "Extra big",
                        ShortDescription = "For when a regular one isn't enough",
                        Description =
                            "Super whooper",
                        ImagePath =
                            @"https://s-media-cache-ak0.pinimg.com/originals/de/ae/02/deae02dee88a637d6a2310564de25361.jpg",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string> {"Extra big bun", "1000% Beef in Beef", "Moar all"},
                        Price = 8,
                        IsFavorite = true
                    }
                }
            }
        };

        public List<Burger> GetAllBurgers()
        {
            var burgers =
                from burgerGroup in burgerGroups
                from burger in burgerGroup.Burgers
                select burger;
            return burgers.ToList();
        }

        public Burger GetBurgerById(int burgerId)
        {
            var burgers =
                from burgerGroup in burgerGroups
                from burger in burgerGroup.Burgers
                where burger.BurgerId == burgerId
                select burger;

            return burgers.FirstOrDefault();
        }

        public List<burgerGroup> GetGroupedBurgers()
        {
            return burgerGroups;
        }

        public List<Burger> GetBurgersForGroup(int burgerGroupId)
        {
            var group = burgerGroups.FirstOrDefault(h => h.BurgerGroupId == burgerGroupId);

            if (group != null)
                return group.Burgers;
            return null;
        }

        public List<Burger> GetFavoriteBurgers()
        {
            var burgers =
                from burgerGroup in burgerGroups
                from burger in burgerGroup.Burgers
                where burger.IsFavorite
                select burger;

            return burgers.ToList();
        }
    }
}