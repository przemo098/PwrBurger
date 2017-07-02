using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Widget;
using PwrBurgers.Model;
using Thread = Java.Lang.Thread;

namespace PwrBurgers
{
    [Activity(Label = "Cart")]
    class CartActivity : Activity
    {
        private MediaPlayer _player;
        private Button _proceedOrdersButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CartView);
            FindViewById<TextView>(Resource.Id.orderSummaryText).Text = Cart.OrderSummary();


            _proceedOrdersButton = FindViewById<Button>(Resource.Id.proceedOrderButton);
            _proceedOrdersButton.Click += ProceedOrder_Click;
        }

        private void ProceedOrder_Click(object sender, EventArgs e)
        {
            _player = MediaPlayer.Create(this, Resource.Raw.crazyFrog);

//            var temp = this.FindViewById<Button>(Resource.Id.proceedOrderButton);
//
//
//
//        var task = new Task(() => ChangeColorsRandomly(temp));
//                        var thread = new Thread(
//                            () => task.Start());
////                        thread.Start();
//
//            
//        task.Start();    

            _player.Start();
        }

        private void ChangeColorsRandomly(Button button)
        {
            var rand = new Random();


            while (true)
            {
                var number = rand.Next(Int32.MaxValue);
                var randColor = new Color(number);
                button.SetBackgroundColor(randColor);
//                Task.wait
            } //            this.
        }
    }
}