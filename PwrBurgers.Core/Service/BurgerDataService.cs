using System.Collections.Generic;
using PwrBurgers.Core.Model;
using PwrBurgers.Core.Repository;

namespace PwrBurgers.Core.Service
{
    public class BurgerDataService
    {
        private static BurgerRepository _burgerRepository = new BurgerRepository();

        public List<Burger> GetAllBurgers()
        {
            return _burgerRepository.GetAllBurgers();
        }

        public List<burgerGroup> GetGroupedBurgers()
        {
            return _burgerRepository.GetGroupedBurgers();
        }

        public List<Burger> GetBurgersForGroup(int burgerGroupId)
        {
            return _burgerRepository.GetBurgersForGroup(burgerGroupId);
        }

        public List<Burger> GetFavoriteBurgers()
        {
            return _burgerRepository.GetFavoriteBurgers();
        }

        public Burger GetBurgerById(int burgerId)
        {
            return _burgerRepository.GetBurgerById(burgerId);
        }
    }
}
