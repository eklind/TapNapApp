using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using Android.Media;

namespace NapApp
{
    [Activity(Label = "NapApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private TextView _touchInfoTextView;
        private TextView _touchTimerTextView;
        private ImageView _touchMeImageView;
        MediaPlayer _player;

        public int timer = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.touch_layout);
            _touchInfoTextView = FindViewById<TextView>(Resource.Id.touchInfoTextView);
            _touchTimerTextView = FindViewById<TextView>(Resource.Id.touchTimerTextView);
            _touchMeImageView = FindViewById<ImageView>(Resource.Id.touchImageView);

            _touchMeImageView.Touch += TouchMeImageViewOnTouch;
            _player = MediaPlayer.Create(this, Resource.Raw.alarm);
        }

        private void TouchMeImageViewOnTouch(object sender, View.TouchEventArgs touchEventArgs)
        {
            string message;
            switch (touchEventArgs.Event.Action & MotionEventActions.Mask)
            {
                case MotionEventActions.Down:
                    message = "Program running";
                    timer = timer + 1;
                    break;
                case MotionEventActions.Move:
                    // Handle both the Down and Move actions.
                    message = "Program running";
                    timer =timer+1;
                    break;

                case MotionEventActions.Up:
                    message = "Wake up!";
                    timer = 0;
                    _player.Start();
                    break;

                default:
                    message = "default";
                    break;
            }
            /*if (timer > 100)
            {
                _player.Reset();
                _player.Start();
            }*/
            _touchInfoTextView.Text = message;
            _touchTimerTextView.Text = timer.ToString();
        }
        

    }
    }

