using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using PwrBurgers.Core.Model;
using PwrBurgers.Core.Service;
using PwrBurgers.Model;
using PwrBurgers.Utility;

namespace PwrBurgers
{
    [Activity(Label = "Hotdog details")]
    public class BurgerDetailActivity : Activity
    {
        private ImageView _burgerImageView;
        private TextView _burgerNameTextView;
        private TextView _shortDescriptionTextView;
        private TextView _descriptionTextView;
        private TextView _priceTextView;
        private EditText _amountEditText;
        private Button _cancelButton;
        private Button _orderButton;

        private Burger _selectedBurger;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.BurgerDetailView);

            BurgerDataService dataService = new BurgerDataService();
            var selectedBurgerId = Intent.Extras.GetInt("selectedBurgerId");
            _selectedBurger = dataService.GetBurgerById(selectedBurgerId);

            FindViews();

            BindData();

            HandleEvents();
        }

        private void FindViews()
        {
            _burgerImageView = FindViewById<ImageView>(Resource.Id.burgerImageView);
            _burgerNameTextView = FindViewById<TextView>(Resource.Id.burgerNameTextView);
            _shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            _descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            _priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            _amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            _cancelButton = FindViewById<Button>(Resource.Id.cancelButton); 
            _orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {
            _burgerNameTextView.Text = _selectedBurger.Name;
            _shortDescriptionTextView.Text = _selectedBurger.ShortDescription;
            _descriptionTextView.Text = _selectedBurger.Description;
            _priceTextView.Text = "Price: " + _selectedBurger.Price;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(_selectedBurger.ImagePath);

            _burgerImageView.SetImageBitmap(imageBitmap);
        }

        private void HandleEvents()
        {
            _orderButton.Click += OrderButton_Click;
            _cancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var amount = Int32.Parse(_amountEditText.Text);

            AddBurgersToCart(amount);
            CreateOrderNotification(amount);
        }

        private void AddBurgersToCart(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Cart.Orders.Add(_selectedBurger);
            }
        }

        private void CreateOrderNotification(int burgerAmount)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Confirmation");
            alert.SetMessage("Your burger has been added to your cart.");
            alert.SetPositiveButton("OK", (senderAlert, args) =>
            {
                Toast.MakeText(this, "Burger added!", ToastLength.Short).Show();

                //TODO: Move redirect to cart ?

                var intent = new Intent();
                intent.PutExtra("selectedBurgerId", _selectedBurger.BurgerId);
                intent.PutExtra("burgerAmount", burgerAmount);

                SetResult(Result.Ok, intent);
                Finish();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}