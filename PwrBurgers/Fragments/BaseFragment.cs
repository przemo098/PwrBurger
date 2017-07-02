using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using PwrBurgers.Core.Model;
using PwrBurgers.Core.Service;
using PwrBurgers;

namespace PwrBurgers.Fragments
{
    public class BaseFragment: Fragment
    {
        protected ListView listView;
        protected BurgerDataService BurgerDataService;
        protected List<Burger> burgers;

        public BaseFragment()
        {
            BurgerDataService = new BurgerDataService();
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }
        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.burgerListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var burger = burgers[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(BurgerDetailActivity));
            intent.PutExtra("selectedBurgerId", burger.BurgerId);

            StartActivityForResult(intent, 100);
        }
    }
}