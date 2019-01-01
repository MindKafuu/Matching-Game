using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

namespace Matching_GameII
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            if (widthInDp < 320 && heightInDp < 480)
                SetContentView(Resource.Layout.Main_small);
            else if (widthInDp < 480 && heightInDp < 720)
                SetContentView(Resource.Layout.Main_normal);
            else if (widthInDp < 640 && heightInDp < 960)
                SetContentView(Resource.Layout.Main_large);
            else if (widthInDp > 640 && heightInDp > 960)
                SetContentView(Resource.Layout.Main_xlarge);

            Button button = FindViewById<Button>(Resource.Id.btnHome);
            button.Click += Button_Click;
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

        private void Button_Click(object send, EventArgs e)
        {
            Intent playPage = new Intent(this, typeof(Play));
            StartActivity(playPage);
        }
    }
}