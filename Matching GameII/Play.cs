using System;
using System.Collections.Generic;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Matching_GameII
{
    [Activity(Label = "play")]
    public class Play : AppCompatActivity
    {
        ImageView img1, img2, img3, img4, img5, img6, img7, img8, img9, img10;
        Button[] button = new Button[17];
        Queue<int> sum = new Queue<int>();
        List<int> checklist = new List<int>();
        Timer time;
        int count = 0;
        int randF, randS, timecount, setTime;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            if (widthInDp < 320 && heightInDp < 480)
                SetContentView(Resource.Layout.Play_small);
            else if (widthInDp < 480 && heightInDp < 720)
                SetContentView(Resource.Layout.Play_normal);
            else if (widthInDp < 640 && heightInDp < 960)
                SetContentView(Resource.Layout.Play_large);
            else if (widthInDp > 640 && heightInDp > 960)
                SetContentView(Resource.Layout.Play_xlarge);

            randF = Intent.GetIntExtra("randF", 10);
            randS = Intent.GetIntExtra("randS", 10);

            button[0] = FindViewById<Button>(Resource.Id.btnBack);
            button[1] = FindViewById<Button>(Resource.Id.btn1);
            button[2] = FindViewById<Button>(Resource.Id.btn2);
            button[3] = FindViewById<Button>(Resource.Id.btn3);
            button[4] = FindViewById<Button>(Resource.Id.btn4);
            button[5] = FindViewById<Button>(Resource.Id.btn5);
            button[6] = FindViewById<Button>(Resource.Id.btn6);
            button[7] = FindViewById<Button>(Resource.Id.btn7);
            button[8] = FindViewById<Button>(Resource.Id.btn8);
            button[9] = FindViewById<Button>(Resource.Id.btn9);
            button[10] = FindViewById<Button>(Resource.Id.btn10);
            button[11] = FindViewById<Button>(Resource.Id.btn11);
            button[12] = FindViewById<Button>(Resource.Id.btn12);
            button[13] = FindViewById<Button>(Resource.Id.btn13);
            button[14] = FindViewById<Button>(Resource.Id.btn14);
            button[15] = FindViewById<Button>(Resource.Id.btn15);
            button[16] = FindViewById<Button>(Resource.Id.btn16);

            img1 = FindViewById<ImageView>(Resource.Id.image1);
            img2 = FindViewById<ImageView>(Resource.Id.image2);
            img3 = FindViewById<ImageView>(Resource.Id.image3);
            img4 = FindViewById<ImageView>(Resource.Id.image4);
            img5 = FindViewById<ImageView>(Resource.Id.image5);
            img6 = FindViewById<ImageView>(Resource.Id.image6);
            img7 = FindViewById<ImageView>(Resource.Id.image7);
            img8 = FindViewById<ImageView>(Resource.Id.image8);
            img9 = FindViewById<ImageView>(Resource.Id.image9);
            img10 = FindViewById<ImageView>(Resource.Id.image10);

            button[0].Click += Button_Click;
            button[1].Click += Button1_Click;
            button[2].Click += Button2_Click;
            button[3].Click += Button3_Click;
            button[4].Click += Button4_Click;
            button[5].Click += Button5_Click;
            button[6].Click += Button6_Click;
            button[7].Click += Button7_Click;
            button[8].Click += Button8_Click;
            button[9].Click += Button9_Click;
            button[10].Click += Button10_Click;
            button[11].Click += Button11_Click;
            button[12].Click += Button12_Click;
            button[13].Click += Button13_Click;
            button[14].Click += Button14_Click;
            button[15].Click += Button15_Click;
            button[16].Click += Button16_Click;

            List<int> list = new List<int>();
            Queue<int> queue = new Queue<int>();
            Random rand = new Random();

            for (int i = 1; i <= 16; i++)
            {
                list.Add(i);
            }

            for (int j = 0; j < 8; j++)
            {
                var index = rand.Next(list.Count);
                var item = list[index];
                list.RemoveAt(index);
                var fnum = rand.Next(1, randF);
                var lnum = rand.Next(1, randS);
                queue.Enqueue(fnum + lnum);
                button[item].Text = fnum + "+" + lnum;

                index = rand.Next(list.Count);
                item = list[index];
                list.RemoveAt(index);
                var ans = queue.Dequeue();
                button[item].Text = ans + " ";
            }

        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button[1].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[1].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(1);
            CheckAns();
            button[1].Pressed = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button[2].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[2].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(2);
            CheckAns();
            button[2].Pressed = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            button[3].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[3].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(3);
            CheckAns();
            button[3].Pressed = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button[4].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[4].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(4);
            CheckAns();
            button[4].Pressed = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button[5].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[5].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(5);
            CheckAns();
            button[5].Pressed = false;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            button[6].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[6].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(6);
            CheckAns();
            button[6].Pressed = false;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            button[7].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[7].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(7);
            CheckAns();
            button[7].Pressed = false;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            button[8].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[8].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(8);
            CheckAns();
            button[8].Pressed = false;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            button[9].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[9].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(9);
            CheckAns();
            button[9].Pressed = false;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            button[10].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[10].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(10);
            CheckAns();
            button[10].Pressed = false;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            button[11].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[11].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(11);
            CheckAns();
            button[11].Pressed = false;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            button[12].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[12].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(12);
            CheckAns();
            button[12].Pressed = false;
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            button[13].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[13].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(13);
            CheckAns();
            button[13].Pressed = false;
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            button[14].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[14].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(14);
            CheckAns();
            button[14].Pressed = false;
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            button[15].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[15].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(15);
            CheckAns();
            button[15].Pressed = false;
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            button[16].SetBackgroundColor(Android.Graphics.Color.GhostWhite);
            string[] splits = button[16].Text.Split('+');
            int val = 0;
            int add = 0;
            foreach (string split in splits)
            {
                Int32.TryParse(split, out val);
                add = add + val;
            }
            sum.Enqueue(add);
            sum.Enqueue(16);
            CheckAns();
            button[16].Pressed = false;
        }

        public void ReleaseButton()
        {
            for (int i = 1; i <= 16; i++)
            {
                button[i].Pressed = false;
            }
        }

        public void CheckAns()
        {
            if (sum.Count > 3)
            {
                var first = sum.Dequeue();
                var fbt = sum.Dequeue();
                var second = sum.Dequeue();
                var sbt = sum.Dequeue();

                if (first == second)
                {
                    button[fbt].Visibility = ViewStates.Invisible;
                    button[sbt].Visibility = ViewStates.Invisible;
                    checklist.Add(fbt);
                    checklist.Add(sbt);
                    ReleaseButton();
                }
                else
                {
                    ReleaseButton();
                    button[fbt].SetBackgroundColor(Android.Graphics.Color.LightSeaGreen);
                    button[sbt].SetBackgroundColor(Android.Graphics.Color.LightSeaGreen);
                    count = count - 5;
                }
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            time = new Timer();
            time.Interval = 1000;
            time.Elapsed += Time_Elapsed;
            setTime = Intent.GetIntExtra("setTime", 30);
            timecount = setTime / 10;
            count = setTime;
            time.Start();
        }

        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            count = count - 1;
            if (count < timecount * 10)
            {
                RunOnUiThread(() =>
                {
                    img10.Visibility = ViewStates.Invisible;
                });
            }
            if (count < timecount * 9)
            {
                RunOnUiThread(() =>
                {
                    img9.Visibility = ViewStates.Invisible;
                });
            }
            if (count < timecount * 8)
            {
                RunOnUiThread(() =>
                {
                    img8.Visibility = ViewStates.Invisible;
                });
            }
            if (count < timecount * 7)
            {
                RunOnUiThread(() =>
                {
                    img7.Visibility = ViewStates.Invisible;
                });
            }
            if (count < timecount * 6)
            {
                RunOnUiThread(() =>
                {
                    img6.Visibility = ViewStates.Invisible;
                });
            }
            if (count < timecount * 5)
            {
                RunOnUiThread(() =>
                {
                    img5.Visibility = ViewStates.Invisible;
                });
            }
            if (count < timecount * 4)
            {
                RunOnUiThread(() =>
                {
                    img4.Visibility = ViewStates.Invisible;
                });
            }
            if (count < timecount * 3)
            {
                RunOnUiThread(() =>
                {
                    img3.Visibility = ViewStates.Invisible;
                });
            }
            if (count < timecount * 2)
            {
                RunOnUiThread(() =>
                {
                    img2.Visibility = ViewStates.Invisible;
                });
            }
            if (count < timecount)
            {
                RunOnUiThread(() =>
                {
                    img1.Visibility = ViewStates.Invisible;
                });
            }
            if (count < 0)
            {
                if (checklist.Count < 16)
                {
                    this.Finish();
                    checklist.Clear();
                    Intent endPage = new Intent(this, typeof(End));
                    StartActivity(endPage);
                    time.Stop();
                }
            }

            if (checklist.Count == 16)
            {
                this.Finish();
                setTime = setTime + 20;
                randF = randF + 10;
                randS = randS + 10;
                checklist.Clear();
                Intent playPage = new Intent(this, typeof(Play));
                playPage.PutExtra("setTime", setTime);
                playPage.PutExtra("randF", randF);
                playPage.PutExtra("randS", randS);
                StartActivity(playPage);
                time.Stop();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            this.Finish();
            time.Stop();
        }
    }
}