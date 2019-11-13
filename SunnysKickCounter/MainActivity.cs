using System;
using System.Diagnostics;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace SunnysKickCounter
{
    [Activity(Label = "Sunny's Kick Counter'", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //fab.Click += FabOnClick;
            var kickCount = 0;
            var kickTimer = new Stopwatch();

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            TextView dailyKickCount = FindViewById<TextView>(Resource.Id.dailyKickCount);
            dailyKickCount.Text = kickCount.ToString();

            TextView elapsedTime = FindViewById<TextView>(Resource.Id.lastKickElapsedTime);
            elapsedTime.Text = kickTimer.ElapsedMilliseconds.ToString();

            Button kickCountButton = FindViewById<Button>(Resource.Id.countKick);

            //kickCountButton.Click

            FindViewById<Button>(Resource.Id.countKick).Click +=
                (o, e) => dailyKickCount.Text = (++kickCount).ToString();
        }



        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }
        
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

