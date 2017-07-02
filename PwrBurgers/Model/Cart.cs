using System.Collections.Generic;
using System.Linq;
using Java.Lang;
using PwrBurgers.Core.Model;

namespace PwrBurgers.Model
{
    static class Cart
    {
        public static List<Burger> Orders = new List<Burger>();

        public static string OrderSummary()
        {
            var sb =  new StringBuilder();

            foreach (var burger in Orders)
            {
                sb.Append($"{burger.Name} {burger.Price}$\n");
            }

            sb.Append($"Totally: {Orders.Sum(x => x.Price)}");

            return sb.ToString();
        }
    }
}