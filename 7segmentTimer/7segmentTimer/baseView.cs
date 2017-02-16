using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;


namespace _7segmentTimer
{
    class baseView
    {
            public static readonly BindableProperty CameraProperty = BindableProperty.Create(
                propertyName: "Camera",
                returnType: typeof(CameraOptions),
                declaringType: typeof(CameraPreview),
                defaultValue: CameraOptions.Rear);

            public CameraOptions Camera
            {
                get {return (CameraOptions)GetValue(CameraProperty); }
                set {SetValue(CameraProperty, value); }
            }
        }

    public enum CameraOptions
    {
        Rear,
        Front
    }
}