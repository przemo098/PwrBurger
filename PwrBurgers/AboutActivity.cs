using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace PwrBurgers
{
    [Activity(Label = "About PWr burgers.")]
    public class AboutActivity : Activity
    {
        private TextView _phoneNumberTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AboutView);

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            _phoneNumberTextView = FindViewById<TextView>(Resource.Id.phoneNumberTextView);
        }

        private void HandleEvents()
        {
            _phoneNumberTextView.Click += PhoneNumberTextView_Click;
        }

        private void PhoneNumberTextView_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("tel:" + _phoneNumberTextView.Text);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);
        }

    }
}