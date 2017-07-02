using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using PwrBurgers;
using PwrBurgers.Core.Model;
using PwrBurgers.Utility;

namespace PwrBurgers.Adapters
{
    public class BurgerListAdapter: BaseAdapter<Burger>
    {
        List<Burger> items;
        Activity context;

        public BurgerListAdapter(Activity context, List<Burger> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Burger this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(item.ImagePath);

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.BurgerRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.burgerNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$ " + item.Price;
            convertView.FindViewById<ImageView>(Resource.Id.burgerImageView).SetImageBitmap(imageBitmap);

            return convertView;
        }

    }
}