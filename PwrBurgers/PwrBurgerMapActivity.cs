using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace PwrBurgers
{
    [Activity(Label = "Visit store")]
    public class PwrBurgerMapActivity : Activity
    {
        private Button externalMapButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PwrBurgerMapView);

            FindViews();

            HandleEvents();

        }

        private void FindViews()
        {
            externalMapButton = FindViewById<Button>(Resource.Id.externalMapButton);
        }

        private void HandleEvents()
        {
            externalMapButton.Click += ExternalMapButton_Click;
        }

        private void ExternalMapButton_Click(object sender, EventArgs e)
        {
            //            Android.Net.Uri rayLocationUri = Android.Net.Uri.Parse("geo:0,0?q=51.108673,17.060158(PWr Burgers !)");
            //            Intent mapIntent = new Intent(Intent.ActionView, rayLocationUri);
            //            StartActivity(mapIntent);

            Android.Net.Uri gmmIntentUri = Android.Net.Uri.Parse("geo:37.7749,-122.4194");
            Intent mapIntent = new Intent(Intent.ActionView, gmmIntentUri);
            mapIntent.SetPackage("com.google.android.apps.maps");
            StartActivity(mapIntent);
        }
    }
}