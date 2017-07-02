using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using PwrBurgers.Core.Service;
using PwrBurgers.Fragments;

namespace PwrBurgers
{
    [Activity(Label = "BurgerMenuActivity")]
    public class BurgerMenuActivity : Activity
    {
//        private ListView burgerListView;
//        private List<Burger> allBurgers;
        private BurgerDataService BurgerDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BurgerMenuView);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Favorites", Resource.Drawable.FavoritesIcon, new FavoriteBurgerFragment());
            AddTab("Meat Lovers", Resource.Drawable.MeatLoversIcon, new MeatLoversFragment());
            AddTab("Veggie Lovers", Resource.Drawable.VeggieLoversIcon, new VeggieLoversFragment());
        }

        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedBurger = BurgerDataService.GetBurgerById(data.GetIntExtra("selectedBurgerId", 0));

                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage(string.Format("You've added {0} time(s) the {1}", data.GetIntExtra("amount", 0), selectedBurger.Name));
                dialog.Show();
            }
        }
    }

}