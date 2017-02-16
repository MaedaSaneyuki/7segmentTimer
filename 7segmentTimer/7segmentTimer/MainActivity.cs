using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace _7segmentTimer
{
    [Activity(Label = "_7segmentTimer", MainLauncher = true, Icon = "@drawable/icon")]
    //public class MainActivity : Activity
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

