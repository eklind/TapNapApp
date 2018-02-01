using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using Android.Media;

using System.Diagnostics;

namespace NapApp
{
    [Activity(Label = "NapApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private TextView _touchInfoTextView;
        private TextView _touchTimerTextView;
        private ImageView _touchMeImageView;
        MediaPlayer _player;
        Stopwatch elapTime = new Stopwatch();

        public int timer = 0;
        public int sleepTime = 20;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.touch_layout);
            _touchInfoTextView = FindViewById<TextView>(Resource.Id.touchInfoTextView);
            _touchTimerTextView = FindViewById<TextView>(Resource.Id.touchTimerTextView);
            _touchMeImageView = FindViewById<ImageView>(Resource.Id.touchImageView);

            _touchMeImageView.Touch += TouchMeImageViewOnTouch;
            _player = MediaPlayer.Create(this, Resource.Raw.alarm);
            //elapTime.Reset();
        }

        private void TouchMeImageViewOnTouch(object sender, View.TouchEventArgs touchEventArgs)
        {
            string message;
            
            if (elapTime.ElapsedMilliseconds < sleepTime * 1000)
            {
                elapTime.Reset();
                _player.Start();
            }
            
            switch (touchEventArgs.Event.Action & MotionEventActions.Mask)
            {
                //Happens one time
                case MotionEventActions.Down:
                    message = "Program running";
                    timer = timer + 1;
                    break;
                //Happens many times
                case MotionEventActions.Move:
                    // Handle both the Down and Move actions.
                    message = "Program running";
                    timer =timer+1;
                    break;
                //Happens one time
                case MotionEventActions.Up:
                    elapTime.Start();
                    message = "Wake up in!"+(elapTime.ElapsedMilliseconds); //milliseconds
                    timer = 0;
                    break;
                //Never
                default:
                    message = "default";
                    break;
            }
            _touchInfoTextView.Text = message;
            _touchTimerTextView.Text = timer.ToString();
        }
        

    }
    }

