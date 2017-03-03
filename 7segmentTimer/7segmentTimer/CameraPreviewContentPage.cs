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
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    
                    new CameraXamarineView
                    {
                        IsPreviewing = true,
                        Camera = CameraOptions.Rear,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    }
                    

                }
            };
        }

        protected override bool OnBackButtonPressed()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            App.LastReadLED = rnd.Next() % 30;

            System.Diagnostics.Debug.WriteLine("CameraPreviewContentPage - OnBackButtonPressed App.LastReadLED={0}", args: App.LastReadLED);

            return base.OnBackButtonPressed();
        }
    }
}