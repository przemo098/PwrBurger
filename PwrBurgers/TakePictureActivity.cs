using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Java.IO;
using PwrBurgers.Utility;

namespace PwrBurgers
{
    [Activity(Label = "Take a picture !")]
    public class TakePictureActivity : Activity
    {
        private ImageView pwrBurgerPictureImageView;
        private Button takePictureButton;
        private File imageDirectory;
        private File imageFile;
        private Bitmap imageBitmap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TakePictureView);

            FindViews();

            HandleEvents();

            imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryPictures), "PwrBurgerBurgers");

            if (!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }

        }

        private void FindViews()
        {
            pwrBurgerPictureImageView = FindViewById<ImageView>(Resource.Id.rayPictureImageView);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            imageFile = new File(imageDirectory, String.Format("PwrBurgerLogo_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            int height = pwrBurgerPictureImageView.Height;
            int width = pwrBurgerPictureImageView.Width;
            imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);

            if (imageBitmap != null)
            {
                pwrBurgerPictureImageView.SetImageBitmap(imageBitmap);
                imageBitmap = null;
            }

            //required to avoid memory leaks!
            GC.Collect();
        }

    }
}