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
    class CameraPreviewContentPage : ContentPage
    {
        public CameraPreviewContentPage()
        {
            Content = new StackLayout
            {
                Spacing = 15,
                VerticalOptions = LayoutOptions.Start,
                Children = {
                    new CameraXamarineView
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    }

                }
            };
        }
    }
}