using System.Collections.Generic;

namespace PwrBurgers.Core.Model
{
    public class burgerGroup
    {
        public int BurgerGroupId { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public List<Burger> Burgers { get; set; }
    }
}