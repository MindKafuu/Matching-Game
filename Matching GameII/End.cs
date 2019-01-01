using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace Matching_GameII
{
    [Activity(Label = "End")]
    public class End : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            if (widthInDp < 320 && heightInDp < 480)
                SetContentView(Resource.Layout.End_small);
            else if (widthInDp < 480 && heightInDp < 720)
                SetContentView(Resource.Layout.End_normal);
            else if (widthInDp < 640 && heightInDp < 960)
                SetContentView(Resource.Layout.End_large);
            else if (widthInDp > 640 && heightInDp > 960)
                SetContentView(Resource.Layout.End_xlarge);

            Button btnhome, btnplay;

            btnhome = FindViewById<Button>(Resource.Id.home);
            btnplay = FindViewById<Button>(Resource.Id.play);

            btnhome.Click += Btnhome_Click;
            btnplay.Click += Btnplay_Click;
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

        private void Btnhome_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        private void Btnplay_Click(object sender, EventArgs e)
        {
            this.Finish();
            Intent playPage = new Intent(this, typeof(Play));
            StartActivity(playPage);
        }
    }
}