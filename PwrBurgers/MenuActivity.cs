using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace PwrBurgers
{
    [Activity(Label = "MenuActivity", MainLauncher = true)]
    public class MenuActivity : Activity
    {
        private Button _aboutButton;
        private Button _cartButton;
        private Button _mapButton;
        private Button _orderButton;
        private Button _takePictureButton;
        private Button _dataBaseButton;
        private Button _rotationsButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);

            FindViews();

            HandleEvents();
        }

        private void FindViews()
        {
            _orderButton = FindViewById<Button>(Resource.Id.orderButton);
            _cartButton = FindViewById<Button>(Resource.Id.cartButton);
            _aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            _mapButton = FindViewById<Button>(Resource.Id.mapButton);
            _takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
            _dataBaseButton = FindViewById<Button>(Resource.Id.dataBaseButton);
            _rotationsButton = FindViewById<Button>(Resource.Id.rotationsButton);
        }

        private void HandleEvents()
        {
            _orderButton.Click += OrderButton_Click;
            _aboutButton.Click += AboutButton_Click;
            _takePictureButton.Click += TakePictureButton_Click;
            _mapButton.Click += MapButton_Click;
            _cartButton.Click += CartButton_Click;
            _dataBaseButton.Click += DataBaseButton_Click;
            _rotationsButton.Click += RotationsButton_Click;
        }

        private void RotationsButton_Click(object sender, EventArgs e)
        {
            var intent  = new Intent(this, typeof(RotationsActivity));
            StartActivity(intent);
        }


        private void DataBaseButton_Click(object sender, EventArgs e)
        {
            var intent  = new Intent(this, typeof(DataBaseActivity));
            StartActivity(intent);
        }

        #region buttonClicks

        private void CartButton_Click(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(CartActivity));
            StartActivity(intent);
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BurgerMenuActivity));
            StartActivity(intent);
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(PwrBurgerMapActivity));
            StartActivity(intent);
        }

        #endregion
    }
}