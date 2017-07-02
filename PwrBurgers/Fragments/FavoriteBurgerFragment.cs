using Android.OS;
using Android.Views;
using PwrBurgers.Adapters;

namespace PwrBurgers.Fragments
{
    public class FavoriteBurgerFragment : BaseFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            FindViews();

            HandleEvents();

            burgers = BurgerDataService.GetFavoriteBurgers();
            listView.Adapter = new BurgerListAdapter(Activity, burgers);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.FavoriteBurgerFragment, container, false);
        }
    }
}