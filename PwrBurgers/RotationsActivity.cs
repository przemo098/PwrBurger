using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PwrBurgers
{

    [Activity(Label = "Rotations !!")]
    class RotationsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.rotationsView);
//            FindViewById<TextView>(Resource.Id.orderSummaryText).Text = Cart.OrderSummary();


        }
    }
}