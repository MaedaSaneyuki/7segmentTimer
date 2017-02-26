using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace _7segmentTimer
{
    [Activity(Label = "コインランドリータイマー", MainLauncher = true)]
    //public class MainActivity : Activity
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetTheme(Android.Resource.Style.ThemeTranslucentNoTitleBarFullScreen);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

