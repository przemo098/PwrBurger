using Android.OS;
using Android.Views;
using PwrBurgers.Adapters;

namespace PwrBurgers.Fragments
{
    public class MeatLoversFragment : BaseFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();

            HandleEvents();

            burgers = BurgerDataService.GetBurgersForGroup(1);
            listView.Adapter = new BurgerListAdapter(this.Activity, burgers);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.MeatLoversFragment, container, false);
        }
    }
}