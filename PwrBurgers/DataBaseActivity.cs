using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Microsoft.EntityFrameworkCore;
using Mono.Data.Sqlite;
using PwrBurgers.Core.Model;
using PwrBurgers.Core.Model.Context;
using Environment = System.Environment;

namespace PwrBurgers
{
    [Activity(Label = "DataBaseActivity")]
    public class DataBaseActivity : Activity
    {
        int count = 1;
        private CatContext _db;
        private EditText newUserName;
        private EditText meowCount;
        private Button countClickButton;
        private Button addUserButton;

        protected override void OnDestroy()
        {
            _db.Dispose();
        }

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.DataBaseView);

            // Get our button from the layout resource,
            // and attach an event to it
            newUserName = FindViewById<EditText>(Resource.Id.dbUserName);
            meowCount = FindViewById<EditText>(Resource.Id.meowsCount);

            setEditText();

            countClickButton = FindViewById<Button>(Resource.Id.MyButton);
            addUserButton = FindViewById<Button>(Resource.Id.AddUserButton);


            TextView textView = (TextView)FindViewById(Resource.Id.CatsView);
            await InitializeDb(textView);


            countClickButton.Click += delegate { countClickButton.Text = string.Format("{0} clicks!", count++); };
            addUserButton.Click += async delegate
            {
                Cat newCat = new Cat() { CatId = _db.Cats.Count() + 1, Name = newUserName.Text, MeowsPerSecond = int.Parse(meowCount.Text) };
                this._db.Cats.Add(newCat);
                _db.SaveChanges();
                await PrintUsers(textView, _db);

            };
        }

        private async System.Threading.Tasks.Task InitializeDb(TextView textView)
        {

            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "Cats.db";
            var dbFullPath = Path.Combine(dbFolder, fileName);

            CreateDb(dbFullPath);
            try
            {
                _db = new CatContext(dbFullPath);


                var lol = await _db.Cats.ToListAsync();

                if (!lol.Any())
                {
                    await generateFakeData(_db);
                }

                await PrintUsers(textView, _db);


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void setEditText()
        {
            newUserName.KeyPress += (object sender, View.KeyEventArgs e) => {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    Toast.MakeText(this, newUserName.Text, ToastLength.Short).Show();
                    e.Handled = true;
                }
            };
            meowCount.KeyPress += (object sender, View.KeyEventArgs e) => {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    Toast.MakeText(this, meowCount.Text, ToastLength.Short).Show();
                    e.Handled = true;
                }
            };

        }

        private static async System.Threading.Tasks.Task PrintUsers(TextView textView, CatContext db)
        {
            var catsInTheBag = await db.Cats.ToListAsync();

            textView.Text = String.Empty;

            foreach (var cat in catsInTheBag)
            {
                textView.Text += $"{cat.CatId} - {cat.Name} - {cat.MeowsPerSecond}" + System.Environment.NewLine;
            }
        }

        private static async System.Threading.Tasks.Task generateFakeData(CatContext db)
        {
            await db.Database.MigrateAsync();
            //We need to ensure the latest Migration was added. This is different than EnsureDatabaseCreated.

            Cat catGary = new Cat() { CatId = 1, Name = "Gary", MeowsPerSecond = 5 };
            Cat catJack = new Cat() { CatId = 2, Name = "Jack", MeowsPerSecond = 11 };
            Cat catLuna = new Cat() { CatId = 3, Name = "Luna", MeowsPerSecond = 3 };

            List<Cat> catsInTheHat = new List<Cat>() { catGary, catJack, catLuna };

            if (await db.Cats.CountAsync() < 3)
            {
                await db.Cats.AddRangeAsync(catsInTheHat);
                await db.SaveChangesAsync();
            }
        }

        private async void CreateDb(string pathToDatabase)
        {
            var connectionString = string.Format("Data Source={0};Version=3;", pathToDatabase);
            try
            {
                using (var conn = new SqliteConnection((connectionString)))
                {
                    await conn.OpenAsync();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = "CREATE TABLE Cats (CatId INTEGER PRIMARY KEY AUTOINCREMENT, Name ntext, MeowsPerSecond integer)";
                        command.CommandType = CommandType.Text;
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var reason = string.Format("Failed to insert into the database - reason = {0}", ex.Message);
                Toast.MakeText(this, reason, ToastLength.Long).Show();
            }
        }
    }
}